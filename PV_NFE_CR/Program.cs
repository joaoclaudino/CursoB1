using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV_NFE_CR
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            frmPV_NFE_CR ofrmPV_NFE_CR = new frmPV_NFE_CR();
            System.Windows.Forms.Application.Run();
        }
    }
}
