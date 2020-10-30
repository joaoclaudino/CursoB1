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
            )
        {
            Item oItem = pForm.Items.Add(pUID, BoFormItemTypes.it_STATIC);
            SAPbouiCOM.StaticText oStaticText = null;
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
            oItem.AffectsFormMode = false;
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
            )
        {
            Item oItem = pForm.Items.Add(pUID, BoFormItemTypes.it_EDIT);
            SAPbouiCOM.EditText oEditText = null;
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
            oItem.AffectsFormMode = false;
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
            )
        {
            SAPbouiCOM.Item oItem = null;
            SAPbouiCOM.ComboBox oComboBox = null;

            oItem = pForm.Items.Add(pUID, BoFormItemTypes.it_COMBO_BOX);
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
            oItem.AffectsFormMode = false;
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
            )
        {
            Item oItem = pForm.Items.Add(pUID, BoFormItemTypes.it_RECTANGLE);
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
            oItem.AffectsFormMode = false;
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
            )
        {
            SAPbouiCOM.Item oItem = null;
            SAPbouiCOM.Button oButton = null;

            oItem = pForm.Items.Add(pUID, SAPbouiCOM.BoFormItemTypes.it_BUTTON);
            oItem.Left = pLeft;
            oItem.Width = pWidth;
            oItem.Top = pTop;
            oItem.Height = pHeight;
            oItem.AffectsFormMode = false;

            oButton = ((SAPbouiCOM.Button)(oItem.Specific));
            oButton.Caption = pCaption;

            return oButton;
        }
    }
}
