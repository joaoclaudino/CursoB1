using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperacoesBasicas
{
    public partial class frmPrecoDoItem : Form
    {
        public frmPrecoDoItem()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.SBObob oSBObob;
            SAPbobsCOM.Recordset oRecordset;

            string sCardCode;
            string sItemCode;
            double dAmount;

            try
            {
                oSBObob = (SAPbobsCOM.SBObob)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
                oRecordset = (SAPbobsCOM.Recordset)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);


                oRecordset = oSBObob.GetObjectKeyBySingleValue(SAPbobsCOM.BoObjectTypes.oBusinessPartners,"CardName",textBox1.Text,SAPbobsCOM.BoQueryConditions.bqc_Equal);
                sCardCode = oRecordset.Fields.Item(0).Value.ToString();

                oRecordset = oSBObob.GetObjectKeyBySingleValue(SAPbobsCOM.BoObjectTypes.oItems, "ItemName", textBox2.Text, SAPbobsCOM.BoQueryConditions.bqc_Equal);
                sItemCode = oRecordset.Fields.Item(0).Value.ToString();

                dAmount = Convert.ToDouble(this.textBox3.Text);
                oRecordset = oSBObob.GetItemPrice(sCardCode,sItemCode,dAmount,dateTimePicker1.Value);

                textBox5.Text = oRecordset.Fields.Item(0).Value.ToString() +" - " +oRecordset.Fields.Item(1).Value.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
