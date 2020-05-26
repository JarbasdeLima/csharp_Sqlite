namespace csharp_Sqlite
{
    partial class frmFotografar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFotografar));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCaptura = new System.Windows.Forms.Button();
            this.picImagem = new System.Windows.Forms.PictureBox();
            this.picWebCam = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebCam)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.Location = new System.Drawing.Point(275, 298);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(266, 37);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar Imagem";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCaptura
            // 
            this.btnCaptura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaptura.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCaptura.Location = new System.Drawing.Point(1, 298);
            this.btnCaptura.Margin = new System.Windows.Forms.Padding(4);
            this.btnCaptura.Name = "btnCaptura";
            this.btnCaptura.Size = new System.Drawing.Size(266, 37);
            this.btnCaptura.TabIndex = 3;
            this.btnCaptura.Text = "Capturar Imagem";
            this.btnCaptura.UseVisualStyleBackColor = true;
            this.btnCaptura.Click += new System.EventHandler(this.btnCaptura_Click);
            // 
            // picImagem
            // 
            this.picImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImagem.Location = new System.Drawing.Point(275, 3);
            this.picImagem.Margin = new System.Windows.Forms.Padding(4);
            this.picImagem.Name = "picImagem";
            this.picImagem.Size = new System.Drawing.Size(266, 287);
            this.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImagem.TabIndex = 2;
            this.picImagem.TabStop = false;
            // 
            // picWebCam
            // 
            this.picWebCam.BackColor = System.Drawing.Color.White;
            this.picWebCam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picWebCam.Location = new System.Drawing.Point(1, 3);
            this.picWebCam.Margin = new System.Windows.Forms.Padding(4);
            this.picWebCam.Name = "picWebCam";
            this.picWebCam.Size = new System.Drawing.Size(266, 287);
            this.picWebCam.TabIndex = 1;
            this.picWebCam.TabStop = false;
            // 
            // frmFotografar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(547, 340);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCaptura);
            this.Controls.Add(this.picImagem);
            this.Controls.Add(this.picWebCam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFotografar";
            this.Text = "Fotografia";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmFotografar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picWebCam;
        private System.Windows.Forms.PictureBox picImagem;
        private System.Windows.Forms.Button btnCaptura;
        private System.Windows.Forms.Button btnSalvar;
    }
}