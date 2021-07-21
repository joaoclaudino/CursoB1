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
    public partial class frmEntrada : Form
    {
        public frmEntrada()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                }
            }
        }
    }
}
