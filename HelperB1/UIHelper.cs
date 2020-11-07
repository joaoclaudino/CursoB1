using SAPbouiCOM;

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
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
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
        public static SAPbouiCOM.EditText AdcionarEditTextAoFormulario(
            SAPbouiCOM.Form pForm
            , string pUID
            , int pLeft
            , int pWidth
            , int pTop
            , int pHeight
            , bool AffectsFormMode = false
            , int pFromPane = 0
            , int pToPane = 0)
        {
            Item oItem = pForm.Items.Add(pUID, BoFormItemTypes.it_EDIT);
            SAPbouiCOM.EditText oEditText = null;
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
            oItem.AffectsFormMode = AffectsFormMode;
            if (pFromPane > 0)
            {
                oItem.FromPane = pFromPane;
            }
            if (pToPane > 0)
            {
                oItem.ToPane = pToPane;
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
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
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
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
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
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
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
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
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
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
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
    }
}
