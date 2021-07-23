using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dialogos
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            Dialogo oDialogo = new Dialogo();
            System.Windows.Forms.Application.Run();
        }
    }
}
