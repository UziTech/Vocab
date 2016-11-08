using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vocab
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

            try
            {

                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error -->\n" + ex.ToString());
            }
        }
    }
}