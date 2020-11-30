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
    public partial class frmBuscarDados : Form
    {
        private SAPbobsCOM.BusinessPartners oBusinessPartners;
        private SAPbobsCOM.Recordset oRecordset;
        public frmBuscarDados()
        {
            InitializeComponent();
        }

        private void frmBuscarDados_Load(object sender, EventArgs e)
        {
            this.oRecordset = (SAPbobsCOM.Recordset)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            this.oBusinessPartners = (SAPbobsCOM.BusinessPartners)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            this.button2.Enabled = false;
            this.button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.oRecordset.DoQuery(this.textBox1.Text);
            this.oBusinessPartners.Browser.Recordset = this.oRecordset;
            this.button2.Enabled = true;
            this.button3.Enabled = true;
            SetarResultados();
        }

        private void SetarResultados()
        {
            try
            {
                this.textBox2.Text = this.oBusinessPartners.CardCode;
                this.textBox3.Text = this.oBusinessPartners.CardName;
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.oBusinessPartners.Browser.BoF == false)
            {
                this.oBusinessPartners.Browser.MovePrevious();
                this.SetarResultados();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.oBusinessPartners.Browser.EoF == false)
            {
                this.oBusinessPartners.Browser.MoveNext();
                this.SetarResultados();
            }
        }
    }
}
