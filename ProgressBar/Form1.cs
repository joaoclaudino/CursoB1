using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.ProgressBar oProgressBar;
        public Form1()
        {
            InitializeComponent();
        }
        private void SetApplication()
        {
            SAPbouiCOM.SboGuiApi oSboGuiApi = null;
            string sConnectionString = null;
            oSboGuiApi = new SAPbouiCOM.SboGuiApi();
            sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));

            try
            {
                oSboGuiApi.Connect(sConnectionString);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }
            oApplication = oSboGuiApi.GetApplication(-1);
            oApplication.SetStatusBarMessage(string.Format("Addon {0} Conectado Com sucesso!!!",
                            System.Windows.Forms.Application.ProductName),
                            BoMessageTime.bmt_Medium
                            , false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetApplication();
            oApplication.ProgressBarEvent += OApplication_ProgressBarEvent;

            btnFrente.Enabled = false;
            btnTraz.Enabled = false;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }
        private void OApplication_ProgressBarEvent(ref ProgressBarEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (pVal.EventType == BoProgressBarEventTypes.pbet_ProgressBarStopped & pVal.BeforeAction)
            {
                oApplication.MessageBox("Progress Bar Stop",1,"OK","","");
                ReleaseBar();
            }
            else if (pVal.EventType == BoProgressBarEventTypes.pbet_ProgressBarCreated & pVal.BeforeAction)
            {
                oApplication.MessageBox("Progress Bar Criado", 1, "OK", "", "");
            }
            else if (pVal.EventType == BoProgressBarEventTypes.pbet_ProgressBarReleased & pVal.BeforeAction)
            {
                oApplication.MessageBox("Progress Bar Released", 1, "OK", "", "");
            }
            else
            {

                oApplication.SetStatusBarMessage("O Evento " + pVal.EventType.ToString() + " Foi Enviado!!",
                BoMessageTime.bmt_Short
                , false);
            }

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            oProgressBar = oApplication.StatusBar.CreateProgressBar("Exemplo de Progress Bar",27,true);
            btnFrente.Enabled = true;
            btnTraz.Enabled = true;
            btnStop.Enabled = true;

            btnStart.Enabled = false;
        }

        private void btnFrente_Click(object sender, EventArgs e)
        {
            oProgressBar.Value += 1;
        }

        private void btnTraz_Click(object sender, EventArgs e)
        {
            oProgressBar.Value -= 1;
        }

        private void ReleaseBar()
        {
            oProgressBar.Stop();
            btnFrente.Enabled = false;
            btnTraz.Enabled = false;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ReleaseBar();
        }
    }
}
