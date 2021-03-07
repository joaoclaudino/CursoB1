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
    public partial class frmBuscaPorChaveEFiltros : Form
    {
        public frmBuscaPorChaveEFiltros()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.SBObob oSBObob;
            SAPbobsCOM.Recordset oRecordset;
            SAPbobsCOM.BusinessPartners oBusinessPartners;
            SAPbobsCOM.Items oItem;
            try
            {
                oSBObob = (SAPbobsCOM.SBObob)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
                oRecordset = (SAPbobsCOM.Recordset)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                int i = 0;
                this.listBox1.Items.Clear();

                if (this.listBox2.SelectedIndex==0)//PN
                {
                    oBusinessPartners = (SAPbobsCOM.BusinessPartners)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
                    oRecordset = oSBObob.GetObjectKeyBySingleValue(SAPbobsCOM.BoObjectTypes.oBusinessPartners, this.textBox2.Text, textBox3.Text, (SAPbobsCOM.BoQueryConditions)this.listBox3.SelectedIndex);
                    this.listBox1.Items.Add("CardCode"+"\t" + "\t"+"CardName");
                    this.listBox1.Items.Add("-------------------------------");

                    //oRecordset.MoveFirst();


                    while (!(oRecordset.EoF == true))
                    {
                        if (oRecordset.EoF == false && i < Convert.ToInt32(this.textBox1.Text))
                        {
                            oBusinessPartners.GetByKey(oRecordset.Fields.Item(0).Value.ToString());
                            this.listBox1.Items.Add(oBusinessPartners.CardCode + "\t" + "\t" + oBusinessPartners.CardName);
                            i++;
                        }
                        oRecordset.MoveNext();
                    }
                }
                else if (this.listBox2.SelectedIndex == 1)//Item
                {
                    oItem = (SAPbobsCOM.Items)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);

                    oRecordset = oSBObob.GetObjectKeyBySingleValue(SAPbobsCOM.BoObjectTypes.oItems, this.textBox2.Text, textBox3.Text, (SAPbobsCOM.BoQueryConditions)this.listBox3.SelectedIndex);
                    this.listBox1.Items.Add("ItemCode" + "\t" + "\t" + "ItemName");
                    this.listBox1.Items.Add("-------------------------------");

                    //oRecordset.MoveFirst();


                    while (!(oRecordset.EoF == true))
                    {
                        if (oRecordset.EoF == false && i < Convert.ToInt32(this.textBox1.Text))
                        {
                            oItem.GetByKey(oRecordset.Fields.Item(0).Value.ToString());
                            this.listBox1.Items.Add(oItem.ItemCode + "\t" + "\t" + oItem.ItemName);
                            i++;
                        }
                        oRecordset.MoveNext();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmBuscaPorChaveEFiltros_Load(object sender, EventArgs e)
        {
            this.listBox2.SelectedIndex = 0;
            this.listBox3.SelectedIndex = 0;
        }
    }
}
