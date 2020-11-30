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
    public partial class frmRecordSet : Form
    {
        private SAPbobsCOM.Recordset oRecordset;
        public frmRecordSet()
        {
            InitializeComponent();

            string sPath = Application.StartupPath;
            this.textBox4.Text = sPath + "\\";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.oRecordset = (SAPbobsCOM.Recordset)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            this.oRecordset.DoQuery(textBox1.Text);
            this.lblTotal.Text = string.Format("Total de Registros: {0}", this.oRecordset.RecordCount);
            this.button2.Enabled = true;
            this.button3.Enabled = true;
            this.button4.Enabled = true;
            
            SetarResultados();
        }

        private void SetarResultados()
        {
            try
            {
                this.textBox2.Text = this.oRecordset.Fields.Item(0).Value.ToString();
                this.textBox3.Text = this.oRecordset.Fields.Item(1).Value.ToString();
            }
            catch
            {
            }
        }

        private void frmRecordSet_Load(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.oRecordset.BoF==false)
            {
                this.oRecordset.MovePrevious();
                SetarResultados();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.oRecordset.EoF==false)
            {
                this.oRecordset.MoveNext();
                SetarResultados();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.oRecordset.MoveFirst();
            SetarResultados();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.oRecordset.MoveLast();
            SetarResultados();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.oRecordset.SaveXML(this.textBox4.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.oRecordset.SaveToFile(this.textBox4.Text);
        }
    }
}
