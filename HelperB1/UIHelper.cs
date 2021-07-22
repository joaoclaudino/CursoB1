using SAPbouiCOM;
using System;
using System.Windows.Forms;

namespace HelperB1
{
    public static class UIHelper
    {
        public static SAPbouiCOM.StaticText AdcionarStaticTextAoFormulario(
            SAPbouiCOM.Form pForm
            , string pUID
            , int pLeft
            , int pWidth
            , int pTop
            , int pHeight
            , string pCaption
            , string pLinkTo = ""
            , bool AffectsFormMode = false
            , int pFromPane = 0
            , int pToPane = 0
            )
        {
            Item oItem = pForm.Items.Add(pUID, BoFormItemTypes.it_STATIC);
            SAPbouiCOM.StaticText oStaticText = null;


            if (pLeft>0)
            {
                oItem.Left = pLeft;
            }
            if (pWidth>0)
            {
                oItem.Width = pWidth;
            }
            if (pTop>0)
            {
                oItem.Top = pTop;
            }
            if (pHeight>0)
            {
                oItem.Height = pHeight;
            }           


            oItem.AffectsFormMode = AffectsFormMode;
            if (pFromPane > 0)
            {
                oItem.FromPane = pFromPane;
            }
            if (pToPane > 0)
            {
                oItem.ToPane = pToPane;
            }
            oItem.LinkTo = pLinkTo;
            oStaticText = ((SAPbouiCOM.StaticText)(oItem.Specific));
            oStaticText.Caption = pCaption;
            return oStaticText;
        }
        public static SAPbouiCOM.EditText AdcionarEditExtendTextAoFormulario(
            SAPbouiCOM.Form pForm
            , string pUID
            , int pLeft
            , int pWidth
            , int pTop
            , int pHeight
            , string pLinkTo
            , bool AffectsFormMode = false
            , int pFromPane = 0
            , int pToPane = 0

            )
        {
            Item oItem = pForm.Items.Add(pUID, BoFormItemTypes.it_EXTEDIT);
            SAPbouiCOM.EditText oEditText = null;
            if (pLeft > 0)
            {
                oItem.Left = pLeft;
            }
            if (pWidth > 0)
            {
                oItem.Width = pWidth;
            }
            if (pTop > 0)
            {
                oItem.Top = pTop;
            }
            if (pHeight > 0)
            {
                oItem.Height = pHeight;
            }
            oItem.AffectsFormMode = AffectsFormMode;
            if (pFromPane > 0)
            {
                oItem.FromPane = pFromPane;
            }
            if (pToPane > 0)
            {
                oItem.ToPane = pToPane;
            }
            if (!string.IsNullOrEmpty(pLinkTo))
            {
                oItem.LinkTo = pLinkTo;
            }

            oEditText = ((SAPbouiCOM.EditText)(oItem.Specific));
            return oEditText;
        }
        public static SAPbouiCOM.EditText AdcionarEditTextAoFormulario(
            SAPbouiCOM.Form pForm
            , string pUID
            , int pLeft
            , int pWidth
            , int pTop
            , int pHeight
            , string pLinkTo
            , bool AffectsFormMode = false
            , int pFromPane = 0
            , int pToPane = 0
            
            )
        {
            Item oItem = pForm.Items.Add(pUID, BoFormItemTypes.it_EDIT);
            SAPbouiCOM.EditText oEditText = null;
            if (pLeft > 0)
            {
                oItem.Left = pLeft;
            }
            if (pWidth > 0)
            {
                oItem.Width = pWidth;
            }
            if (pTop > 0)
            {
                oItem.Top = pTop;
            }
            if (pHeight > 0)
            {
                oItem.Height = pHeight;
            }
            oItem.AffectsFormMode = AffectsFormMode;
            if (pFromPane > 0)
            {
                oItem.FromPane = pFromPane;
            }
            if (pToPane > 0)
            {
                oItem.ToPane = pToPane;
            }
            if (!string.IsNullOrEmpty(pLinkTo))
            {
                oItem.LinkTo = pLinkTo;
            }
            
            oEditText = ((SAPbouiCOM.EditText)(oItem.Specific));
            return oEditText;
        }

