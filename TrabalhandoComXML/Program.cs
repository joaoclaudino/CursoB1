using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhandoComXML
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WorkingWithXML oWorkingWithXML = null;
            oWorkingWithXML = new WorkingWithXML();
        }
    }
}
