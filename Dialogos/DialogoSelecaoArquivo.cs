using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dialogos
{
    public class DialogoSelecaoArquivo
    {
        private ManualResetEvent shutdownEvent = new ManualResetEvent(false);
        public string ArquivoSelecionado { get; private set; }
        public string PastaSelecionada { get; private set; }

        private string pasta, arquivo, filtro;

        private TipoDialogo tipo;

        public DialogoSelecaoArquivo(
            string pasta, 
            string arquivo, 
            string filtro,
            TipoDialogo tipo)
        {
            if (pasta == null || arquivo == null || filtro == null)
                throw new ArgumentException("Todos os parâmetros são obrigatório");

            this.pasta = pasta;
            this.arquivo = arquivo;
            this.filtro = filtro;
            this.tipo = tipo;
        }

        private void DialogoSelecaoArquivoInterno()
        {
            var form = new System.Windows.Forms.Form();

            form.TopMost = true;
            form.Height = 0;
            form.Width = 0;
            form.WindowState = FormWindowState.Minimized;
            form.Visible = true;

            switch (tipo)
            {
                case TipoDialogo.PASTA:
                    //seleciona a pasta
                    DialogoPasta(form);
                    break;
                case TipoDialogo.ABRE:
                    //abrir arquigo
                    DialogoAbrir(form);
                    break;
                case TipoDialogo.SALVA:
                    //salvar o arquivo
                    DialogoSavar(form);
                    break;
            }

            shutdownEvent.Set();

        }

        private void DialogoPasta(System.Windows.Forms.Form form)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Por favor selecione uma pasta";
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                form.Close();
                PastaSelecionada = dialog.SelectedPath;
            }
            else
            {
                form.Close();
                PastaSelecionada = "";
            }
        }
        private void DialogoAbrir(System.Windows.Forms.Form form)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogoAbrirOuSalvar(dialog, form);
        }
        private void DialogoSavar(System.Windows.Forms.Form form)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            DialogoAbrirOuSalvar(dialog, form);
        }

        private void DialogoAbrirOuSalvar(FileDialog dialog, System.Windows.Forms.Form form)
        {
            dialog.Title = "Por favor informe um nome de arquivo";
            dialog.Filter = filtro;
            dialog.InitialDirectory = pasta;
            dialog.FileName = arquivo;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                form.Close();
                ArquivoSelecionado = dialog.FileName;
            }
            else
            {
                form.Close();
                ArquivoSelecionado = "";
            }
        }

        public void Open()
        {
            Thread t = new Thread(new ThreadStart(this.DialogoSelecaoArquivoInterno));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            shutdownEvent.WaitOne();

        }
    }
}