        public static SAPbouiCOM.ComboBox AddComboBoxAoFormulario(
            SAPbouiCOM.Form pForm
            , string pUID
            , int pLeft
            , int pWidth
            , int pTop
            , int pHeight
            , bool AffectsFormMode = false
            , int pFromPane = 0
            , int pToPane = 0
            )
        {
            SAPbouiCOM.Item oItem = null;
            SAPbouiCOM.ComboBox oComboBox = null;

            oItem = pForm.Items.Add(pUID, BoFormItemTypes.it_COMBO_BOX);
            if (pLeft > 0)
            {
                oItem.Left = pLeft;
            }
            if (pWidth > 0)
            {
                oItem.Width = pWidth;
            }
            if (pTop > 0)
            {
                oItem.Top = pTop;
            }
            if (pHeight > 0)
            {
                oItem.Height = pHeight;
            }
            oItem.AffectsFormMode = AffectsFormMode;
            if (pFromPane > 0)
            {
                oItem.FromPane = pFromPane;
            }
            if (pToPane > 0)
            {
                oItem.ToPane = pToPane;
            }
            oItem.DisplayDesc = true;
            oComboBox = ((SAPbouiCOM.ComboBox)(oItem.Specific));
            return oComboBox;
        }

        public static Item AddRectAoFormulario(
            SAPbouiCOM.Form pForm
            , string pUID
            , int pLeft
            , int pWidth
            , int pTop
            , int pHeight
            , bool AffectsFormMode = false
            , int pFromPane = 0
            , int pToPane = 0
            )
        {
            Item oItem = pForm.Items.Add(pUID, BoFormItemTypes.it_RECTANGLE);
            if (pLeft > 0)
            {
                oItem.Left = pLeft;
            }
            if (pWidth > 0)
            {
                oItem.Width = pWidth;
            }
            if (pTop > 0)
            {
                oItem.Top = pTop;
            }
            if (pHeight > 0)
            {
                oItem.Height = pHeight;
            }
            oItem.AffectsFormMode = AffectsFormMode;
            if (pFromPane > 0)
            {
                oItem.FromPane = pFromPane;
            }
            if (pToPane > 0)
            {
                oItem.ToPane = pToPane;
            }
            return oItem;
        }

        public static SAPbouiCOM.Button AddBotaoAoFormulario(
            SAPbouiCOM.Form pForm
            , string pUID
            , int pLeft
            , int pWidth
            , int pTop
            , int pHeight
            , string pCaption
            , bool AffectsFormMode = false
            , int pFromPane = 0
            , int pToPane = 0
            )
        {
            SAPbouiCOM.Item oItem = null;
            SAPbouiCOM.Button oButton = null;

            oItem = pForm.Items.Add(pUID, SAPbouiCOM.BoFormItemTypes.it_BUTTON);
            if (pLeft > 0)
            {
                oItem.Left = pLeft;
            }
            if (pWidth > 0)
            {
                oItem.Width = pWidth;
            }
            if (pTop > 0)
            {
                oItem.Top = pTop;
            }
            if (pHeight > 0)
            {
                oItem.Height = pHeight;
            }
            oItem.AffectsFormMode = AffectsFormMode;
            if (pFromPane > 0)
            {
                oItem.FromPane = pFromPane;
            }
            if (pToPane > 0)
            {
                oItem.ToPane = pToPane;
            }

            oButton = ((SAPbouiCOM.Button)(oItem.Specific));
            oButton.Caption = pCaption;

            return oButton;
        }

