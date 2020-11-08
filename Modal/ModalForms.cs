using HelperB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal
{
    public class ModalForms
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Button oButtonOK;
        private SAPbouiCOM.StaticText oStaticTextMeuStatic;

        private bool bModal;

        public ModalForms()
        {
            AppHelper.SetApplication(ref oApplication);
            CreateModalForm();

            oApplication.ItemEvent += OApplication_ItemEvent;
            oApplication.MenuEvent += OApplication_MenuEvent;
        }

        private void OApplication_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (bModal)
            {
                BubbleEvent = false;
            }
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

        public void CreateModalForm()
        {
            SAPbouiCOM.FormCreationParams cp = null;
            cp = ((SAPbouiCOM.FormCreationParams)(oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams)));

            cp.BorderStyle = SAPbouiCOM.BoFormBorderStyle.fbs_Fixed;
            cp.FormType = "Modal1";
            cp.UniqueID = "Modal1";

            oForm = oApplication.Forms.AddEx(cp);
            oForm.ClientHeight = 170;
            oForm.ClientWidth = 150;
            oForm.AutoManaged = true;
            oForm.SupportedModes = 0;

            this.oButtonOK = UIHelper.AddBotaoAoFormulario(this.oForm, "1", 10, 0, 100, 0, "Ok",false);

            this.oStaticTextMeuStatic = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "st01", 0, 160, 0, 0, "Eu Sou um Formulário Modal!!");

            this.oForm.Visible = true;

            this.bModal = true;

        }
    }
}
