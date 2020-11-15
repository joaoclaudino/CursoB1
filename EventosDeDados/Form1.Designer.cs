namespace EventosDeDados
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.GridDataEvent = new System.Windows.Forms.DataGrid();
            this.EventData = new System.Data.DataSet();
            this.tblDataEvent = new System.Data.DataTable();
            this.DataColumn1 = new System.Data.DataColumn();
            this.DataColumn2 = new System.Data.DataColumn();
            this.DataColumn3 = new System.Data.DataColumn();
            this.DataColumn4 = new System.Data.DataColumn();
            this.DataColumn5 = new System.Data.DataColumn();
            this.DataColumn6 = new System.Data.DataColumn();
            this.DataColumn7 = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridDataEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // GridDataEvent
            // 
            this.GridDataEvent.DataMember = "";
            this.GridDataEvent.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GridDataEvent.Location = new System.Drawing.Point(12, 23);
            this.GridDataEvent.Name = "GridDataEvent";
            this.GridDataEvent.Size = new System.Drawing.Size(776, 415);
            this.GridDataEvent.TabIndex = 0;
            // 
            // EventData
            // 
            this.EventData.DataSetName = "DataSetEvent";
            this.EventData.Tables.AddRange(new System.Data.DataTable[] {
            this.tblDataEvent});
            // 
            // tblDataEvent
            // 
            this.tblDataEvent.Columns.AddRange(new System.Data.DataColumn[] {
            this.DataColumn1,
            this.DataColumn2,
            this.DataColumn3,
            this.DataColumn4,
            this.DataColumn5,
            this.DataColumn6,
            this.DataColumn7});
            this.tblDataEvent.TableName = "DataEventTable";
            // 
            // DataColumn1
            // 
            this.DataColumn1.Caption = "ActionSuccses";
            this.DataColumn1.ColumnName = "ActionSuccses";
            // 
            // DataColumn2
            // 
            this.DataColumn2.Caption = "BeforeAction";
            this.DataColumn2.ColumnName = "BeforeAction";
            // 
            // DataColumn3
            // 
            this.DataColumn3.Caption = "EventType";
            this.DataColumn3.ColumnName = "EventType";
            // 
            // DataColumn4
            // 
            this.DataColumn4.Caption = "FormType";
            this.DataColumn4.ColumnName = "FormType";
            // 
            // DataColumn5
            // 
            this.DataColumn5.Caption = "FormUID";
            this.DataColumn5.ColumnName = "FormUID";
            // 
            // DataColumn6
            // 
            this.DataColumn6.Caption = "ObjectKey";
            this.DataColumn6.ColumnName = "ObjectKey";
            // 
            // DataColumn7
            // 
            this.DataColumn7.Caption = "Type";
            this.DataColumn7.ColumnName = "Type";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridDataEvent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.GridDataEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Data.DataSet EventData;
        private System.Data.DataTable tblDataEvent;
        internal System.Data.DataColumn DataColumn1;
        internal System.Data.DataColumn DataColumn2;
        internal System.Data.DataColumn DataColumn3;
        internal System.Data.DataColumn DataColumn4;
        internal System.Data.DataColumn DataColumn5;
        internal System.Data.DataColumn DataColumn6;
        internal System.Data.DataColumn DataColumn7;
        internal System.Windows.Forms.DataGrid GridDataEvent;
    }
}

