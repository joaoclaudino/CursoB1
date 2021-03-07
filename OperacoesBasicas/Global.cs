using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacoesBasicas
{
    public static class Global
    {
        public static SAPbobsCOM.Company oCompany;
        public static string sMsgErro = string.Empty;
        public static int iErrorCode = 0;
        public static int iRetCode;


        public static SAPbobsCOM.Items oItems;
        public static SAPbobsCOM.Documents oInvGenEntry;
        public static SAPbobsCOM.Documents oInvGenSaida;

        public static void Iniciar()
        {
            Global.oCompany = new SAPbobsCOM.Company();
            Global.oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Portuguese_Br;

        }

    }
}
