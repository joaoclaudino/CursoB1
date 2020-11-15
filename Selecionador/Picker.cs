using HelperB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selecionador
{
    public class Picker
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;

        private SAPbouiCOM.StaticText oStaticHead = null;

        private SAPbouiCOM.EditText oEditDate = null;
        private SAPbouiCOM.StaticText oStaticDate = null;
        private SAPbouiCOM.EditText oEditPrice = null;
        private SAPbouiCOM.StaticText oStaticPrice = null;
        private SAPbouiCOM.EditText oEditCLF = null;
        private SAPbouiCOM.StaticText oStaticCLF = null;

        public Picker()
        {
            AppHelper.SetApplication(ref this.oApplication);

            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Fixed, "PickerForm", "PickerForm", 150, 350, true, 0, "Exemplo de Selecionador",0,0,100,400);
            this.oForm.Visible = true;

            this.oForm.Freeze(true);

            UserDataSourceHelper.AddUserDataSource(this.oForm, "DateDS", SAPbouiCOM.BoDataType.dt_DATE, 254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "CalcDS", SAPbouiCOM.BoDataType.dt_PRICE, 254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "CLFDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);

            AddChooseFromList();

            this.oStaticHead = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "StaticHead", 7, 350, 8, 44, "São 3 exemplos de Selecionar Informações!!", "EditDate");


            this.oEditDate = UIHelper.AdcionarEditTextAoFormulario(this.oForm, "EditDate", 157, 80, 65, 14, "", false, 0, 0);
            this.oEditDate.DataBind.SetBound(true,"", "DateDS");
            this.oStaticDate = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "StaticDate", 7, 148,65, 14, "Data: ", "EditDate");

            this.oEditPrice = UIHelper.AdcionarEditTextAoFormulario(this.oForm, "EditPrice", 157, 80, 46, 14, "", false, 0, 0);
            this.oEditPrice.DataBind.SetBound(true, "", "CalcDS");
            this.oStaticPrice = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "StPrice", 7, 148, 46, 14, "Preço: ", "EditPrice");

            this.oEditCLF = UIHelper.AdcionarEditTextAoFormulario(this.oForm, "EditCLF", 157, 80, 85, 14, "", false, 0, 0);
            this.oEditCLF.DataBind.SetBound(true, "", "CLFDS");
            this.oEditCLF.ChooseFromListUID = "CFL1";
            this.oStaticCLF = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "StaticCLF", 7, 148, 85, 14, "CLF: ", "EditCLF");

            this.oApplication.ItemEvent += OApplication_ItemEvent;

            this.oForm.Freeze(false);

        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST  )
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
                        val = System.Convert.ToString(oDataTable.GetValue(0, 0));
                        valN = System.Convert.ToString(oDataTable.GetValue(1, 0));
                    }
                    catch
                    {

                    }
                    if (pVal.ItemUID.Equals("EditCLF") )
                    {
                        oForm.DataSources.UserDataSources.Item("CLFDS").ValueEx = val;

                    }

                }
            }
            if ((FormUID == "PickerForm") & (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD))
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


        }
    }
}
