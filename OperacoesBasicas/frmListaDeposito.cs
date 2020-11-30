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
    public partial class frmListaDeposito : Form
    {
        public frmListaDeposito()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.SBObob oSBObob;
            SAPbobsCOM.Recordset oRecordset;
            //SAPbobsCOM.oItem oBusinessPartners;

            int i;
            try
            {
                oSBObob = (SAPbobsCOM.SBObob)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
                oRecordset = (SAPbobsCOM.Recordset)Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                oRecordset = oSBObob.GetWareHouseList();

                i = 0;

                this.listBox1.Items.Clear();
                this.listBox1.Items.Add("Codigo" +"\t"+"\t"+"Nome");
                oRecordset.MoveFirst();


                while (!(oRecordset.EoF == true))
                {
                    if (oRecordset.EoF == false && i < Convert.ToInt32(this.textBox1.Text))
                    {
                        this.listBox1.Items.Add(oRecordset.Fields.Item(0).Value + "\t" + "\t" + oRecordset.Fields.Item(1).Value);
                        i++;
                    }
                    oRecordset.MoveNext();
                    if (i > Convert.ToInt32(this.textBox1.Text))
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
