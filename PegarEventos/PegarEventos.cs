using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PegarEventos
{
    public class PegarEventos
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.ProgressBar oProgBar;
        private void SetApplication()
        {
            SAPbouiCOM.SboGuiApi oSboGuiApi = null;
            string sConnectionString = null;
            oSboGuiApi = new SAPbouiCOM.SboGuiApi();
            sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));
            oSboGuiApi.Connect(sConnectionString);
            oApplication = oSboGuiApi.GetApplication(-1);
        }
        public PegarEventos()
        {
            SetApplication();

            //1-app Events
            oApplication.AppEvent += OApplication_AppEvent;
            //2-Menu Events
            oApplication.MenuEvent += OApplication_MenuEvent;
            //3-Item Events
            oApplication.ItemEvent += OApplication_ItemEvent;
            //4-ProgressBarEvents
            oApplication.ProgressBarEvent += OApplication_ProgressBarEvent;
            //5-Status BarEvents
            oApplication.StatusBarEvent += OApplication_StatusBarEvent;

            //ProgressBarEventos();

            oApplication.SetStatusBarMessage("Menssagem 01",
                            BoMessageTime.bmt_Short
                            , false);
            Thread.Sleep(1000);
            oApplication.SetStatusBarMessage("Menssagem 01",
                            BoMessageTime.bmt_Medium
                            , false);
            Thread.Sleep(1000);
            oApplication.SetStatusBarMessage("Menssagem 01",
                            BoMessageTime.bmt_Long
                            , false);
            Thread.Sleep(1000);
            oApplication.SetStatusBarMessage("Menssagem Erro 01",
                            BoMessageTime.bmt_Short
                            , true);
            Thread.Sleep(1000);
            oApplication.SetStatusBarMessage("Menssagem Erro 01",
                            BoMessageTime.bmt_Medium
                            , true);
            Thread.Sleep(1000);
            oApplication.SetStatusBarMessage("Menssagem Erro 01",
                            BoMessageTime.bmt_Long
                            , true);
        }

        private void OApplication_StatusBarEvent(string Text, BoStatusBarMessageType messageType)
        {
            oApplication.MessageBox(
                string.Format("Evento de StatusBar com Mensagem: {0}, MessageType: {1}", Text, messageType.ToString())
                
                , 1, "OK", "", "");
        }

        private void ProgressBarEventos()
        {
            oProgBar = oApplication.StatusBar.CreateProgressBar("Minha primeira Barra de Progresso!!", 50, true);

            oApplication.SetStatusBarMessage("Barra de Progresso Criada!!!",
                            BoMessageTime.bmt_Short
                            , false);

            oApplication.SetStatusBarMessage("Barra de Progresso em frente...",
                            BoMessageTime.bmt_Short
                            , false);
            for (int i = 0; i < 49; i++)
            {
                oProgBar.Value += 1;
                Thread.Sleep(500);
            }
            oApplication.SetStatusBarMessage("Barra de Progresso para tras...",
                            BoMessageTime.bmt_Short
                            , false);
            for (int i = 49; i > 0; i--)
            {
                oProgBar.Value -= 1;
                Thread.Sleep(500);
            }
            oProgBar.Stop();
            oApplication.SetStatusBarMessage("Barra de Progresso Parada!!!",
                            BoMessageTime.bmt_Short
                            , false);
        }

        private void OApplication_ProgressBarEvent(ref ProgressBarEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            oApplication.SetStatusBarMessage("O Evento " + pVal.EventType.ToString() + " Foi Enviado!!",
                BoMessageTime.bmt_Short
                , false);

        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.FormType!=0)
            {
                BoEventTypes EventEnum = 0;
                EventEnum = pVal.EventType;
                oApplication.SetStatusBarMessage(string.Format(
                    "Evento: {0},FormType{1} ,FormId: {2}, Before: {3}, ItemUID: {4}"
                    , EventEnum.ToString()
                    ,pVal.FormType.ToString()
                    , FormUID
                    ,pVal.BeforeAction.ToString()
                    ,pVal.ItemUID

                    )
                    ,BoMessageTime.bmt_Short
                    ,false
                    );
            }
        }

        private void OApplication_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.BeforeAction)
            {
                oApplication.SetStatusBarMessage("Menu Item: " + pVal.MenuUID + ", Antes", SAPbouiCOM.BoMessageTime.bmt_Long, true);
            }
            else
            {
                oApplication.SetStatusBarMessage("Menu Item: " + pVal.MenuUID + ", Depois", SAPbouiCOM.BoMessageTime.bmt_Long, true);
            }
        }

        private void OApplication_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    oApplication.MessageBox("A Empresa Foi Trocada!!!");
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    oApplication.MessageBox("O Evento ShutDown foi chamado!!"
                                            + Environment.NewLine
                                            + "Fechando o Addon..."
                        , 1,"OK","","");
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    oApplication.MessageBox("O Idioma Foi Modificado!!!");
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    oApplication.MessageBox("A Fonte Foi Modificada!!!");
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    oApplication.MessageBox("O Servidor Caiu!!!");
                    System.Windows.Forms.Application.Exit();
                    break;
            }
        }
    }
}
