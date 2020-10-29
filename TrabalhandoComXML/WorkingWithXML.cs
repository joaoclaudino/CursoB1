//using SAPbouiCOM;
using System;
using System.Windows.Forms;


namespace TrabalhandoComXML
{
    public class WorkingWithXML
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
        private void SetApplication()
        {
            SAPbouiCOM.SboGuiApi oSboGuiApi = null;
            string sConnectionString = null;
            oSboGuiApi = new SAPbouiCOM.SboGuiApi();
            sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));
            oSboGuiApi.Connect(sConnectionString);
            oApplication = oSboGuiApi.GetApplication(-1);
        }

        private void LoadFromXML (ref string pFileNAme)
        {
            System.Xml.XmlDocument oXmlDoc = null;

            oXmlDoc = new System.Xml.XmlDocument();

            string sPath = null;

            sPath = System.IO.Directory.GetParent(Application.StartupPath).ToString();
            sPath = System.IO.Directory.GetParent(sPath).ToString();

            //E:\CursoB1Source\CursoB1\TrabalhandoComXML\bin\FormSimples.xml
            oXmlDoc.Load(sPath + "\\" + pFileNAme);

            string sXML = oXmlDoc.InnerXml.ToString();

            oApplication.LoadBatchActions(ref sXML);
        }
        private void SaveAsXML(ref SAPbouiCOM.Form pForm )
        {
            System.Xml.XmlDocument oXmlDoc = null;
            oXmlDoc = new System.Xml.XmlDocument();

            string sXmlString = null;

            sXmlString = pForm.GetAsXML();

            oXmlDoc.LoadXml(sXmlString);

            string sPath = null;
            sPath = System.IO.Directory.GetParent(Application.StartupPath).ToString();

            oXmlDoc.Save(sPath + @"\FormSimples_1.xml");

            //oApplication.SetStatusBarMessage("Dir: " + sPath, SAPbouiCOM.BoMessageTime.bmt_Short, false);
        }
        public WorkingWithXML()
        {
            SetApplication();

            string sXMLFormNAme = "FormSimples.xml";
            LoadFromXML(ref sXMLFormNAme);

            oForm = oApplication.Forms.Item("MeuFormSimples");

            oForm.Visible = true;

            SaveAsXML(ref oForm);
        }
    }
}
