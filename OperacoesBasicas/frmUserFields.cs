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
    public partial class frmUserFields : Form
    {
        public frmUserFields()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex==-1)
            {
                return;
            }
            SAPbobsCOM.UserFieldsMD oUserFieldsMD;
            oUserFieldsMD = (SAPbobsCOM.UserFieldsMD)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserFields);


            oUserFieldsMD.TableName = this.textBox1.Text;
            oUserFieldsMD.Name = this.textBox2.Text;
            oUserFieldsMD.Description = this.textBox3.Text;

            oUserFieldsMD.Type = (SAPbobsCOM.BoFieldTypes)this.listBox1.SelectedIndex;
            if (this.listBox2.SelectedIndex>=0)
            {
                string sSubTypeCodigo = this.listBox2.SelectedItem.ToString().Split('-').FirstOrDefault();
                oUserFieldsMD.SubType = (SAPbobsCOM.BoFldSubTypes)Convert.ToInt32(sSubTypeCodigo);
            }
            if (this.textBox6.Lines.Count() >0)
            {
                foreach (string item in this.textBox6.Lines)
                {
                    string sCod = item.Split('-').First();
                    string sDesc = item.Split('-').Last();
                    oUserFieldsMD.ValidValues.Value = sCod;
                    oUserFieldsMD.ValidValues.Description = sDesc;
                    oUserFieldsMD.ValidValues.Add();
                }
            }

            if (!string.IsNullOrEmpty(this.textBox5.Text))
            {
                oUserFieldsMD.DefaultValue = this.textBox5.Text;
            }

            //oUserFieldsMD.Size = Convert.ToInt32(this.textBox4.Text);
            if (!string.IsNullOrEmpty(this.textBox4.Text))
            {
                oUserFieldsMD.EditSize = Convert.ToInt32(this.textBox4.Text);
            }
            

            if (this.checkBox1.Checked)
            {
                oUserFieldsMD.Mandatory = SAPbobsCOM.BoYesNoEnum.tYES;
            }
            else
            {
                oUserFieldsMD.Mandatory = SAPbobsCOM.BoYesNoEnum.tNO;
            }

            Global.iRetCode = oUserFieldsMD.Add();

            if (Global.iRetCode != 0)
            {
                Global.oCompany.GetLastError(out Global.iErrorCode, out Global.sMsgErro);
                MessageBox.Show(string.Format("{0} - {1}", Global.iErrorCode, Global.sMsgErro));
            }
            else
            {
                MessageBox.Show(string.Format("Campo {0} - {1} Adicionado com Sucesso na tabela {2}!!", this.textBox2.Text, this.textBox3.Text, this.textBox1.Text));
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
