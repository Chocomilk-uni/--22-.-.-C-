﻿using System;
using System.Windows.Forms;

namespace LabWork1_V9_WindowsFormsBuses
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBus());
        }
    }
}