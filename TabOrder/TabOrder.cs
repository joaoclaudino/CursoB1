using HelperB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabOrder
{
    public class TabOrder
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;

        private SAPbouiCOM.OptionBtn oOptionBtnHor;
        private SAPbouiCOM.OptionBtn oOptionBtnVer;

        private SAPbouiCOM.Item oItem;

        private SAPbouiCOM.UserDataSource userDS;

        public TabOrder() {
            AppHelper.SetApplication(ref this.oApplication);

            string strTmp = "TabOrder.srf";
            UIHelper.LoadFromXML(oApplication, ref strTmp);

            oForm = oApplication.Forms.Item("frmTab");

            userDS=UserDataSourceHelper.AddUserDataSource(oForm, "OpBtnDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 1);

            oItem = oForm.Items.Item("optHor");
            oOptionBtnHor = ((SAPbouiCOM.OptionBtn)(oItem.Specific));
            oOptionBtnHor.GroupWith("optVer");
            oOptionBtnHor.DataBind.SetBound(true, "", "OpBtnDS");

            oItem = oForm.Items.Item("optVer");

            oOptionBtnVer = ((SAPbouiCOM.OptionBtn)(oItem.Specific));
            oOptionBtnVer.GroupWith("optHor");
            oOptionBtnVer.DataBind.SetBound(true, "", "OpBtnDS");

            oOptionBtnHor.Selected = true;
            SetTabHorizontal();
            oForm.Visible = true;


            oApplication.ItemEvent += OApplication_ItemEvent;
        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if ((FormUID.Equals("frmTab") & (pVal.ItemUID.Equals("optHor") | pVal.ItemUID.Equals("optVer")) & (pVal.EventType==SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED) & (!pVal.BeforeAction) ))
            {
                if (userDS.Value.Equals("1"))
                {
                    this.SetTabVertical();
                }
                else if (userDS.Value.Equals("2"))
                {
                    this.SetTabHorizontal();
                }
            }
            if (FormUID.Equals("frmTab") & (pVal.EventType==SAPbouiCOM.BoEventTypes.et_FORM_CLOSE))
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void SetTabHorizontal()
        {
            this.oForm.Freeze(true);
            SAPbouiCOM.EditText oEdit = null;
            int diff = 50;
            for (int i = 20; i <= 29; i++)
            {
                oItem = oForm.Items.Item(i.ToString());
                oEdit = ((SAPbouiCOM.EditText)(oItem.Specific));
                oEdit.TabOrder = i + diff;
                oEdit.Value = oEdit.TabOrder.ToString();
            }
            SetFocusItem20();
            this.oForm.Freeze(false);
        }
        private void SetFocusItem20()
        {
            SAPbouiCOM.EditText oEdit = null;
            oItem = oForm.Items.Item("20");
            oEdit = ((SAPbouiCOM.EditText)(oItem.Specific));
            oEdit.Value = oEdit.Value;
        }
        private void SetTabVertical()
        {
            this.oForm.Freeze(true);
            SAPbouiCOM.EditText oEdit = null;
            int left = 0, diff = 0, rigth = 0;
            left = 1;
            rigth = 2;
            diff = 100;
            for (int i = 20;  i <= 29; i++)
            {
                oItem = oForm.Items.Item(i.ToString());
                oEdit = ((SAPbouiCOM.EditText)(oItem.Specific));
                if (i<25)
                {
                    oEdit.TabOrder = left + diff;
                    left = left + 2;
                }
                else
                {
                    oEdit.TabOrder = rigth + diff;
                    rigth = rigth + 2;
                }

                oEdit.Value = oEdit.TabOrder.ToString();
            }
            SetFocusItem20();
            this.oForm.Freeze(false);

        }

    }
}
