using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ja_projekt
{
    internal class ThreadManager
    {

        private ConcurrentQueue<CSV> inputList;
        private ConcurrentQueue<CSV> outputList;
        private String sourceFilePath;
        private String targetFilePath;
        private Liblary liblary = Liblary.CPP;
        private int threads = Environment.ProcessorCount;

        public ThreadManager(String sourceFilePathStr, String targetFilePathStr, Liblary newLiblary, int newThreads)
        {
            inputList = new ConcurrentQueue<CSV>();
            outputList = new ConcurrentQueue<CSV>();
            this.sourceFilePath = sourceFilePathStr;
            this.targetFilePath = targetFilePathStr;
            liblary = newLiblary;
            threads = newThreads;
        }

        public void SetSourceFilePath(String str)
        {
            sourceFilePath = str;
        }

        public void SetTaegetFilePath(String str)
        {
            targetFilePath = str;
        }

        public void SetLiblary(Liblary lib)
        {
            liblary = lib;
        }

        public String Start()
        {
            LoadFromFile();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (liblary == Liblary.ASM)
            {
                CalculateASM();
            }
            else
            {
                CalculateCPP();
            }
            stopWatch.Stop();
            SaveToFile();
            return String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            stopWatch.Elapsed.Hours, stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds,
            stopWatch.Elapsed.Milliseconds);
        }

        private void SaveToFile()
        {
            using (StreamWriter stream = new StreamWriter(targetFilePath))
            {
                CSV csv;
                while (outputList.TryDequeue(out csv))
                {
                    stream.WriteLine(csv.ToString());
                }
            }

        }

        private void LoadFromFile()
        {
            StreamReader stream = new StreamReader(sourceFilePath);
            String line;
            while (!stream.EndOfStream)
            {
                line = stream.ReadLine();
                if (line != null)
                {
                    inputList.Enqueue(new CSV(line, false));
                }
            }
        }


        private void CalculateASM()
        {
            List<Thread> threadsList = new List<Thread>();
            for (int i = 0; i < threads; i++)
            {
                threadsList.Add(new Thread(new ThreadStart(ThreadASM)));
                threadsList[i].Start();
            }
            while (!inputList.IsEmpty)
            {
                Thread.Sleep(1);
            }

        }

        private void CalculateCPP()
        {
            List<Thread> threadsList = new List<Thread>();
            for (int i = 0; i < threads; i++)
            {
                threadsList.Add(new Thread(new ThreadStart(ThreadCPP)));
                threadsList[i].Start();
            }
            while (!inputList.IsEmpty)
            {
                Thread.Sleep(1);
            }
            //ThreadPool.SetMaxThreads(threads, threads);
            //using (var countdownEvent = new CountdownEvent(inputList.Count))
            //{
            //    for (int i = 0; i < count; i++)
            //    {
            //        ThreadPool.QueueUserWorkItem(state =>
            //        {
            //            CSV csv = inputList[i];
            //            this.WorkerCPP(csv);
            //            countdownEvent.Signal();
            //        }
            //        );

            //    }
            //    foreach (var item in inputList)
            //    {
            //        ThreadPool.QueueUserWorkItem(state =>
            //        {
            //            this.WorkerCPP(item);
            //            countdownEvent.Signal();
            //        });
            //    }
            //    countdownEvent.Wait();
            //    outputList.CompleteAdding();
            //}

        }

        private void ThreadASM()
        {
            CSV local;
            while (inputList.TryDequeue(out local))
            {
                WorkerASM(local);
            }
        }

        private unsafe void WorkerASM(CSV inputCSV)
        {
            byte[] strByte = Encoding.ASCII.GetBytes(inputCSV.GetString());
            fixed (byte* ptr = &strByte[0])
            {
                if (Program.calculateLuhnValueASM(ptr) == 0)
                {
                    outputList.Enqueue(new CSV(inputCSV.GetString(), true));
                }
                else
                {
                    outputList.Enqueue((new CSV(inputCSV.GetString(), false)));
                }
            }
        }

        private void ThreadCPP()
        {
            CSV local;
            while (inputList.TryDequeue(out local))
            {
                WorkerCPP(local);
            }
        }

        private unsafe void WorkerCPP(CSV inputCSV)
        {
            byte[] strByte = Encoding.ASCII.GetBytes(inputCSV.GetString());
            fixed (byte* ptr = &strByte[0])
            {
                if (Program.calculateLuhnValueC(ptr) == 0)
                {
                    outputList.Enqueue(new CSV(inputCSV.GetString(), true));
                }
                else
                {
                    outputList.Enqueue((new CSV(inputCSV.GetString(), false)));
                }
            }
        }
    }
}
