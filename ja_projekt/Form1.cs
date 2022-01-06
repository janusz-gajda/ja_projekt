using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ja_projekt
{
    public partial class Form1 : Form
    {
        Liblary lib = Liblary.CPP;
        int threads = Environment.ProcessorCount;
        public Form1()
        {
            
            InitializeComponent();
            threadsSlderSetValue(Environment.ProcessorCount);

        }

        private void libC_CheckedChanged(object sender, EventArgs e)
        {
            lib = Liblary.CPP;
        }

        private void libAsm_CheckedChanged(object sender, EventArgs e)
        {
            lib = Liblary.ASM;
        }

        private unsafe void startButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(sourceFilePath.Text))
            {
                MessageBox.Show("Specify Source File!", "Source File not specified", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(targetFilePath.Text))
            {
                MessageBox.Show("Specify Target File!", "Target File not specified", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ThreadManager threadManager = new ThreadManager(sourceFilePath.Text, targetFilePath.Text, lib, threads);
            timeLabel.Text = threadManager.Start();
            threadManager = null;
        }

        private void sourceFileChooseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Title = "Choose file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {   
                sourceFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void targetFileChooseButton_Click(object sender, EventArgs e)
        {
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    InitialDirectory = Directory.GetCurrentDirectory(),
                    Title = "Choose file",

                    CheckFileExists = false,
                    CheckPathExists = true,

                    DefaultExt = "csv",
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true

                };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    targetFilePath.Text = saveFileDialog1.FileName;
                }
            }
        }

        private void threadsSlider_Scroll(object sender, EventArgs e)
        {
            switch (threadsSlider.Value)
            {
                case 0:
                    threadsCountLabel.Text = "1";
                    threads = 1;
                    break;
                case 1:
                    threadsCountLabel.Text = "2";
                    threads = 2;
                    break;
                case 2:
                    threadsCountLabel.Text = "4";
                    threads = 4;
                    break;
                case 3:
                    threadsCountLabel.Text = "6";
                    threads = 6;
                    break;
                case 4:
                    threadsCountLabel.Text = "8";
                    threads = 8;
                    break;
                case 5:
                    threadsCountLabel.Text = "12";
                    threads = 12;
                    break;
                case 6:
                    threadsCountLabel.Text = "16";
                    threads = 16;
                    break;
                case 7:
                    threadsCountLabel.Text = "24";
                    threads = 24;
                    break;
                case 8:
                    threadsCountLabel.Text = "32";
                    threads = 32;
                    break;
                case 9:
                    threadsCountLabel.Text = "48";
                    threads = 48;
                    break;
                case 10:
                    threadsCountLabel.Text = "64";
                    threads = 64;
                    break;

            }
        }

        private void threadsSlderSetValue(int val)
        {
            threadsCountLabel.Text = val.ToString();
            switch (val)
            {
                case 1:
                    threadsSlider.Value = 0;
                    break;
                case 2:
                    threadsSlider.Value = 1;
                    break;
                case 4:
                    threadsSlider.Value = 2; 
                    break;
                case 6:
                    threadsSlider.Value = 3; 
                    break;
                case 8:
                    threadsSlider.Value = 4; 
                    break;
                case 12:
                    threadsSlider.Value = 5; 
                    break;
                case 16:
                    threadsSlider.Value = 6; 
                    break;
                case 24:
                    threadsSlider.Value = 7; 
                    break;
                case 32:
                    threadsSlider.Value = 8; 
                    break;
                case 48:
                    threadsSlider.Value = 9; 
                    break;
                case 64:
                    threadsSlider.Value = 10;
                    break;

            }
        }

    }
}
