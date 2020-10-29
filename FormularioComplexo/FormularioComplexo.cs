using SAPbouiCOM;
using System;

namespace FormularioComplexo
{
    public class FormularioComplexo
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Item oItem;

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
        private void CriarFormularioComplexo()
        {
            SAPbouiCOM.Button oButton = null;
            SAPbouiCOM.Folder oFolder = null;
            SAPbouiCOM.OptionBtn oOptionBtn = null;
            SAPbouiCOM.CheckBox oCheckBox = null;
            SAPbouiCOM.ComboBox oComboBox = null;


            SAPbouiCOM.FormCreationParams oCreationParams = null;
            oCreationParams = ((SAPbouiCOM.FormCreationParams)(oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams)));

            oCreationParams.UniqueID = "frmComplex";
            oCreationParams.FormType = "frmComplex";
            oCreationParams.BorderStyle = BoFormBorderStyle.fbs_Sizable;

            oForm = oApplication.Forms.AddEx(oCreationParams);

            AddDataSourceNoForm();


            oForm.Title = "Formulário Complexo";
            oForm.Left = 300;
            oForm.ClientWidth = 200;
            oForm.Top = 100;
            oForm.ClientHeight = 140;

            oItem = oForm.Items.Add("1", BoFormItemTypes.it_BUTTON);
            oItem.Left = 5;
            oItem.Width = 65;
            oItem.Top = 110;
            oItem.Height = 19;
            oButton = ((SAPbouiCOM.Button)(oItem.Specific));
            oButton.Caption = "Ok";

            oItem = oForm.Items.Add("2", BoFormItemTypes.it_BUTTON);
            oItem.Left = 75;
            oItem.Width = 65;
            oItem.Top = 110;
            oItem.Height = 19;
            oButton = ((SAPbouiCOM.Button)(oItem.Specific));
            oButton.Caption = "Cancel";


            oItem = oForm.Items.Add("Rect1",BoFormItemTypes.it_RECTANGLE);
            oItem.Left = 0;
            oItem.Width = 194;
            oItem.Top = 25;
            oItem.Height = 80;

            for (int i = 1; i <= 3; i++)
            {
                oItem = oForm.Items.Add("Folder" + i.ToString(), BoFormItemTypes.it_FOLDER);
                oItem.Left = (i-1)*100;
                oItem.Width = 100;
                oItem.Top = 6;
                oItem.Height = 19;

                oFolder= ((SAPbouiCOM.Folder)(oItem.Specific));

                oFolder.Caption = "Folder " + i.ToString();
                oFolder.DataBind.SetBound(true,"", "FolderDS");
                if (i==1)
                {
                    oFolder.Select();
                }
                else
                {
                    oFolder.GroupWith("Folder"+ Convert.ToString(i-1));
                }
            }

            for (int i = 1; i <= 3; i++)
            {
                oItem = oForm.Items.Add("OptBtn" + i.ToString(), BoFormItemTypes.it_OPTION_BUTTON);
                oItem.Left = 20;
                oItem.Width = 120;
                oItem.Top = 30 + (i-1)*19;
                oItem.Height = 19;

                oItem.FromPane = 1;
                oItem.ToPane = 1;

                oOptionBtn = ((SAPbouiCOM.OptionBtn)(oItem.Specific));
                oOptionBtn.Caption = string.Format("Botão de Opção {0}",i);

                if (i>1)
                {
                    oOptionBtn.GroupWith("OptBtn"+ Convert.ToString(i - 1));
                }

                oOptionBtn.DataBind.SetBound(true,"", "OptBtnDS");
            }

            for (int i = 1; i <= 3; i++)
            {
                oItem = oForm.Items.Add("CheckBox" + i.ToString(), BoFormItemTypes.it_CHECK_BOX);

                oItem.Left = 20;
                oItem.Width = 100;
                oItem.Top = 30 + (i - 1) * 19;
                oItem.Height = 19;

                oItem.FromPane = 2;
                oItem.ToPane = 2;

                oCheckBox = ((SAPbouiCOM.CheckBox)(oItem.Specific));
                oCheckBox.Caption = string.Format("Check Box {0}", i);
                oCheckBox.DataBind.SetBound(true, "", string.Format("CheckDS{0}", i));
            }