        public static SAPbouiCOM.Button AddBotaoImagemAoFormulario(
            SAPbouiCOM.Form pForm
            , string pUID
            , int pLeft
            , int pWidth
            , int pTop
            , int pHeight
            , string pImagem
            , bool AffectsFormMode = false
            , int pFromPane = 0
            , int pToPane = 0
            )
        {
            SAPbouiCOM.Item oItem = null;
            SAPbouiCOM.Button oButton = null;

            oItem = pForm.Items.Add(pUID, SAPbouiCOM.BoFormItemTypes.it_BUTTON);
            if (pLeft > 0)
            {
                oItem.Left = pLeft;
            }
            if (pWidth > 0)
            {
                oItem.Width = pWidth;
            }
            if (pTop > 0)
            {
                oItem.Top = pTop;
            }
            if (pHeight > 0)
            {
                oItem.Height = pHeight;
            }
            oItem.AffectsFormMode = AffectsFormMode;
            if (pFromPane > 0)
            {
                oItem.FromPane = pFromPane;
            }
            if (pToPane > 0)
            {
                oItem.ToPane = pToPane;
            }

            oButton = ((SAPbouiCOM.Button)(oItem.Specific));
            oButton.Type = BoButtonTypes.bt_Image;
            oButton.Image = pImagem;
            //oButton.Caption = pCaption;

            return oButton;
        }

        public static SAPbouiCOM.CheckBox AddCheckBoxAoFormulario(
            SAPbouiCOM.Form pForm
            , string pUID
            , int pLeft
            , int pWidth
            , int pTop
            , int pHeight
            , string pCaption
            , bool AffectsFormMode = false
            , int pFromPane = 0
            , int pToPane = 0
            
            )
        {
            SAPbouiCOM.Item oItem = null;
            SAPbouiCOM.CheckBox oCheckBox = null;

            oItem = pForm.Items.Add(pUID, SAPbouiCOM.BoFormItemTypes.it_CHECK_BOX);
            if (pLeft > 0)
            {
                oItem.Left = pLeft;
            }
            if (pWidth > 0)
            {
                oItem.Width = pWidth;
            }
            if (pTop > 0)
            {
                oItem.Top = pTop;
            }
            if (pHeight > 0)
            {
                oItem.Height = pHeight;
            }
            oItem.AffectsFormMode = AffectsFormMode;
            if (pFromPane>0)
            {
                oItem.FromPane = pFromPane;
            }
            if (pToPane>0)
            {
                oItem.ToPane = pToPane;
            }

            oCheckBox = ((SAPbouiCOM.CheckBox)(oItem.Specific));
            oCheckBox.Caption = pCaption;

            return oCheckBox;
        }

        public static SAPbouiCOM.OptionBtn AddOptionButtonAoFormulario(
            SAPbouiCOM.Form pForm
            , string pUID
            , int pLeft
            , int pWidth
            , int pTop
            , int pHeight
            , string pCaption
            , string pGroupWith
            , bool AffectsFormMode = false
            , int pFromPane = 0
            , int pToPane = 0

            )
        {
            SAPbouiCOM.Item oItem = null;
            SAPbouiCOM.OptionBtn oOptionBtn = null;

            oItem = pForm.Items.Add(pUID, SAPbouiCOM.BoFormItemTypes.it_OPTION_BUTTON);
            if (pLeft > 0)
            {
                oItem.Left = pLeft;
            }
            if (pWidth > 0)
            {
                oItem.Width = pWidth;
            }
            if (pTop > 0)
            {
                oItem.Top = pTop;
            }
            if (pHeight > 0)
            {
                oItem.Height = pHeight;
            }
            oItem.AffectsFormMode = AffectsFormMode;
            if (pFromPane > 0)
            {
                oItem.FromPane = pFromPane;
            }
            if (pToPane > 0)
            {
                oItem.ToPane = pToPane;
            }

            oOptionBtn = ((SAPbouiCOM.OptionBtn)(oItem.Specific));
            oOptionBtn.Caption = pCaption;
            if (!string.IsNullOrEmpty(pGroupWith))
            {
                oOptionBtn.GroupWith(pGroupWith);
            }
            return oOptionBtn;
        }

