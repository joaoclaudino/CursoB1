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


    public partial class frmListaDataVencimento : Form
    {
        private SAPbobsCOM.SBObob oSBObob;
        private SAPbobsCOM.Recordset oRecordset;

        public frmListaDataVencimento()
        {
            InitializeComponent();
        }

        private void frmListaDataVencimento_Load(object sender, EventArgs e)
        {
            this.oSBObob = (SAPbobsCOM.SBObob)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
            this.oRecordset = (SAPbobsCOM.Recordset)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            this.oRecordset = oSBObob.GetBPList(SAPbobsCOM.BoCardTypes.cCustomer);

            this.oRecordset.MoveFirst();
            while (this.oRecordset.EoF==false)
            {
                this.listBox1.Items.Add(this.oRecordset.Fields.Item("CardCode").Value.ToString() +"-"+this.oRecordset.Fields.Item("CardNAme").Value.ToString());
                this.oRecordset.MoveNext();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex==-1)
            {
                return;
            }
            DateTime dtReferencia=this.dateTimePicker2.Value;
            this.oRecordset=this.oSBObob.GetDueDate(this.listBox1.SelectedItem.ToString().Split('-').First(), dtReferencia);


            if (Global.iRetCode != 0)
            {
                Global.oCompany.GetLastError(out Global.iErrorCode, out Global.sMsgErro);
                MessageBox.Show(string.Format("{0} - {1}", Global.iErrorCode, Global.sMsgErro));
            }
            else
            {
                if (this.oRecordset.RecordCount>0)
                {
                    this.textBox1.Text = oRecordset.Fields.Item(0).Value.ToString();
                }
                else
                {
                    this.textBox1.Text = "Sem Vencimentos";
                }
                
            }
        }
    }
}
