using SAPbouiCOM;
using System;

namespace EventFilter
{
    public class OBJEventFilters
    {
        private SAPbouiCOM.Application oApplication;

        private SAPbouiCOM.EventFilters oEventFilters;
        private SAPbouiCOM.EventFilter oEventFilter;
        //private SAPbouiCOM.Form oForm;
        //private SAPbouiCOM.Item oItem;

        private void SetApplication()
        {
            SAPbouiCOM.SboGuiApi oSboGuiApi = null;
            string sConnectionString = null;
            oSboGuiApi = new SAPbouiCOM.SboGuiApi();
            sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));

            try
            {
                oSboGuiApi.Connect(sConnectionString);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }
            oApplication = oSboGuiApi.GetApplication(-1);
            oApplication.SetStatusBarMessage(string.Format("Addon {0} Conectado Com sucesso!!!",
                            System.Windows.Forms.Application.ProductName),
                            BoMessageTime.bmt_Medium
                            , false);
        }
        public OBJEventFilters()
        {
            SetApplication();
            SetFilters();

            oApplication.AppEvent += OApplication_AppEvent;
            oApplication.MenuEvent += OApplication_MenuEvent;
            oApplication.ItemEvent += OApplication_ItemEvent;
        }

        private void OApplication_ItemEvent(string FormUID, ref ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.FormType != 0 & pVal.Before_Action == true)
            {
                switch (pVal.EventType)
                {
                    case SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED:
                        oApplication.MessageBox("O Evento et_ITEM_PRESSED foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_KEY_DOWN:
                        oApplication.MessageBox("O Evento et_KEY_DOWN foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_GOT_FOCUS:
                        oApplication.MessageBox("O Evento et_GOT_FOCUS foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_LOST_FOCUS:
                        oApplication.MessageBox("O Evento et_LOST_FOCUS foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_COMBO_SELECT:
                        oApplication.MessageBox("O Evento et_COMBO_SELECT foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_CLICK:
                        oApplication.MessageBox("O Evento et_CLICK foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_DOUBLE_CLICK:
                        oApplication.MessageBox("O Evento et_DOUBLE_CLICK foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_MATRIX_LINK_PRESSED:
                        oApplication.MessageBox("An et_MATRIX_LINK_PRESSED foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_MATRIX_COLLAPSE_PRESSED:
                        oApplication.MessageBox("O Evento et_MATRIX_COLLAPSE_PRESSED foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_VALIDATE:
                        oApplication.MessageBox("O Evento et_VALIDATE foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_FORM_LOAD:
                        oApplication.MessageBox("O Evento et_FORM_LOAD foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD:
                        oApplication.MessageBox("An et_FORM_UNLOAD foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_FORM_ACTIVATE:
                        break;
                    case SAPbouiCOM.BoEventTypes.et_FORM_DEACTIVATE:
                        break;
                    case SAPbouiCOM.BoEventTypes.et_FORM_CLOSE:
                        oApplication.MessageBox("O Evento et_FORM_CLOSE foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_FORM_RESIZE:
                        oApplication.MessageBox("O Evento et_FORM_RESIZE foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                    case SAPbouiCOM.BoEventTypes.et_FORM_KEY_DOWN:
                        oApplication.MessageBox("O Evento et_FORM_KEY_DOWN foi enviado pelo formulário com unique ID: " + FormUID, 1, "Ok", "", "");
                        break;
                }
            }
        }

        private void OApplication_MenuEvent(ref MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.BeforeAction)
            {
                oApplication.SetStatusBarMessage("Menu Item: " + pVal.MenuUID + ", Antes", SAPbouiCOM.BoMessageTime.bmt_Long, true);
            }
            else
            {
                oApplication.SetStatusBarMessage("Menu Item: " + pVal.MenuUID + ", Depois", SAPbouiCOM.BoMessageTime.bmt_Long, true);
            }
        }

        private void OApplication_AppEvent(BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    oApplication.MessageBox("A Empresa Foi Trocada!!!");
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    oApplication.MessageBox("O Evento ShutDown foi chamado!!"
                                            + Environment.NewLine
                                            + "Fechando o Addon..."
                        , 1, "OK", "", "");
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    oApplication.MessageBox("O Idioma Foi Modificado!!!");
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    oApplication.MessageBox("A Fonte Foi Modificada!!!");
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    oApplication.MessageBox("O Servidor Caiu!!!");
                    System.Windows.Forms.Application.Exit();
                    break;
            }
        }

        private void SetFilters()
        {
            oEventFilters = new EventFilters();

            oEventFilter = oEventFilters.Add(BoEventTypes.et_CLICK);
            oEventFilter.AddEx("139");//pedido de venda
            oEventFilter.AddEx("142");//pedido de compra

            oEventFilter = oEventFilters.Add(BoEventTypes.et_KEY_DOWN);
            oEventFilter.AddEx("139");
            
            oEventFilter = oEventFilters.Add(BoEventTypes.et_ITEM_PRESSED);
            oEventFilter.AddEx("133");

            oApplication.SetFilter(oEventFilters);
        }
    }
}
