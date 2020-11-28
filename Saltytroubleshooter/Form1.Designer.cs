namespace Saltytroubleshooter
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkDNS = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.progressText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkDNS
            // 
            this.checkDNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDNS.Location = new System.Drawing.Point(60, 213);
            this.checkDNS.Name = "checkDNS";
            this.checkDNS.Size = new System.Drawing.Size(186, 119);
            this.checkDNS.TabIndex = 0;
            this.checkDNS.Text = "Start";
            this.checkDNS.UseVisualStyleBackColor = true;
            this.checkDNS.Click += new System.EventHandler(this.button1_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(60, 98);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(633, 23);
            this.progress.TabIndex = 1;
            this.progress.Visible = false;
            // 
            // progressText
            // 
            this.progressText.AutoSize = true;
            this.progressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressText.Location = new System.Drawing.Point(55, 70);
            this.progressText.Name = "progressText";
            this.progressText.Size = new System.Drawing.Size(0, 25);
            this.progressText.TabIndex = 2;
            this.progressText.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Saltytroubleshooter.Properties.Resources.logo_big;
            this.pictureBox1.Location = new System.Drawing.Point(364, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressText);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.checkDNS);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "SaltyTroubleshooter - immortal-roleplay.one";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkDNS;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label progressText;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

