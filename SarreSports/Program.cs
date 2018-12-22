//Project Name: SarreSports | File Name: Program.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 3/12/2018 | 21:01
//Last Updated On:  20/12/2018 | 14:44
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarreSports
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
            Application.Run(new loginForm());
        }
    }
}
