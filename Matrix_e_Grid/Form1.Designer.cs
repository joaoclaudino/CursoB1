namespace Matrix_e_Grid
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatrixXML = new System.Windows.Forms.TextBox();
            this.txtGridXML = new System.Windows.Forms.TextBox();
            this.btnSerXMLMatrix = new System.Windows.Forms.Button();
            this.btnSerXMLGrid = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonMatrixMetaEData = new System.Windows.Forms.RadioButton();
            this.radioButtonMatrixMetaData = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonGridMetaData = new System.Windows.Forms.RadioButton();
            this.radioButtonGridMetaEData = new System.Windows.Forms.RadioButton();
            this.radioButtonGridData = new System.Windows.Forms.RadioButton();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matrix e Grid Avançado";
            // 
            // txtMatrixXML
            // 
            this.txtMatrixXML.Location = new System.Drawing.Point(443, 89);
            this.txtMatrixXML.Multiline = true;
            this.txtMatrixXML.Name = "txtMatrixXML";
            this.txtMatrixXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMatrixXML.Size = new System.Drawing.Size(418, 174);
            this.txtMatrixXML.TabIndex = 1;
            // 
            // txtGridXML
            // 
            this.txtGridXML.Location = new System.Drawing.Point(443, 323);
            this.txtGridXML.Multiline = true;
            this.txtGridXML.Name = "txtGridXML";
            this.txtGridXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGridXML.Size = new System.Drawing.Size(418, 174);
            this.txtGridXML.TabIndex = 2;
            // 
            // btnSerXMLMatrix
            // 
            this.btnSerXMLMatrix.Location = new System.Drawing.Point(443, 57);
            this.btnSerXMLMatrix.Name = "btnSerXMLMatrix";
            this.btnSerXMLMatrix.Size = new System.Drawing.Size(168, 23);
            this.btnSerXMLMatrix.TabIndex = 3;
            this.btnSerXMLMatrix.Text = "Serialize Matrix XML -->";
            this.btnSerXMLMatrix.UseVisualStyleBackColor = true;
            this.btnSerXMLMatrix.Click += new System.EventHandler(this.btnSerXMLMatrix_Click);
            // 
            // btnSerXMLGrid
            // 
            this.btnSerXMLGrid.Location = new System.Drawing.Point(443, 291);
            this.btnSerXMLGrid.Name = "btnSerXMLGrid";
            this.btnSerXMLGrid.Size = new System.Drawing.Size(168, 23);
            this.btnSerXMLGrid.TabIndex = 4;
            this.btnSerXMLGrid.Text = "Serialize Grid XML -->";
            this.btnSerXMLGrid.UseVisualStyleBackColor = true;
            this.btnSerXMLGrid.Click += new System.EventHandler(this.btnSerXMLGrid_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(19, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(364, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Adicionar Matrix";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(19, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 50);
            this.button2.TabIndex = 6;
            this.button2.Text = "Fazer Colunas Ordenaveis";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(19, 181);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 50);
            this.button3.TabIndex = 7;
            this.button3.Text = "Desabilitar Ordenações";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(213, 117);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 50);
            this.button4.TabIndex = 8;
            this.button4.Text = "Primeira Coluna Ordenavel crescente";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(213, 181);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(170, 50);
            this.button5.TabIndex = 9;
            this.button5.Text = "Primeira Coluna Ordenação acendente";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(213, 429);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(170, 50);
            this.button6.TabIndex = 14;
            this.button6.Text = "Primeira Coluna Ordenação acendente";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(213, 365);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(170, 50);
            this.button7.TabIndex = 13;
            this.button7.Text = "Primeira Coluna Ordenavel crescente";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(19, 429);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(170, 50);
            this.button8.TabIndex = 12;
            this.button8.Text = "Desabilitar Ordenações";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(19, 365);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(170, 50);
            this.button9.TabIndex = 11;
            this.button9.Text = "Fazer Colunas Ordenaveis";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(19, 323);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(364, 36);
            this.button10.TabIndex = 10;
            this.button10.Text = "Adicionar Grid";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonMatrixMetaData);
            this.groupBox1.Controls.Add(this.radioButtonMatrixMetaEData);
            this.groupBox1.Location = new System.Drawing.Point(637, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 53);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonMatrixMetaEData
            // 
            this.radioButtonMatrixMetaEData.AutoSize = true;
            this.radioButtonMatrixMetaEData.Location = new System.Drawing.Point(7, 20);
            this.radioButtonMatrixMetaEData.Name = "radioButtonMatrixMetaEData";
            this.radioButtonMatrixMetaEData.Size = new System.Drawing.Size(105, 17);
            this.radioButtonMatrixMetaEData.TabIndex = 0;
            this.radioButtonMatrixMetaEData.TabStop = true;
            this.radioButtonMatrixMetaEData.Text = "Metadata e Data";
            this.radioButtonMatrixMetaEData.UseVisualStyleBackColor = true;
            // 
            // radioButtonMatrixMetaData
            // 
            this.radioButtonMatrixMetaData.AutoSize = true;
            this.radioButtonMatrixMetaData.Location = new System.Drawing.Point(118, 19);
            this.radioButtonMatrixMetaData.Name = "radioButtonMatrixMetaData";
            this.radioButtonMatrixMetaData.Size = new System.Drawing.Size(70, 17);
            this.radioButtonMatrixMetaData.TabIndex = 1;
            this.radioButtonMatrixMetaData.TabStop = true;
            this.radioButtonMatrixMetaData.Text = "Metadata";
            this.radioButtonMatrixMetaData.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonGridData);
            this.groupBox2.Controls.Add(this.radioButtonGridMetaData);
            this.groupBox2.Controls.Add(this.radioButtonGridMetaEData);
            this.groupBox2.Location = new System.Drawing.Point(617, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 53);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // radioButtonGridMetaData
            // 
            this.radioButtonGridMetaData.AutoSize = true;
            this.radioButtonGridMetaData.Location = new System.Drawing.Point(118, 19);
            this.radioButtonGridMetaData.Name = "radioButtonGridMetaData";
            this.radioButtonGridMetaData.Size = new System.Drawing.Size(70, 17);
            this.radioButtonGridMetaData.TabIndex = 1;
            this.radioButtonGridMetaData.TabStop = true;
            this.radioButtonGridMetaData.Text = "Metadata";
            this.radioButtonGridMetaData.UseVisualStyleBackColor = true;
            // 
            // radioButtonGridMetaEData
            // 
            this.radioButtonGridMetaEData.AutoSize = true;
            this.radioButtonGridMetaEData.Location = new System.Drawing.Point(7, 20);
            this.radioButtonGridMetaEData.Name = "radioButtonGridMetaEData";
            this.radioButtonGridMetaEData.Size = new System.Drawing.Size(105, 17);
            this.radioButtonGridMetaEData.TabIndex = 0;
            this.radioButtonGridMetaEData.TabStop = true;
            this.radioButtonGridMetaEData.Text = "Metadata e Data";
            this.radioButtonGridMetaEData.UseVisualStyleBackColor = true;
            // 
            // radioButtonGridData
            // 
            this.radioButtonGridData.AutoSize = true;
            this.radioButtonGridData.Location = new System.Drawing.Point(195, 19);
            this.radioButtonGridData.Name = "radioButtonGridData";
            this.radioButtonGridData.Size = new System.Drawing.Size(48, 17);
            this.radioButtonGridData.TabIndex = 2;
            this.radioButtonGridData.TabStop = true;
            this.radioButtonGridData.Text = "Data";
            this.radioButtonGridData.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(213, 485);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(170, 50);
            this.button11.TabIndex = 20;
            this.button11.Text = "Expand Grid";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(19, 485);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(170, 50);
            this.button12.TabIndex = 19;
            this.button12.Text = "Collapse Grid";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(443, 512);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(168, 48);
            this.button13.TabIndex = 21;
            this.button13.Text = "Carregar Serialize XML para o Grid";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Location = new System.Drawing.Point(624, 507);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 53);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(195, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Data";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(118, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Metadata";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 20);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(105, 17);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Metadata e Data";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 572);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSerXMLGrid);
            this.Controls.Add(this.btnSerXMLMatrix);
            this.Controls.Add(this.txtGridXML);
            this.Controls.Add(this.txtMatrixXML);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Funcionalidades de Matrix e Grid";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtMatrixXML;
        internal System.Windows.Forms.TextBox txtGridXML;
        private System.Windows.Forms.Button btnSerXMLMatrix;
        private System.Windows.Forms.Button btnSerXMLGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonMatrixMetaData;
        private System.Windows.Forms.RadioButton radioButtonMatrixMetaEData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonGridData;
        private System.Windows.Forms.RadioButton radioButtonGridMetaData;
        private System.Windows.Forms.RadioButton radioButtonGridMetaEData;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}

