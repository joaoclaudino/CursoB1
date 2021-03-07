using OperacoesBasicas.SerialELote;
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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();


            //string stestes = "123-curso sap";

            //MessageBox.Show (stestes.Split('-').FirstOrDefault());
            

            Global.Iniciar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEscolherBD frmEscolherBD = new frmEscolherBD();
            frmEscolherBD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmRecordSet ofrmRecordSet = new frmRecordSet();
            ofrmRecordSet.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBuscarDados ofrmBuscarDados = new frmBuscarDados();
            ofrmBuscarDados.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmUserTable ofrmUserTable = new frmUserTable();
            ofrmUserTable.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmUserFields ofrmUserFields = new frmUserFields();
            ofrmUserFields.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmChavePrivada ofrmChavePrivada = new frmChavePrivada();
            ofrmChavePrivada.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmListaParceiroDeNegocios ofrmListaParceiroDeNegocios = new frmListaParceiroDeNegocios();
            ofrmListaParceiroDeNegocios.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmListaDataVencimento ofrmListaDataVencimento = new frmListaDataVencimento();
            ofrmListaDataVencimento.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Global.oCompany.Connected)
            {
                Global.oCompany.Disconnect();
                Global.Iniciar();
            }

            Global.oCompany.CompanyDB = OperacoesBasicas.Properties.Settings.Default.NomeDB;
            Global.oCompany.UserName = OperacoesBasicas.Properties.Settings.Default.UsuarioSAP;
            Global.oCompany.Password = OperacoesBasicas.Properties.Settings.Default.SenhaSAP;
            Global.oCompany.Server = OperacoesBasicas.Properties.Settings.Default.ServidorDB;
            Global.oCompany.LicenseServer = OperacoesBasicas.Properties.Settings.Default.LicenceServer;
            Global.oCompany.UseTrusted = true;

            Global.oCompany.DbUserName = OperacoesBasicas.Properties.Settings.Default.UsuarioDB;
            Global.oCompany.DbPassword = OperacoesBasicas.Properties.Settings.Default.SenhaDB;
            Global.oCompany.DbServerType = (SAPbobsCOM.BoDataServerTypes)Convert.ToInt32(OperacoesBasicas.Properties.Settings.Default.DBType);


            Global.iRetCode = Global.oCompany.Connect();

            if (Global.iRetCode != 0)
            {
                Global.oCompany.GetLastError(out Global.iErrorCode, out Global.sMsgErro);
                //MessageBox.Show(string.Format("{0} - {1}", Global.iErrorCode, Global.sMsgErro));
                this.label1.ForeColor = Color.Red;
                this.label1.Text = string.Format("{0} - {1}", Global.iErrorCode, Global.sMsgErro);
            }
            else
            {
                //MessageBox.Show(string.Format("Conectato em: {0}", Global.oCompany.CompanyName));
                this.label1.ForeColor = Color.Green;
                this.label1.Text = string.Format("Conectato em: {0}", Global.oCompany.CompanyName);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmPrecoDoItem ofrmPrecoDoItem = new frmPrecoDoItem();
            ofrmPrecoDoItem.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmListaItens ofrmListaItens = new frmListaItens();
            ofrmListaItens.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmListaUsuario ofrmListaUsuario = new frmListaUsuario();
            ofrmListaUsuario.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmListaDeposito ofrmListaDeposito = new frmListaDeposito();
            ofrmListaDeposito.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            frmFormatacao ofrmFormatacao = new frmFormatacao();
            ofrmFormatacao.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmBuscaPorChaveEFiltros ofrmBuscaPorChaveEFiltros = new frmBuscaPorChaveEFiltros();
            ofrmBuscaPorChaveEFiltros.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            frmGestaoDeItens ofrmGestaoDeItens = new frmGestaoDeItens();
            ofrmGestaoDeItens.ShowDialog();
        }
    }
}
