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

        private List<CSV> inputList;
        private BlockingCollection<CSV> outputList;
        private String sourceFilePath;
        private String targetFilePath;
        private Liblary liblary = Liblary.CPP;
        private int threads = Environment.ProcessorCount;

        public ThreadManager(String sourceFilePathStr, String targetFilePathStr, Liblary newLiblary, int newThreads)
        {
            inputList = new List<CSV>();
            outputList = new BlockingCollection<CSV>();
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
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            stopWatch.Elapsed.Hours, stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds,
            stopWatch.Elapsed.Milliseconds / 10);
        }

        private void SaveToFile()
        {
            using(StreamWriter stream = new StreamWriter(targetFilePath))
            {
                foreach (CSV csv in outputList)
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
                    inputList.Add(new CSV(line, false));
                }
            }
        }


        private void CalculateASM()
        {
            ThreadPool.SetMaxThreads(threads, threads);
            using (var countdownEvent = new CountdownEvent(inputList.Count))
            {
                foreach (var item in inputList)
                {
                    ThreadPool.QueueUserWorkItem(state =>
                    {
                        this.WorkerASM(item);
                        countdownEvent.Signal();
                    });
                }
                countdownEvent.Wait();
                outputList.CompleteAdding();
            }
            
        }

        private void CalculateCPP()
        {
            ThreadPool.SetMaxThreads(threads, threads);
            using (var countdownEvent = new CountdownEvent(inputList.Count))
            {
                int count = inputList.Count;
                //for (int i = 0; i < count; i++)
                //{
                //    ThreadPool.QueueUserWorkItem(state =>
                //    {
                //        CSV csv = inputList[i];
                //        this.WorkerCPP(csv);
                //        countdownEvent.Signal();
                //    }
                //    );

                //}
                foreach (var item in inputList)
                {
                    ThreadPool.QueueUserWorkItem(state =>
                    {
                        this.WorkerCPP(item);
                        countdownEvent.Signal();
                    });
                }
                countdownEvent.Wait();
                outputList.CompleteAdding();
            }

        }

        private unsafe void WorkerASM(CSV inputCSV)
        {
            String strZero = inputCSV.GetStringWithZero();
            int oldChecksum = inputCSV.GetChecksum();
            int calculatedChecksum;
            byte[] str = Encoding.ASCII.GetBytes(strZero);
            fixed (byte* ptr = &str[0])
            {
                calculatedChecksum = Program.calculateLuhnValueASM(ptr);
            }
            if(oldChecksum != calculatedChecksum)
            {
                outputList.Add(new CSV(inputCSV.GetString(), false));
            }
            else
            {
                outputList.Add((new CSV(inputCSV.GetString(), true)));
            }
        }

        private unsafe void WorkerCPP(CSV inputCSV)
        {
            String strZero = inputCSV.GetStringWithZero();
            int oldChecksum = inputCSV.GetChecksum();
            int calculatedChecksum;
            byte[] str = Encoding.ASCII.GetBytes(strZero);
            fixed (byte* ptr = &str[0])
            {
                calculatedChecksum = Program.calculateLuhnValueC(ptr);
            }
            if (oldChecksum != calculatedChecksum)
            {
                outputList.Add(new CSV(inputCSV.GetString(), false));
            }
            else
            {
                outputList.Add((new CSV(inputCSV.GetString(), true)));
            }
        }

    }
}
