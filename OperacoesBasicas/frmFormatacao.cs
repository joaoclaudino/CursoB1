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
    public partial class frmFormatacao : Form
    {
        private SAPbobsCOM.SBObob oSBObob;
        private SAPbobsCOM.Recordset oRecordset;
        public frmFormatacao()
        {
            InitializeComponent();
        }

        private void frmFormatacao_Load(object sender, EventArgs e)
        {            
            try
            {
                this.listBox1.SelectedIndex = 0;
                oSBObob = (SAPbobsCOM.SBObob)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
                oRecordset = (SAPbobsCOM.Recordset)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.oRecordset = this.oSBObob.Format_DateToString(DateTime.Now);
                this.textBox1.Text = this.oRecordset.Fields.Item(0).Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int iPrecisao = 0;
                if (this.listBox1.SelectedIndex==0)//Soma
                {
                    iPrecisao = Convert.ToInt32(SAPbobsCOM.BoMoneyPrecisionTypes.mpt_Sum);
                }
                else if (this.listBox1.SelectedIndex == 1)//Preço
                {
                    iPrecisao = Convert.ToInt32(SAPbobsCOM.BoMoneyPrecisionTypes.mpt_Price);
                }
                else if (this.listBox1.SelectedIndex == 2)//Taxa
                {
                    iPrecisao = Convert.ToInt32(SAPbobsCOM.BoMoneyPrecisionTypes.mpt_Rate);
                }
                else if (this.listBox1.SelectedIndex == 3)//Quantidade
                {
                    iPrecisao = Convert.ToInt32(SAPbobsCOM.BoMoneyPrecisionTypes.mpt_Quantity);

                }
                else if (this.listBox1.SelectedIndex == 4)//Percentual
                {
                    iPrecisao = Convert.ToInt32(SAPbobsCOM.BoMoneyPrecisionTypes.mpt_Percent);
                }
                else if (this.listBox1.SelectedIndex == 5)//Medida
                {
                    iPrecisao = Convert.ToInt32(SAPbobsCOM.BoMoneyPrecisionTypes.mpt_Measure);
                }
                else if (this.listBox1.SelectedIndex == 6)//Imposto
                {
                    iPrecisao = Convert.ToInt32(SAPbobsCOM.BoMoneyPrecisionTypes.mpt_Tax);
                }

                this.oRecordset = this.oSBObob.Format_MoneyToString(Convert.ToDouble(this.textBox2.Text),(SAPbobsCOM.BoMoneyPrecisionTypes)iPrecisao);

                this.textBox3.Text = this.oRecordset.Fields.Item(0).Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
