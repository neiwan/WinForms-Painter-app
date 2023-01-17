using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Panel panel1 = new Panel();
            DrawSystem DS = new DrawSystem(panel1.CreateGraphics());
            Model model = new Model(DS);
            Application.Run(new Form1(model));
        }
    }
}
