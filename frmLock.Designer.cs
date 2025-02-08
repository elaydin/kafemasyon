namespace kafemasyon
{
    partial class frmLock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLock));
            this.button2 = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.btnKilitAc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(245)))));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Bauhaus 93", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(931, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 48);
            this.button2.TabIndex = 30;
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackColor = System.Drawing.Color.Transparent;
            this.btnAyarlar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.BackgroundImage")));
            this.btnAyarlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAyarlar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyarlar.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnAyarlar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAyarlar.Location = new System.Drawing.Point(288, 198);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(501, 286);
            this.btnAyarlar.TabIndex = 31;
            this.btnAyarlar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAyarlar.UseVisualStyleBackColor = false;
            // 
            // btnKilitAc
            // 
            this.btnKilitAc.BackColor = System.Drawing.Color.Transparent;
            this.btnKilitAc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKilitAc.BackgroundImage")));
            this.btnKilitAc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnKilitAc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKilitAc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKilitAc.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnKilitAc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKilitAc.Location = new System.Drawing.Point(12, 659);
            this.btnKilitAc.Name = "btnKilitAc";
            this.btnKilitAc.Size = new System.Drawing.Size(122, 57);
            this.btnKilitAc.TabIndex = 32;
            this.btnKilitAc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKilitAc.UseVisualStyleBackColor = false;
            this.btnKilitAc.Click += new System.EventHandler(this.btnKilitAc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(106, 681);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "Kilidi Aç";
            // 
            // frmLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1068, 728);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKilitAc);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLock";
            this.Text = "-";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Button btnKilitAc;
        private System.Windows.Forms.Label label1;
    }
}