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
        int lib = 0;
        string text;
        [DllImport(@"C:\Users\noob7\Documents\repo\ja_projekt\ja_projekt\x64\Debug\jaLibASM.dll")]
        public static extern unsafe int calculateLuhnValue(byte* ptr);
        public Form1()
        {
            
            InitializeComponent();

        }

        private void libC_CheckedChanged(object sender, EventArgs e)
        {
            lib = 0;
        }

        private void libAsm_CheckedChanged(object sender, EventArgs e)
        {
            lib = 1;
        }

        private unsafe void button1_Click(object sender, EventArgs e)
        {
            string text = "1234";
            byte[] str = Encoding.ASCII.GetBytes(text);
            fixed(byte* ptr = &str[0])
            {
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Title = "Choose file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "CSV files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(openFileDialog1.FileName);
            }
        }
    }
}
