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
    public partial class frmEscolherBD : Form
    {
        public frmEscolherBD()
        {
            InitializeComponent();
            listBoxServerTypes.SelectedIndex = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Global.oCompany.Connected)
            {
                Global.oCompany.Disconnect();
                Global.Iniciar();
            }

            Global.oCompany.CompanyDB = textBoxDBName.Text;
            Global.oCompany.UserName = textBoxUsuarioSAP.Text;
            Global.oCompany.Password = textBoxSenhaSAP.Text;
            Global.oCompany.Server = textBoxServerName.Text;
            Global.oCompany.LicenseServer = textBoxLicenceServer.Text;
            Global.oCompany.UseTrusted = true;

            Global.oCompany.DbUserName = textBoxUsuarioDB.Text;
            Global.oCompany.DbPassword = textBoxSenhaDB.Text;
            Global.oCompany.DbServerType = (SAPbobsCOM.BoDataServerTypes)listBoxServerTypes.SelectedIndex + 1;


            Global.iRetCode = Global.oCompany.Connect();

            if (Global.iRetCode!=0)
            {
                Global.oCompany.GetLastError(out Global.iErrorCode,out Global.sMsgErro);
                MessageBox.Show(string.Format("{0} - {1}", Global.iErrorCode, Global.sMsgErro));
            }
            else
            {
                MessageBox.Show(string.Format("Conectato em: {0}", Global.oCompany.CompanyName));
            }


        }
    }
}
