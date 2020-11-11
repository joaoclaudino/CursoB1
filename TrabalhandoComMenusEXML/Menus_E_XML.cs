using HelperB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhandoComMenusEXML
{
    public class Menus_E_XML
    {
        private SAPbouiCOM.Application oApplication;

        public Menus_E_XML()
        {
            AppHelper.SetApplication(ref oApplication);

            string strTemp = "MeusMenus.xml";
            this.LoadFromXML(strTemp);
        }
        private void LoadFromXML(string FileName)
        {
            System.Xml.XmlDocument oXmlDoc = null;
            oXmlDoc = new System.Xml.XmlDocument();

            string sPath = null;
            sPath = Application.StartupPath;

            oXmlDoc.Load(sPath + @"\" + FileName);

            string tmpStr;

            tmpStr = oXmlDoc.InnerXml;

            oApplication.LoadBatchActions(ref tmpStr);

            sPath = oApplication.GetLastBatchResults();

        }
    }
}
