namespace OperacoesBasicas
{
    partial class frmEscolherBD
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxServerTypes = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsuarioDB = new System.Windows.Forms.TextBox();
            this.textBoxSenhaDB = new System.Windows.Forms.TextBox();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSenhaSAP = new System.Windows.Forms.TextBox();
            this.textBoxUsuarioSAP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLicenceServer = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DB Type";
            // 
            // listBoxServerTypes
            // 
            this.listBoxServerTypes.FormattingEnabled = true;
            this.listBoxServerTypes.Items.AddRange(new object[] {
            "1-dst_MSSQL",
            "2-dst_DB_2",
            "3-dst_SYBASE",
            "4-dst_MSSQL2005",
            "5-dst_MAXDB",
            "6-dst_MSSQL2008",
            "7-dst_MSSQL2012",
            "8-dst_MSSQL2014",
            "9-dst_HANADB",
            "10-dst_MSSQL2016",
            "11-dst_MSSQL2017"});
            this.listBoxServerTypes.Location = new System.Drawing.Point(87, 12);
            this.listBoxServerTypes.Name = "listBoxServerTypes";
            this.listBoxServerTypes.Size = new System.Drawing.Size(274, 199);
            this.listBoxServerTypes.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxSenhaDB);
            this.groupBox1.Controls.Add(this.textBoxUsuarioDB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(378, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 76);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do Login no Banco de Dados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuário:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Senha:";
            // 
            // textBoxUsuarioDB
            // 
            this.textBoxUsuarioDB.Location = new System.Drawing.Point(69, 19);
            this.textBoxUsuarioDB.Name = "textBoxUsuarioDB";
            this.textBoxUsuarioDB.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsuarioDB.TabIndex = 2;
            this.textBoxUsuarioDB.Text = "sa";
            // 
            // textBoxSenhaDB
            // 
            this.textBoxSenhaDB.Location = new System.Drawing.Point(69, 45);
            this.textBoxSenhaDB.Name = "textBoxSenhaDB";
            this.textBoxSenhaDB.PasswordChar = '*';
            this.textBoxSenhaDB.Size = new System.Drawing.Size(100, 20);
            this.textBoxSenhaDB.TabIndex = 3;
            this.textBoxSenhaDB.Text = "123@Mudar";
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(520, 236);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.Size = new System.Drawing.Size(125, 20);
            this.textBoxDBName.TabIndex = 3;
            this.textBoxDBName.Text = "SBODemoBR_31_10_2020";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nome do Banco de Dados:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSenhaSAP);
            this.groupBox2.Controls.Add(this.textBoxUsuarioSAP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(378, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 76);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações do Login no SAP";
            // 
            // textBoxSenhaSAP
            // 
            this.textBoxSenhaSAP.Location = new System.Drawing.Point(69, 45);
            this.textBoxSenhaSAP.Name = "textBoxSenhaSAP";
            this.textBoxSenhaSAP.PasswordChar = '*';
            this.textBoxSenhaSAP.Size = new System.Drawing.Size(100, 20);
            this.textBoxSenhaSAP.TabIndex = 3;
            this.textBoxSenhaSAP.Text = "1234";
            // 
            // textBoxUsuarioSAP
            // 
            this.textBoxUsuarioSAP.Location = new System.Drawing.Point(69, 19);
            this.textBoxUsuarioSAP.Name = "textBoxUsuarioSAP";
            this.textBoxUsuarioSAP.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsuarioSAP.TabIndex = 2;
            this.textBoxUsuarioSAP.Text = "manager";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Senha:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Usuário:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(14, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 60);
            this.button1.TabIndex = 5;
            this.button1.Text = "Conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(378, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Nome Servidor BD:";
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Location = new System.Drawing.Point(520, 210);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(125, 20);
            this.textBoxServerName.TabIndex = 6;
            this.textBoxServerName.Text = "WIN-3ILJ2PUQN5R";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(378, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Servidor Licence Server:";
            // 
            // textBoxLicenceServer
            // 
            this.textBoxLicenceServer.Location = new System.Drawing.Point(520, 184);
            this.textBoxLicenceServer.Name = "textBoxLicenceServer";
            this.textBoxLicenceServer.Size = new System.Drawing.Size(125, 20);
            this.textBoxLicenceServer.TabIndex = 8;
            this.textBoxLicenceServer.Text = "WIN-3ILJ2PUQN5R";
            // 
            // frmEscolherBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 342);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxLicenceServer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxServerName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDBName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxServerTypes);
            this.Controls.Add(this.label1);
            this.Name = "frmEscolherBD";
            this.Text = "Conexão";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxServerTypes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSenhaDB;
        private System.Windows.Forms.TextBox textBoxUsuarioDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDBName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxSenhaSAP;
        private System.Windows.Forms.TextBox textBoxUsuarioSAP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLicenceServer;
    }
}