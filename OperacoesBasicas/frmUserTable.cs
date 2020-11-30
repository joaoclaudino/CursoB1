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
    public partial class frmUserTable : Form
    {
        public frmUserTable()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.UserTablesMD oUserTablesMD;
            oUserTablesMD = (SAPbobsCOM.UserTablesMD)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserTables);

            oUserTablesMD.TableName = this.textBox1.Text;
            oUserTablesMD.TableDescription = this.textBox2.Text;

            oUserTablesMD.TableType = (SAPbobsCOM.BoUTBTableType)this.listBox1.SelectedIndex;


            if (this.listBox1.SelectedIndex==0 | this.listBox1.SelectedIndex==5)
            {
                if (this.checkBox1.Checked)
                {
                    oUserTablesMD.Archivable = SAPbobsCOM.BoYesNoEnum.tYES;
                }
            }

            Global.iRetCode = oUserTablesMD.Add();

            if (Global.iRetCode!=0)
            {
                Global.oCompany.GetLastError(out Global.iErrorCode, out Global.sMsgErro);
                MessageBox.Show(string.Format("{0} - {1}", Global.iErrorCode, Global.sMsgErro));
            }
            else
            {
                MessageBox.Show(string.Format("Tabela {0} - {1} Adicionada com Sucesso!!", this.textBox1.Text, this.textBox2.Text));
            }

        }
    }
}
