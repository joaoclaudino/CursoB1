using HelperB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseFromList
{
    public class ChooseFromList
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;


        private SAPbouiCOM.EditText oEditTxt = null;
        private SAPbouiCOM.EditText oEditTxtN = null;
        private SAPbouiCOM.StaticText oStaticTxt = null;
        private SAPbouiCOM.StaticText oStaticExplain = null;
        private SAPbouiCOM.StaticText oStaticExplain1 = null;
        private SAPbouiCOM.StaticText oStaticExplain2 = null;
        private SAPbouiCOM.StaticText oStaticExplain3 = null;
        private SAPbouiCOM.StaticText oStaticExplain4 = null;
        private SAPbouiCOM.Button oButton = null;


        public ChooseFromList()
        {
            AppHelper.SetApplication(ref this.oApplication);

            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Fixed, "CFL1", "CFL1", 150, 350, true, 0,"Exemplo de Choose From List");

            UserDataSourceHelper.AddUserDataSource(this.oForm,"EditDS",SAPbouiCOM.BoDataType.dt_SHORT_TEXT,254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "EditDSN", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);

            AddChooseFromList();

            this.oEditTxt = UIHelper.AdcionarEditTextAoFormulario(this.oForm, "EditTxt", 120, 0, 90, 0, "StaticTxt", false, 0, 0);
            this.oEditTxtN = UIHelper.AdcionarEditTextAoFormulario(this.oForm, "EditTxtN", 120, 0, 105, 0, "EditTxt", false, 0, 0);
            this.oStaticTxt = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "StaticTxt", 10, 0, 90, 0, "Cliente");

            this.oStaticExplain = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Explain", 10, 200, 10, 0, "São dois Choose From List Aqui no Formulário!!");
            this.oStaticExplain1 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Explain1", 10, 300, 25, 0, "Um deles é ativado pressionando TAB no Edit Text...");
            this.oStaticExplain2 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Explain2", 10, 300, 40, 0, "Somente é mostrado quando o Parceiro de Negócios é Cliente...");
            this.oStaticExplain3 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Explain3", 10, 300, 55, 0, "O Outro Choose From List é ativado pelo Botão...");
            this.oStaticExplain4 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Explain4", 10, 300, 70, 0, "Mostra Todos os Parceiros de Negocios...");

            string sImagem = System.Windows.Forms.Application.StartupPath + @"\CFL.BMP"; ;
            this.oButton = UIHelper.AddBotaoImagemAoFormulario(this.oForm, "Button", 199, 20, 88, 20, sImagem);

            this.oEditTxt.DataBind.SetBound(true, "", "EditDS");
            this.oEditTxtN.DataBind.SetBound(true, "", "EditDSN");


            this.oEditTxt.ChooseFromListUID = "CFL1";
            this.oButton.ChooseFromListUID = "CFL2";


            this.oApplication.ItemEvent += OApplication_ItemEvent;

            this.oForm.Visible = true;
        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST /*& pVal.FormType.Equals("CFL1")*/ )
            {
                SAPbouiCOM.IChooseFromListEvent oCFLEvento = null;
                oCFLEvento = ((SAPbouiCOM.IChooseFromListEvent)(pVal));
                string sCFL_ID = null;
                sCFL_ID = oCFLEvento.ChooseFromListUID;

                SAPbouiCOM.ChooseFromList oCFL = null;
                oCFL = oForm.ChooseFromLists.Item(sCFL_ID);
                if (oCFLEvento.BeforeAction == false)
                {
                    SAPbouiCOM.DataTable oDataTable = null;
                    oDataTable = oCFLEvento.SelectedObjects;

                    string val = null;
                    string valN = null;

                    try
                    {
                        val = System.Convert.ToString(oDataTable.GetValue(0,0));
                        valN = System.Convert.ToString(oDataTable.GetValue(1, 0));
                    }
                    catch 
                    {

                    }
                    if (pVal.ItemUID.Equals("EditTxt") | (pVal.ItemUID.Equals("Button")) )
                    {
                        oForm.DataSources.UserDataSources.Item("EditDS").ValueEx = val;
                        oForm.DataSources.UserDataSources.Item("EditDSN").ValueEx = valN;
                    }

                }
            }
            if ((FormUID == "CFL1") & (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD))
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void AddChooseFromList()
        {
            SAPbouiCOM.ChooseFromListCollection oCFLs = null;
            SAPbouiCOM.Conditions oCons = null;
            SAPbouiCOM.Condition oCon = null;

            oCFLs = oForm.ChooseFromLists;

            SAPbouiCOM.ChooseFromList oCFL = null;

            SAPbouiCOM.ChooseFromListCreationParams oCFLCreationParams = null;
            oCFLCreationParams = ((SAPbouiCOM.ChooseFromListCreationParams)(oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams)));

            oCFLCreationParams.MultiSelection = false;
            oCFLCreationParams.ObjectType = "2";
            oCFLCreationParams.UniqueID = "CFL1";

            oCFL = oCFLs.Add(oCFLCreationParams);

            oCons = oCFL.GetConditions();
            
            oCon = oCons.Add();
            oCon.Alias = "CardType";
            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            oCon.CondVal = "C";

            oCFL.SetConditions(oCons);

            oCFLCreationParams.MultiSelection = false;
            oCFLCreationParams.ObjectType = "2";
            oCFLCreationParams.UniqueID = "CFL2";
            oCFL = oCFLs.Add(oCFLCreationParams);

        }


    }
}
