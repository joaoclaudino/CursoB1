using HelperB1;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemForms
{
    public class frmPedidoDeVenda
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oFormPV;
        private SAPbouiCOM.Item oNewItem;
        private SAPbouiCOM.Item oItem;
        private SAPbouiCOM.Folder oFolderItem;
        private SAPbouiCOM.CheckBox oCheckBox;
        private SAPbouiCOM.OptionBtn oOptionBtn;
        public frmPedidoDeVenda()
        {
            AppHelper.SetApplication(ref oApplication);

            oApplication.ItemEvent += OApplication_ItemEvent;
            oApplication.AppEvent += OApplication_AppEvent;
        }

        private void OApplication_AppEvent(BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    oApplication.MessageBox("O Evento ShutDown foi chamado!!"
                                            + Environment.NewLine
                                            + "Fechando o Addon..."
                        , 1, "OK", "", "");
                    System.Windows.Forms.Application.Exit();
                    break;
            }
        }

        private void OApplication_ItemEvent(string FormUID, ref ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (
                    (pVal.FormType==139)
                    & pVal.EventType!=BoEventTypes.et_FORM_UNLOAD
                    & pVal.BeforeAction
                )
            {
                this.oFormPV = oApplication.Forms.GetFormByTypeAndCount( pVal.FormType,pVal.FormTypeCount );
                if (pVal.EventType==BoEventTypes.et_FORM_LOAD & pVal.BeforeAction)
                {
                    oNewItem = this.oFormPV.Items.Add("UserFolder",BoFormItemTypes.it_FOLDER);

                    oItem = this.oFormPV.Items.Item("138");

                    oNewItem.Top = oItem.Top;
                    oNewItem.Height = oItem.Height;
                    oNewItem.Width = oItem.Width;
                    oNewItem.Left = oItem.Left;

                    oFolderItem = (SAPbouiCOM.Folder)oNewItem.Specific;
                    oFolderItem.Caption = "User Folder";
                    oFolderItem.GroupWith("138");

                    AddItemsToPVForm();

                    this.oFormPV.PaneLevel = 1;

                }

                if (
                    pVal.ItemUID.Equals("UserFolder")
                    & pVal.EventType==BoEventTypes.et_ITEM_PRESSED
                    & pVal.BeforeAction
                    )
                {
                    this.oFormPV.PaneLevel = 5;

                }
            }
        }

        private void AddItemsToPVForm()
        {
            UserDataSourceHelper.AddUserDataSource(this.oFormPV, "OptBtnDS", BoDataType.dt_SHORT_TEXT, 1);
            UserDataSourceHelper.AddUserDataSource(this.oFormPV, "CheckDS1", BoDataType.dt_SHORT_TEXT, 1);
            UserDataSourceHelper.AddUserDataSource(this.oFormPV, "CheckDS2", BoDataType.dt_SHORT_TEXT, 1);
            UserDataSourceHelper.AddUserDataSource(this.oFormPV, "CheckDS3", BoDataType.dt_SHORT_TEXT, 1);

            //adcionar check box ao Folder
            this.oItem = this.oFormPV.Items.Item("126");

            for (int i = 1; i <= 3; i++)
            {
                this.oCheckBox = UIHelper.AddCheckBoxAoFormulario(
                    this.oFormPV
                    , "CheckBox" + i.ToString()
                    , oItem.Left
                    , 100
                    , this.oItem.Top + (i - 1) * 19
                    , 19
                    , "Check Box " + i.ToString()
                    , true
                    , 5
                    , 5

                    );
                this.oCheckBox.DataBind.SetBound(true,"", "CheckDS" + i.ToString());
            }

            this.oItem = this.oFormPV.Items.Item("44");
            for (int i = 1; i <= 3; i++)
            {
                //this.oNewItem = this.oFormPV.Items.Add("OptBtn" + i.ToString(), BoFormItemTypes.it_OPTION_BUTTON);
                //this.oNewItem.Left = oItem.Left;
                //this.oNewItem.Width = 100;
                //this.oNewItem.Top = this.oItem.Top + (i - 1) * 19;
                //this.oNewItem.Height = 19;

                //this.oNewItem.FromPane = 5;
                //this.oNewItem.ToPane = 5;

                //this.oOptionBtn = (SAPbouiCOM.OptionBtn)oNewItem.Specific;
                //this.oOptionBtn.Caption = "Option Button " + i.ToString();

                //if (i>1)
                //{
                //    oOptionBtn.GroupWith("OptBtn" + Convert.ToString(i - 1));
                //}
                this.oOptionBtn= UIHelper.AddOptionButtonAoFormulario(
                    this.oFormPV
                    , "OptBtn" + i.ToString()
                    , oItem.Left
                    , 100
                    , this.oItem.Top + (i - 1) * 19
                    , 19
                    , "Option Button " + i.ToString()
                    , (i > 1) ? "OptBtn" + Convert.ToString(i - 1) : ""
                    , true
                    , 5
                    , 5                    
                    );
                this.oOptionBtn.DataBind.SetBound(true, "", "OptBtnDS");
            }
        }
    }
}
