using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestApp
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
          //  Application.Run(new SkypeAPITest());
            //Application.Run(new ClientInfo("+5216644448592"));
            Application.Run(new SkypeAPITest());
        }
    }
}