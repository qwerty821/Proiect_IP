using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Objects.Changes;

namespace Proiect_IP
{
    internal static class Program
    {
 

       /// <summary>
       /// The main entry point for the application.
       /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // comentariu GIT
            Application.Run(new Form1());
        }
    }
}
