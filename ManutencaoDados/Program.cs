using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManutencaoDados
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            frmManutenaoDeDados ofrmManutenaoDeDados = new frmManutenaoDeDados();
            System.Windows.Forms.Application.Run();
        }
    }
}
