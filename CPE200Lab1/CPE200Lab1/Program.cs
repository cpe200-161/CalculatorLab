using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
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
            Application.Run(new ExtendForm());
            //Application.Run(new MainForm());
            //Call by path absolute
            //System.Collections.Stack testStack = new System.Collections.Stack();
            //Call by Reference

        }
    }
}
