using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_NFC_CP
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            frmPC_NFC_CP ofrmPC_NFC_CP = new frmPC_NFC_CP();
            System.Windows.Forms.Application.Run();
        }
    }
}
