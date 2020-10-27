using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PegarEventos
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PegarEventos oPegarEventos = null;
            oPegarEventos = new PegarEventos();
            System.Windows.Forms.Application.Run();
        }
    }
}
