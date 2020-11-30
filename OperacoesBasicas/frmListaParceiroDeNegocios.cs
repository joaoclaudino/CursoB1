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
    public partial class frmListaParceiroDeNegocios : Form
    {
        public frmListaParceiroDeNegocios()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.SBObob oSBObob;
            SAPbobsCOM.Recordset oRecordset;
            SAPbobsCOM.BusinessPartners oBusinessPartners;

            int i;
            try
            {
                oSBObob = (SAPbobsCOM.SBObob)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
                oRecordset = (SAPbobsCOM.Recordset)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                oBusinessPartners = (SAPbobsCOM.BusinessPartners)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
                if (this.radioButton1.Checked)
                {
                    oRecordset = oSBObob.GetBPList(SAPbobsCOM.BoCardTypes.cCustomer);
                }
                else if (this.radioButton2.Checked)
                {
                    oRecordset = oSBObob.GetBPList(SAPbobsCOM.BoCardTypes.cSupplier);
                }
                else if (this.radioButton3.Checked)
                {
                    oRecordset = oSBObob.GetBPList(SAPbobsCOM.BoCardTypes.cLid);
                }
                i = 0;

                this.listBox1.Items.Clear();
                this.listBox1.Items.Add("Code"+"\t"+"\t"+"Name");
                oRecordset.MoveFirst();


                while (!(oRecordset.EoF==true))
                {
                    if (oRecordset.EoF == false && i < Convert.ToInt32(this.textBox1.Text))
                    {
                        oBusinessPartners.GetByKey(oRecordset.Fields.Item(0).Value.ToString());
                        this.listBox1.Items.Add(oBusinessPartners.CardCode + "-" + oBusinessPartners.CardName);
                        i++;
                    }
                    oRecordset.MoveNext();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmListaParceiroDeNegocios_Load(object sender, EventArgs e)
        {
            this.radioButton1.Checked = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex!=-1)
            {
                try
                {
                    SAPbobsCOM.SBObob oSBObob;
                    SAPbobsCOM.Recordset oRecordset;
                    oSBObob = (SAPbobsCOM.SBObob)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
                    oRecordset = (SAPbobsCOM.Recordset)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    oRecordset = oSBObob.GetContactEmployees(this.listBox1.SelectedItem.ToString().Split('-').First());

                    this.listBox2.Items.Clear();

                    this.listBox2.Items.Add("Nome do Contato");
                    this.listBox2.Items.Add("-----------------");
                    oRecordset.MoveFirst();


                    while (!(oRecordset.EoF == true))
                    {
                        this.listBox2.Items.Add(oRecordset.Fields.Item(0).Value +" - "+ oRecordset.Fields.Item(1).Value);
                        oRecordset.MoveNext();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