            for (int i = 1; i <= 3; i++)
            {
                oItem = oForm.Items.Add("ComboBox" + i.ToString(), BoFormItemTypes.it_COMBO_BOX);

                oItem.Left = 20;
                oItem.Width = 100;
                oItem.Top = 33 + (i - 1) * 19;
                oItem.Height = 19;

                oItem.FromPane = 3;
                oItem.ToPane = 3;

                oComboBox = ((SAPbouiCOM.ComboBox)(oItem.Specific));
                oComboBox.ValidValues.Add("0", "Selecione");
                for (int x = 1; x < 10; x++)
                {
                    oComboBox.ValidValues.Add(x.ToString(),string.Format("Item {0}",x));
                }
                oComboBox.Select("0", BoSearchKey.psk_ByValue);
                oItem.DisplayDesc = true;
                //oComboBox.

                //oCheckBox.Caption = string.Format("Check Box {0}", i);
                //oCheckBox.DataBind.SetBound(true, "", string.Format("CheckDS{0}", i));
            }

            oForm.PaneLevel = 1;
        }
        private void AddDataSourceNoForm()
        {
            oForm.DataSources.UserDataSources.Add("FolderDS", BoDataType.dt_SHORT_TEXT, 1);
            oForm.DataSources.UserDataSources.Add("OptBtnDS", BoDataType.dt_SHORT_TEXT, 1);
            oForm.DataSources.UserDataSources.Add("CheckDS1", BoDataType.dt_SHORT_TEXT, 1);
            oForm.DataSources.UserDataSources.Add("CheckDS2", BoDataType.dt_SHORT_TEXT, 1);
            oForm.DataSources.UserDataSources.Add("CheckDS3", BoDataType.dt_SHORT_TEXT, 1);
        }
        public FormularioComplexo()
        {
            SetApplication();

            CriarFormularioComplexo();

            oForm.Visible = true;


            ((SAPbouiCOM.OptionBtn)(oForm.Items.Item("OptBtn1").Specific)).Selected = true;
            ((SAPbouiCOM.Folder)(oForm.Items.Item("Folder1").Specific)).Select();


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
                                            + string.Format("Fechando o Addon {0}...",
                                            System.Windows.Forms.Application.ProductName)
                        , 1, "OK", "", "");
                    System.Windows.Forms.Application.Exit();
                    break;
            }
        }

        private void ReorganizarItensNaTela()
        {
            //SAPbouiCOM.Button oButton = null;
            //SAPbouiCOM.Folder oFolder = null;
            //SAPbouiCOM.OptionBtn oOptionBtn = null;
            //SAPbouiCOM.CheckBox oCheckBox = null;

            oItem = oForm.Items.Item("1");
            oItem.Top = oForm.Height - 70;

            oItem = oForm.Items.Item("2");
            oItem.Top = oForm.Height - 70;


            oItem = oForm.Items.Item("Rect1");

            oItem.Width = oForm.Width - 20;
            oItem.Height = oForm.Height - 100;

            for (int i = 1; i <= 3; i++)
            {
                oItem = oForm.Items.Item("OptBtn" + i.ToString());
                oItem.Left = 20;
                oItem.Width = 120;
                oItem.Top = 30 + (i - 1) * 19;
                oItem.Height = 19;
            }

            for (int i = 1; i <= 3; i++)
            {
                oItem = oForm.Items.Item("CheckBox" + i.ToString());

                oItem.Left = 20;
                oItem.Width = 100;
                oItem.Top = 30 + (i - 1) * 19;
                oItem.Height = 19;
            }
        }
        private void OApplication_ItemEvent(string FormUID, ref ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (FormUID.Equals("frmComplex"))
            {
                oForm = oApplication.Forms.Item(FormUID);
                switch (pVal.EventType)
                {
                    case BoEventTypes.et_ITEM_PRESSED:
                        if (pVal.ItemUID.Equals("Folder1"))
                        {
                            oForm.PaneLevel = 1;
                        }
                        else if (pVal.ItemUID.Equals("Folder2"))
                        {
                            oForm.PaneLevel = 2;
                        }
                        else if (pVal.ItemUID.Equals("Folder3"))
                        {
                            oForm.PaneLevel = 3;
                        }
                        break;
                    case BoEventTypes.et_FORM_RESIZE:
                        oForm.Freeze(true);
                        ReorganizarItensNaTela();
                        oForm.Freeze(false);
                        oForm.Update();
                        break;
                    case BoEventTypes.et_FORM_CLOSE:
                        System.Windows.Forms.Application.Exit();
                        break;
                }
            }
        }
    }
}
