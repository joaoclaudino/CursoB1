namespace OperacoesBasicas.SerialELote
{
    partial class frmGestaoDeItens
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxItemCode = new System.Windows.Forms.TextBox();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NoneradioButton = new System.Windows.Forms.RadioButton();
            this.manSerRadioButton = new System.Windows.Forms.RadioButton();
            this.manBatchRadionButton = new System.Windows.Forms.RadioButton();
            this.OnReleaseOnly = new System.Windows.Forms.CheckBox();
            this.forceSerial = new System.Windows.Forms.CheckBox();
            this.itemKind = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(15, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Consultar Item";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Apagar Item";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item Name";
            // 
            // textBoxItemCode
            // 
            this.textBoxItemCode.Location = new System.Drawing.Point(73, 12);
            this.textBoxItemCode.Name = "textBoxItemCode";
            this.textBoxItemCode.Size = new System.Drawing.Size(64, 20);
            this.textBoxItemCode.TabIndex = 3;
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(73, 42);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(226, 20);
            this.textBoxItemName.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.itemKind);
            this.groupBox2.Controls.Add(this.forceSerial);
            this.groupBox2.Controls.Add(this.OnReleaseOnly);
            this.groupBox2.Controls.Add(this.manBatchRadionButton);
            this.groupBox2.Controls.Add(this.manSerRadioButton);
            this.groupBox2.Controls.Add(this.NoneradioButton);
            this.groupBox2.Location = new System.Drawing.Point(325, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 168);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seral e Lotes";
            // 
            // NoneradioButton
            // 
            this.NoneradioButton.AutoSize = true;
            this.NoneradioButton.Location = new System.Drawing.Point(16, 29);
            this.NoneradioButton.Name = "NoneradioButton";
            this.NoneradioButton.Size = new System.Drawing.Size(51, 17);
            this.NoneradioButton.TabIndex = 0;
            this.NoneradioButton.TabStop = true;
            this.NoneradioButton.Text = "None";
            this.NoneradioButton.UseVisualStyleBackColor = true;
            // 
            // manSerRadioButton
            // 
            this.manSerRadioButton.AutoSize = true;
            this.manSerRadioButton.Location = new System.Drawing.Point(16, 59);
            this.manSerRadioButton.Name = "manSerRadioButton";
            this.manSerRadioButton.Size = new System.Drawing.Size(114, 17);
            this.manSerRadioButton.TabIndex = 1;
            this.manSerRadioButton.TabStop = true;
            this.manSerRadioButton.Text = "Numeros de Series";
            this.manSerRadioButton.UseVisualStyleBackColor = true;
            // 
            // manBatchRadionButton
            // 
            this.manBatchRadionButton.AutoSize = true;
            this.manBatchRadionButton.Location = new System.Drawing.Point(16, 105);
            this.manBatchRadionButton.Name = "manBatchRadionButton";
            this.manBatchRadionButton.Size = new System.Drawing.Size(51, 17);
            this.manBatchRadionButton.TabIndex = 2;
            this.manBatchRadionButton.TabStop = true;
            this.manBatchRadionButton.Text = "Lotes";
            this.manBatchRadionButton.UseVisualStyleBackColor = true;
            // 
            // OnReleaseOnly
            // 
            this.OnReleaseOnly.AutoSize = true;
            this.OnReleaseOnly.Location = new System.Drawing.Point(41, 82);
            this.OnReleaseOnly.Name = "OnReleaseOnly";
            this.OnReleaseOnly.Size = new System.Drawing.Size(206, 17);
            this.OnReleaseOnly.TabIndex = 3;
            this.OnReleaseOnly.Text = "Somente quando movimentar Estoque";
            this.OnReleaseOnly.UseVisualStyleBackColor = true;
            // 
            // forceSerial
            // 
            this.forceSerial.AutoSize = true;
            this.forceSerial.Location = new System.Drawing.Point(41, 128);
            this.forceSerial.Name = "forceSerial";
            this.forceSerial.Size = new System.Drawing.Size(191, 17);
            this.forceSerial.TabIndex = 4;
            this.forceSerial.Text = "Selecionar ao Movimentar Estoque";
            this.forceSerial.UseVisualStyleBackColor = true;
            // 
            // itemKind
            // 
            this.itemKind.Location = new System.Drawing.Point(73, 29);
            this.itemKind.Name = "itemKind";
            this.itemKind.Size = new System.Drawing.Size(64, 20);
            this.itemKind.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Location = new System.Drawing.Point(188, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 91);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Saída";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(112, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "Entrada";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // frmGestaoDeItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 584);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxItemName);
            this.Controls.Add(this.textBoxItemCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGestaoDeItens";
            this.Text = "frmGestaoDeItens";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxItemCode;
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox itemKind;
        private System.Windows.Forms.CheckBox forceSerial;
        private System.Windows.Forms.CheckBox OnReleaseOnly;
        private System.Windows.Forms.RadioButton manBatchRadionButton;
        private System.Windows.Forms.RadioButton manSerRadioButton;
        private System.Windows.Forms.RadioButton NoneradioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}