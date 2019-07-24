using System;
using System.Windows.Forms;

namespace PomidoroNet
{
    /***
     * ICO FROM https://icon-icons.com/icon/vegetables-tomato-food/1313 by License CC Atribution(https://creativecommons.org/licenses/by/4.0/)
     */
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
            Application.Run(new PomidoroMainForm());
        }
    }
}
