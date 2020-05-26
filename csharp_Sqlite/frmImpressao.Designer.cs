namespace csharp_Sqlite
{
    partial class frmImpressao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpressao));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdCarta = new System.Windows.Forms.RadioButton();
            this.rdRequerimento = new System.Windows.Forms.RadioButton();
            this.rdTranferencia = new System.Windows.Forms.RadioButton();
            this.rdRecomendacao = new System.Windows.Forms.RadioButton();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdBatismo = new System.Windows.Forms.RadioButton();
            this.rdNascimento = new System.Windows.Forms.RadioButton();
            this.grpCartas = new System.Windows.Forms.GroupBox();
            this.grpOutros = new System.Windows.Forms.GroupBox();
            this.rdCarteirinha = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.grpCartas.SuspendLayout();
            this.grpOutros.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(130, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 69);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(166, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Impressões";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::csharp_Sqlite.Properties.Resources.LOGO_MODELO_3___Copia;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(85, 70);
            this.panel2.TabIndex = 1;
            // 
            // rdCarta
            // 
            this.rdCarta.AutoSize = true;
            this.rdCarta.Location = new System.Drawing.Point(7, 28);
            this.rdCarta.Name = "rdCarta";
            this.rdCarta.Size = new System.Drawing.Size(89, 17);
            this.rdCarta.TabIndex = 3;
            this.rdCarta.TabStop = true;
            this.rdCarta.Text = "Carta Convite";
            this.rdCarta.UseVisualStyleBackColor = true;
            // 
            // rdRequerimento
            // 
            this.rdRequerimento.AutoSize = true;
            this.rdRequerimento.Location = new System.Drawing.Point(7, 61);
            this.rdRequerimento.Name = "rdRequerimento";
            this.rdRequerimento.Size = new System.Drawing.Size(134, 17);
            this.rdRequerimento.TabIndex = 4;
            this.rdRequerimento.TabStop = true;
            this.rdRequerimento.Text = "Carta de Requerimento";
            this.rdRequerimento.UseVisualStyleBackColor = true;
            // 
            // rdTranferencia
            // 
            this.rdTranferencia.AutoSize = true;
            this.rdTranferencia.Location = new System.Drawing.Point(7, 128);
            this.rdTranferencia.Name = "rdTranferencia";
            this.rdTranferencia.Size = new System.Drawing.Size(128, 17);
            this.rdTranferencia.TabIndex = 5;
            this.rdTranferencia.TabStop = true;
            this.rdTranferencia.Text = "Carta de Tranferência";
            this.rdTranferencia.UseVisualStyleBackColor = true;
            // 
            // rdRecomendacao
            // 
            this.rdRecomendacao.AutoSize = true;
            this.rdRecomendacao.Location = new System.Drawing.Point(6, 93);
            this.rdRecomendacao.Name = "rdRecomendacao";
            this.rdRecomendacao.Size = new System.Drawing.Size(129, 17);
            this.rdRecomendacao.TabIndex = 6;
            this.rdRecomendacao.TabStop = true;
            this.rdRecomendacao.Text = "Carta Recomendação";
            this.rdRecomendacao.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::csharp_Sqlite.Properties.Resources.imprimir;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(396, 293);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(78, 60);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.UseVisualStyleBackColor = true;
            //this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::csharp_Sqlite.Properties.Resources.IBNFU;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(-2, -2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(134, 71);
            this.panel3.TabIndex = 2;
            // 
            // rdBatismo
            // 
            this.rdBatismo.AutoSize = true;
            this.rdBatismo.Location = new System.Drawing.Point(6, 19);
            this.rdBatismo.Name = "rdBatismo";
            this.rdBatismo.Size = new System.Drawing.Size(130, 17);
            this.rdBatismo.TabIndex = 8;
            this.rdBatismo.TabStop = true;
            this.rdBatismo.Text = "Certificado de Batismo";
            this.rdBatismo.UseVisualStyleBackColor = true;
            // 
            // rdNascimento
            // 
            this.rdNascimento.AutoSize = true;
            this.rdNascimento.Location = new System.Drawing.Point(6, 54);
            this.rdNascimento.Name = "rdNascimento";
            this.rdNascimento.Size = new System.Drawing.Size(149, 17);
            this.rdNascimento.TabIndex = 9;
            this.rdNascimento.TabStop = true;
            this.rdNascimento.Text = "Certificado de Nascimento";
            this.rdNascimento.UseVisualStyleBackColor = true;
            // 
            // grpCartas
            // 
            this.grpCartas.Controls.Add(this.rdCarta);
            this.grpCartas.Controls.Add(this.rdRequerimento);
            this.grpCartas.Controls.Add(this.rdRecomendacao);
            this.grpCartas.Controls.Add(this.rdTranferencia);
            this.grpCartas.Location = new System.Drawing.Point(12, 103);
            this.grpCartas.Name = "grpCartas";
            this.grpCartas.Size = new System.Drawing.Size(219, 184);
            this.grpCartas.TabIndex = 10;
            this.grpCartas.TabStop = false;
            this.grpCartas.Text = "CARTAS";
            // 
            // grpOutros
            // 
            this.grpOutros.Controls.Add(this.rdCarteirinha);
            this.grpOutros.Controls.Add(this.rdBatismo);
            this.grpOutros.Controls.Add(this.rdNascimento);
            this.grpOutros.Location = new System.Drawing.Point(257, 103);
            this.grpOutros.Name = "grpOutros";
            this.grpOutros.Size = new System.Drawing.Size(217, 184);
            this.grpOutros.TabIndex = 11;
            this.grpOutros.TabStop = false;
            this.grpOutros.Text = "OUTROS";
            // 
            // rdCarteirinha
            // 
            this.rdCarteirinha.AutoSize = true;
            this.rdCarteirinha.Location = new System.Drawing.Point(10, 89);
            this.rdCarteirinha.Name = "rdCarteirinha";
            this.rdCarteirinha.Size = new System.Drawing.Size(131, 17);
            this.rdCarteirinha.TabIndex = 10;
            this.rdCarteirinha.TabStop = true;
            this.rdCarteirinha.Text = "Carteirinha de Membro";
            this.rdCarteirinha.UseVisualStyleBackColor = true;
            // 
            // frmImpressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 365);
            this.Controls.Add(this.grpOutros);
            this.Controls.Add(this.grpCartas);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImpressao";
            this.Text = "IBNFU - Impressão";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpCartas.ResumeLayout(false);
            this.grpCartas.PerformLayout();
            this.grpOutros.ResumeLayout(false);
            this.grpOutros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdCarta;
        private System.Windows.Forms.RadioButton rdRequerimento;
        private System.Windows.Forms.RadioButton rdTranferencia;
        private System.Windows.Forms.RadioButton rdRecomendacao;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.RadioButton rdBatismo;
        private System.Windows.Forms.RadioButton rdNascimento;
        private System.Windows.Forms.GroupBox grpCartas;
        private System.Windows.Forms.GroupBox grpOutros;
        private System.Windows.Forms.RadioButton rdCarteirinha;
    }
}