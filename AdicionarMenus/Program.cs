using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdicionarMenus
{
    static class Program//
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AddMenus oAddMenus = null;
            oAddMenus = new AddMenus();

            System.Windows.Forms.Application.Run();

        }
    }
}
