﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin login = new FrmLogin();
            Application.Run(login);
            {
                if (userInfo.userName != "")
                {
                    Application.Run(new FormMain());
                }
                else
                {
                    Application.Exit();
                }

            }
        }
    }
}
