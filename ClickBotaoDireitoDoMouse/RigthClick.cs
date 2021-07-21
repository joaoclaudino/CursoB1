using HelperB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickBotaoDireitoDoMouse
{
    public class RigthClick
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;

        //private SAPbouiCOM.Item oItem;
        private SAPbouiCOM.StaticText oExpTxt1;
        private SAPbouiCOM.StaticText oExpTxt2;
        private SAPbouiCOM.StaticText oExpTxt3;
        private SAPbouiCOM.StaticText oExpTxt4;

        private SAPbouiCOM.EditText oEditTxt;
        //private SAPbouiCOM.Button oBtnCol;


        public RigthClick()
        {
            AppHelper.SetApplication(ref this.oApplication);
            AddMenu();

            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Sizable, "RClick", "RClick", 0, 0, true, 0, "Exemplo de Click no Botão Direito", 150, 400, 0, 0);

            this.oEditTxt = UIHelper.AdcionarEditTextAoFormulario(this.oForm, "EditTxt", 170, 0, 90, 0, "", false, 0, 0);
            this.oExpTxt1 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "ExpTxt1", 10, 350, 90, 0, "Click Direito No Text Box", "EditTxt");
            this.oExpTxt2 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "ExpTxt2", 10, 350, 35, 0, "Click Direito No Text Box, 2 menus adicionar irão aparecer..", "EditTxt");
            this.oExpTxt3 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "ExpTxt3", 10, 350, 50, 0, "No Menu de dados e no Botão direito sempre aparecem no menus Dados..", "EditTxt");
            this.oExpTxt4 = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "ExpTxt4", 10, 350, 65, 0, "Somente com o Botão direito sobre a caixa de teste é que o menu aparece sobre a caxa de Texto..", "EditTxt");

            oApplication.MenuEvent += OApplication_MenuEvent;
            oApplication.ItemEvent += OApplication_ItemEvent;
            oApplication.RightClickEvent += OApplication_RightClickEvent;

            this.oForm.Visible = true;
        }

        private void OApplication_RightClickEvent(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (eventInfo.FormUID.Equals("RClick"))
            {
                if (eventInfo.BeforeAction)
                {
                    try
                    {
                        SAPbouiCOM.MenuItem oMenuItem;
                        SAPbouiCOM.Menus oMenus;
                        SAPbouiCOM.MenuCreationParams oCreateParams = null;
                        oCreateParams = (SAPbouiCOM.MenuCreationParams)oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams);

                        oCreateParams.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                        oCreateParams.UniqueID = "OnlyOnRc";
                        oCreateParams.String = "Somente com Click Direito";
                        oCreateParams.Enabled = true;

                        oMenuItem = oApplication.Menus.Item("1280");
                        oMenus = oMenuItem.SubMenus;
                        oMenus.AddEx(oCreateParams);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //if (pVal.FormType!=0)
            //{
            //    if ((pVal.EventType!=SAPbouiCOM.BoEventTypes.et_FORM_ACTIVATE) & (pVal.EventType!=SAPbouiCOM.BoEventTypes.et_FORM_LOAD) )
            //    {

            //    }
            //}
        }

        private void OApplication_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.BeforeAction)
            {
                oApplication.SetStatusBarMessage("Menu Item: "+pVal.MenuUID+" Enviou o envento ANTES do SAp B1 processa-lo!!",
                    SAPbouiCOM.BoMessageTime.bmt_Long,true);
            }
            else
            {
                oApplication.SetStatusBarMessage("Menu Item: " + pVal.MenuUID + " Enviou o envento DEPOIS do SAp B1 processa-lo!!",
                    SAPbouiCOM.BoMessageTime.bmt_Long, true);
            }
        }

        private void AddMenu()
        {
            SAPbouiCOM.MenuItem oMenuItem;
            SAPbouiCOM.Menus oMenus;
            try
            {
                SAPbouiCOM.MenuCreationParams oCreateParams = null;
                oCreateParams = (SAPbouiCOM.MenuCreationParams)oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams);

                oCreateParams.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
                oCreateParams.UniqueID = "SA";
                oCreateParams.String = "Sempre Aparece";
                oCreateParams.Enabled = true;

                oMenuItem = oApplication.Menus.Item("1280");
                oMenus = oMenuItem.SubMenus;
                oMenus.AddEx(oCreateParams);

                oCreateParams.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreateParams.UniqueID = "SAP";
                oCreateParams.String = "No Menu Dados e no Click Direito";
                oCreateParams.Enabled = true;

                oMenuItem = oApplication.Menus.Item("SA");
                oMenus = oMenuItem.SubMenus;
                oMenus.AddEx(oCreateParams);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
