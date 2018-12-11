using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;


namespace MasterChef3
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            MainController.adding();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            settings param = new settings();
            Application.Run(param);
        }
    }
}
