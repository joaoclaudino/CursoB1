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
    public partial class frmChavePrivada : Form
    {
        private SAPbobsCOM.UserKeysMD oUserKeysMD;
        private bool bFlagFirst;
        public frmChavePrivada()
        {
            InitializeComponent();
        }

        private void frmChavePrivada_Load(object sender, EventArgs e)
        {
            oUserKeysMD = (SAPbobsCOM.UserKeysMD)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserKeys);
            bFlagFirst = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bFlagFirst)
                {
                    bFlagFirst = false;
                }
                else
                {
                    this.oUserKeysMD.Elements.Add();
                }
                this.oUserKeysMD.Elements.ColumnAlias = this.textBox3.Text;
                this.listBox1.Items.Add(this.oUserKeysMD.Elements.ColumnAlias);
                
                this.textBox3.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.oUserKeysMD.Add();
            this.oUserKeysMD.TableName = this.textBox1.Text;
            this.oUserKeysMD.KeyName = this.textBox2.Text;
            if (this.checkBox1.Checked)
            {
                this.oUserKeysMD.Unique = SAPbobsCOM.BoYesNoEnum.tYES;
            }
            else
            {
                this.oUserKeysMD.Unique = SAPbobsCOM.BoYesNoEnum.tNO;
            }

            Global.iRetCode = oUserKeysMD.Add();

            if (Global.iRetCode != 0)
            {
                Global.oCompany.GetLastError(out Global.iErrorCode, out Global.sMsgErro);
                MessageBox.Show(string.Format("{0} - {1}", Global.iErrorCode, Global.sMsgErro));
            }
            else
            {
                MessageBox.Show(string.Format("Indice {0} Adicionado com Sucesso na tabela {1}!!", this.textBox2.Text, this.textBox1.Text));
            }
        }
    }
}
