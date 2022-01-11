﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ja_projekt
{
    internal static class Program
    {
        [DllImport(@"jaLibASM.dll")]
        public static extern unsafe int calculateLuhnValueASM(byte* ptr);
        [DllImport(@"jaLibC.dll")]
        public static extern unsafe int calculateLuhnValueC(byte* ptr);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
