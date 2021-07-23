using HelperB1;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialogos
{
    class Dialogo
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
        //private SAPbouiCOM.Item oItem;

        private SAPbouiCOM.Button oBtnFolder;
        private SAPbouiCOM.Button oBtnOpen;
        private SAPbouiCOM.Button oBtnSave;

        private SAPbouiCOM.StaticText oStaticF = null;
        private SAPbouiCOM.StaticText oStaticO = null;
        private SAPbouiCOM.StaticText oStaticS = null;
        public Dialogo()
        {
            AppHelper.SetApplication(ref this.oApplication);
            
            this.oForm = UIHelper.CriarForm(this.oApplication, 
                SAPbouiCOM.BoFormBorderStyle.fbs_Sizable, 
                "frmDial", "frmDial", 0, 0, true, 0, 
                "Seleção de Arquivos e diretorios", 150, 650);

            this.oBtnFolder = UIHelper.AddBotaoAoFormulario(this.oForm, "btnF", 10, 100, 10, 0, "Selecionar Pasta", false);
            this.oBtnOpen = UIHelper.AddBotaoAoFormulario(this.oForm, "btnO", 10, 100, 40, 0, "Abrir Arquivo", false);
            this.oBtnSave = UIHelper.AddBotaoAoFormulario(this.oForm, "btnS", 10, 100, 70, 0, "Salvar Arquivo", false);

            this.oStaticF = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "Pasta", 120, 500, 10, 0, "");
            this.oStaticO = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "ArquivoO", 120, 500, 40, 0, "");
            this.oStaticS = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "ArquivoS", 120, 500, 70, 0, "");

            this.oForm.Visible = true;
            this.oApplication.ItemEvent += OApplication_ItemEvent;
            this.oForm.Freeze(false);
        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if ((FormUID.Equals("frmDial")) &(!pVal.BeforeAction) &(pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED))
            {
                if (pVal.ItemUID.Equals("btnF")) {
                    DialogoSelecaoArquivo dialogo = new DialogoSelecaoArquivo("C:\\", "",
                        "Arquivos TXT (*.txt)|*.txt|Todos Arquivos (*.*)|*.*", TipoDialogo.PASTA);
                    dialogo.Open();

                    if (!string.IsNullOrEmpty(dialogo.PastaSelecionada))
                    {
                        this.oStaticF.Caption = dialogo.PastaSelecionada;
                        Process.Start("explorer.exe", this.oStaticF.Caption);
                    }
                    else
                    {
                        this.oStaticF.Caption = "";
                    }
                }
                else if (pVal.ItemUID.Equals("btnO"))
                {
                    DialogoSelecaoArquivo dialogo = new DialogoSelecaoArquivo(this.oStaticF.Caption, "",
                        "Arquivos TXT (*.txt)|*.txt|Todos Arquivos (*.*)|*.*", TipoDialogo.ABRE);
                    dialogo.Open();

                    if (!string.IsNullOrEmpty(dialogo.ArquivoSelecionado))
                    {
                        this.oStaticO.Caption = dialogo.ArquivoSelecionado;
                        Process.Start("notepad.exe", this.oStaticO.Caption);
                    }
                    else
                    {
                        this.oStaticO.Caption = "";
                    }
                }
                else if (pVal.ItemUID.Equals("btnS"))
                {
                    DialogoSelecaoArquivo dialogo = new DialogoSelecaoArquivo(this.oStaticF.Caption, this.oStaticO.Caption,
                        "Arquivos TXT (*.txt)|*.txt|Todos Arquivos (*.*)|*.*", TipoDialogo.SALVA);
                    dialogo.Open();

                    if (!string.IsNullOrEmpty(dialogo.ArquivoSelecionado))
                    {
                        IEnumerable<string> contents;
                        contents = File.ReadAllLines(this.oStaticO.Caption);


                        this.oStaticS.Caption = dialogo.ArquivoSelecionado;
                        //this.oStaticO.Caption
                        if (File.Exists(this.oStaticS.Caption))
                        {
                            try
                            {
                                File.Delete(this.oStaticS.Caption);
                                File.AppendAllLines(this.oStaticS.Caption, contents);
                            }
                            catch (Exception ex)
                            {
                                oApplication.SetStatusBarMessage(ex.Message,
                                                BoMessageTime.bmt_Long
                                                , true);
                            }
                        }
                        else
                        {
                            File.AppendAllLines(this.oStaticS.Caption, contents);
                        }
                        
                    }
                    else
                    {
                        this.oStaticS.Caption = "";
                    }
                }
            }
        }
    }
}
