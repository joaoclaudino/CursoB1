using HelperB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalForms
{
    public class ModalForm
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Button oButtonOK;
        private SAPbouiCOM.StaticText oStaticTextMeuStatic;

        private bool bModal;

        public ModalForm()
        {
            AppHelper.SetApplication(ref oApplication);

            CreateModalForm();

            oApplication.MenuEvent += OApplication_MenuEvent;
            oApplication.ItemEvent += OApplication_ItemEvent;
        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (bModal & FormUID != "Modal1")
            {
                oForm.Select(); //  Select the modal form
                BubbleEvent = false;
            }
            else if (FormUID == "Modal1" & (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_CLOSE) & bModal)
            {
                bModal = false;
            }
        }

        private void OApplication_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (bModal)
            {
                BubbleEvent = false;
            }
        }

        public void CreateModalForm()
        {
            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Fixed, "Modal1", "Modal1", 170, 150, true, 0,"Formulário Modal");

            this.oButtonOK = UIHelper.AddBotaoAoFormulario(this.oForm, "1", 10, 0, 100, 0, "Ok", false);
            this.oStaticTextMeuStatic = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "st01", 0, 160, 0, 0, "Eu Sou um Formulário Modal!!");


            this.oForm.Visible = true;
            this.bModal = true;

        }
    }
}
