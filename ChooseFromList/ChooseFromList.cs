using HelperB1;
using SAPbouiCOM;
using System.Windows.Forms; 
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
            this.oForm = UIHelper.AddForm(this.oApplication, "CFL1", "CFL1",SAPbouiCOM.BoFormBorderStyle.fbs_Sizable,"Exemplo de Choose From List",350,150);

            UserDataSourceHelper.AddUserDataSource(this.oForm, "EditDS", BoDataType.dt_SHORT_TEXT, 254);

            AddChooseFromList();

            this.oEditTxt = UIHelper.AdcionarEditTextAoFormulario(this.oForm, "EditTxt", 120, 0, 90, 0, false, 0, 0, "StaticTxt");

            this.oStaticTxt = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "StaticTxt", 10, 0, 90, 0, "Cliente", "EditTxt");

            this.oStaticExplain = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Explain", 10, 200, 10, 0, "São dois Choose From List Aqui!!");

            this.oStaticExplain1 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Explain1", 10, 300, 25, 0, "Um deles é ativado pressionando TAB no Edit Text...");

            this.oStaticExplain2 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Explain2", 10, 300, 40, 0, "Somente é mostrado quando o Parceiro de Negócios Cliente...");

            this.oStaticExplain3 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Explain3", 10, 300, 55, 0, "O Outro Choose From List é ativado pelo Botão...");

            this.oStaticExplain4 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Explain4", 10, 300, 70, 0, "Mostra Todos os Parceiros de Negocios...");

            string sImagem= System.Windows.Forms.Application.StartupPath + @"\CFL.BMP"; ;
            this.oButton = UIHelper.AddBotaoImagemAoFormulario(this.oForm, "Button", 199, 20, 88, 20, sImagem);

            this.oEditTxt.DataBind.SetBound(true, "", "EditDS");
            this.oEditTxt.ChooseFromListUID = "CFL1";
            this.oButton.ChooseFromListUID = "CFL2";

            this.oForm.Visible = true1,2,3,4

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
