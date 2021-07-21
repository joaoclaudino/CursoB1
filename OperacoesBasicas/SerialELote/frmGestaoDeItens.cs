using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperacoesBasicas.SerialELote
{
    public partial class frmGestaoDeItens : Form
    {
        public frmGestaoDeItens()
        {
            InitializeComponent();
            Global.oItems = Global.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.oItems.ItemCode = textBoxItemCode.Text;
            Global.oItems.ItemName = textBoxItemName.Text;
            Global.oItems.ManageSerialNumbersOnReleaseOnly = SAPbobsCOM.BoYesNoEnum.tNO;
            Global.oItems.ManageSerialNumbers = SAPbobsCOM.BoYesNoEnum.tNO;
            Global.oItems.ForceSelectionOfSerialNumber = SAPbobsCOM.BoYesNoEnum.tNO;
            Global.oItems.ManageBatchNumbers = SAPbobsCOM.BoYesNoEnum.tNO;

            if (manSerRadioButton.Checked)
            {
                Global.oItems.ManageSerialNumbers = SAPbobsCOM.BoYesNoEnum.tYES;
                if (OnReleaseOnly.Checked)
                {
                    Global.oItems.ManageSerialNumbersOnReleaseOnly = SAPbobsCOM.BoYesNoEnum.tYES;
                }
            }
            else
            {
                Global.oItems.ManageSerialNumbers = SAPbobsCOM.BoYesNoEnum.tNO;
                if (OnReleaseOnly.Checked)
                {
                    Global.oItems.ManageSerialNumbersOnReleaseOnly = SAPbobsCOM.BoYesNoEnum.tYES;
                }
            }

            if (forceSerial.Checked)
            {
                Global.oItems.ForceSelectionOfSerialNumber = SAPbobsCOM.BoYesNoEnum.tYES;
            }

            Global.iRetCode = Global.oItems.Add();
            if (Global.iRetCode!=0)
            {
                //Global.
                Global.oCompany.GetLastError( out Global.iErrorCode,out Global.sMsgErro );
                MessageBox.Show(string.Format("Erro: {0}: {1}", Global.iErrorCode, Global.sMsgErro));
            }
            else
            {
                MessageBox.Show(string.Format("Item Adcionado com Sucesso!!!", Global.oItems.ItemCode));

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            itemKind.Text = string.Empty;
            textBoxItemName.Text = string.Empty;
            manSerRadioButton.Checked = false;
            OnReleaseOnly.Checked = false;
            forceSerial.Checked = false;

            if (string.IsNullOrEmpty(textBoxItemCode.Text))
            {
                MessageBox.Show("Informe o Codigo do Item!!");
            }
            else
            {
                if (Global.oItems.GetByKey(textBoxItemCode.Text))
                {
                    textBoxItemCode.Text = Global.oItems.ItemCode;
                    textBoxItemName.Text = Global.oItems.ItemName;
                    if (Global.oItems.ManageSerialNumbers==SAPbobsCOM.BoYesNoEnum.tYES)
                    {
                        manSerRadioButton.Checked = true;
                        if (Global.oItems.ManageSerialNumbersOnReleaseOnly==SAPbobsCOM.BoYesNoEnum.tYES)
                        {
                            OnReleaseOnly.Checked = true;
                        }
                        else
                        {
                            OnReleaseOnly.Checked = false;
                        }
                    }
                    else
                    {
                        manSerRadioButton.Checked = false;
                        if (Global.oItems.ManageBatchNumbers==SAPbobsCOM.BoYesNoEnum.tYES)
                        {
                            manBatchRadionButton.Checked = true;
                        }
                        else
                        {
                            manBatchRadionButton.Checked = false;
                        }
                    }
                    if (Global.oItems.ForceSelectionOfSerialNumber==SAPbobsCOM.BoYesNoEnum.tYES)
                    {
                        forceSerial.Checked = true;
                    }
                    else
                    {
                        forceSerial.Checked = false;
                    }

                }
                else
                {
                    MessageBox.Show("Item Não Encontrado!!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxItemCode.Text))
            {
                MessageBox.Show("Informe o Codigo do Item!!");
            }else
            {
                if (Global.oItems.GetByKey(textBoxItemCode.Text))
                {
                    if (Global.oItems.Remove()==0)
                    {
                        MessageBox.Show("Sucesso!!");
                    }
                    else
                    {
                        Global.oCompany.GetLastError(out Global.iErrorCode, out Global.sMsgErro);
                        MessageBox.Show(string.Format("Erro: {0}: {1}", Global.iErrorCode, Global.sMsgErro));
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmEntrada ofrmEntrada = new frmEntrada();
            ofrmEntrada.ShowDialog();
        }
    }
}