        public static SAPbouiCOM.Form CriarForm(
            SAPbouiCOM.Application oApplication
            , SAPbouiCOM.BoFormBorderStyle pBoFormBorderStyle
            ,string pFormType
            ,string pUniqueID
            ,int pClientHeight
            , int pClientWidth
            ,bool pAutoManaged
            ,int pSupportedModes
            ,string pTitle
            ,int pHeight=0
            ,int pWidth=0
            , int pTop = 0
            , int pLeft = 0
            )
        {
            SAPbouiCOM.Form oForm;

            try
            {
                oForm = oApplication.Forms.Item(pUniqueID);
                oForm.Close();
                oForm = null;
                GC.Collect();                
            }
            catch
            {
            }

            SAPbouiCOM.FormCreationParams cp = null;
            cp = ((SAPbouiCOM.FormCreationParams)(oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams)));


            cp.BorderStyle = pBoFormBorderStyle;
            cp.FormType = pFormType;
            cp.UniqueID = pUniqueID;

            oForm = oApplication.Forms.AddEx(cp);

            if (!string.IsNullOrEmpty(pTitle))
            {
                oForm.Title = pTitle;
            }
            if (pTop > 0)
            {
                oForm.Top = pTop;
            }
            if (pLeft > 0)
            {
                oForm.Left = pLeft;
            }
            if (pClientHeight>0)
            {
                oForm.ClientHeight = pClientHeight;
            }
            if (pClientWidth>0)
            {
                oForm.ClientWidth = pClientWidth;
            }

            if (pHeight>0)
            {
                oForm.Height = pHeight;
            }

            if (pWidth>0)
            {
                oForm.Width = pWidth;
            }

            oForm.AutoManaged = pAutoManaged;
            oForm.SupportedModes = pSupportedModes;


            return oForm;
        }

        public static void LoadFromXML(
            SAPbouiCOM.Application oApplication
            ,ref string pFileNAme
            )
        {
            System.Xml.XmlDocument oXmlDoc = null;
            oXmlDoc = new System.Xml.XmlDocument();
            string sPath = null;
            sPath = System.Windows.Forms.Application.StartupPath;
            oXmlDoc.Load(sPath + "\\" + pFileNAme);
            string sXML = oXmlDoc.InnerXml.ToString();
            oApplication.LoadBatchActions(ref sXML);
        }

        public static SAPbouiCOM.Matrix AddMatrixAoFormulario(
                    SAPbouiCOM.Form pForm
                    , string pUID
                    , int pLeft
                    , int pWidth
                    , int pTop
                    , int pHeight
                    , SAPbouiCOM.BoMatrixSelect pBoMatrixSelect


            )
        {

            SAPbouiCOM.Item oItem;
            SAPbouiCOM.Matrix oMatrix;

            oItem = pForm.Items.Add(pUID, SAPbouiCOM.BoFormItemTypes.it_MATRIX);
            if (pLeft > 0)
            {
                oItem.Left = pLeft;
            }
            if (pWidth > 0)
            {
                oItem.Width = pWidth;
            }
            if (pTop > 0)
            {
                oItem.Top = pTop;
            }
            if (pHeight > 0)
            {
                oItem.Height = pHeight;
            }
            oMatrix = ((SAPbouiCOM.Matrix)(oItem.Specific));
            oMatrix.SelectionMode = pBoMatrixSelect;

            return oMatrix;
        }

        public static SAPbouiCOM.Grid AddGridAoFormulario(

                    SAPbouiCOM.Form pForm
                    , string pUID
                    , int pLeft
                    , int pWidth
                    , int pTop
                    , int pHeight
                    , SAPbouiCOM.BoMatrixSelect pBoMatrixSelect
                    , SAPbouiCOM.DataTable pDataTable
            )
        {
            SAPbouiCOM.Grid oGrid;

            SAPbouiCOM.Item oItem = pForm.Items.Add(pUID, SAPbouiCOM.BoFormItemTypes.it_GRID);
            oGrid = ((SAPbouiCOM.Grid)(oItem.Specific));
            oGrid.Item.Left = pLeft;
            oGrid.Item.Top = pTop;
            oGrid.Item.Height = pHeight;
            oGrid.Item.Width = pWidth;
            oGrid.SelectionMode = pBoMatrixSelect;
            oGrid.DataTable = pDataTable;

            return oGrid;
        }

    }
}
