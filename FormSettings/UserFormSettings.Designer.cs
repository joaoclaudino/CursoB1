namespace FormSettings
{
    partial class UserFormSettings
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
            this.btnMatrix = new System.Windows.Forms.Button();
            this.btnMudarGrid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMatrix
            // 
            this.btnMatrix.Location = new System.Drawing.Point(93, 12);
            this.btnMatrix.Name = "btnMatrix";
            this.btnMatrix.Size = new System.Drawing.Size(123, 39);
            this.btnMatrix.TabIndex = 0;
            this.btnMatrix.Text = "Matrix Form";
            this.btnMatrix.UseVisualStyleBackColor = true;
            this.btnMatrix.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMudarGrid
            // 
            this.btnMudarGrid.Location = new System.Drawing.Point(93, 83);
            this.btnMudarGrid.Name = "btnMudarGrid";
            this.btnMudarGrid.Size = new System.Drawing.Size(123, 44);
            this.btnMudarGrid.TabIndex = 1;
            this.btnMudarGrid.Text = "Trocar Matrix";
            this.btnMudarGrid.UseVisualStyleBackColor = true;
            this.btnMudarGrid.Click += new System.EventHandler(this.btnMudarGrid_Click);
            // 
            // UserFormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 162);
            this.Controls.Add(this.btnMudarGrid);
            this.Controls.Add(this.btnMatrix);
            this.Name = "UserFormSettings";
            this.Text = "UserFormSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMatrix;
        private System.Windows.Forms.Button btnMudarGrid;
    }
}