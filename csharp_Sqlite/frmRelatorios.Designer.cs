namespace csharp_Sqlite
{
    partial class frmRelatorios
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rdRelMembro = new System.Windows.Forms.RadioButton();
            this.rdNascimentos = new System.Windows.Forms.RadioButton();
            this.rdRelCasamento = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.pgb1 = new System.Windows.Forms.ProgressBar();
            this.lblPgb1Status = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnLimparFiltro = new System.Windows.Forms.Button();
            this.btnGerarRelatorio = new System.Windows.Forms.Button();
            this.grpPeriodo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDt_fim = new System.Windows.Forms.MaskedTextBox();
            this.txtDt_inicio = new System.Windows.Forms.MaskedTextBox();
            this.lblQtd = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpPeriodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1302, 200);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::csharp_Sqlite.Properties.Resources.LOGOS_MODELO_11;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1296, 193);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rdRelMembro
            // 
            this.rdRelMembro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdRelMembro.Location = new System.Drawing.Point(10, 18);
            this.rdRelMembro.Name = "rdRelMembro";
            this.rdRelMembro.Size = new System.Drawing.Size(174, 35);
            this.rdRelMembro.TabIndex = 4;
            this.rdRelMembro.TabStop = true;
            this.rdRelMembro.Text = "Relatório de Membro";
            this.rdRelMembro.UseVisualStyleBackColor = true;
            // 
            // rdNascimentos
            // 
            this.rdNascimentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNascimentos.Location = new System.Drawing.Point(9, 48);
            this.rdNascimentos.Name = "rdNascimentos";
            this.rdNascimentos.Size = new System.Drawing.Size(280, 35);
            this.rdNascimentos.TabIndex = 12;
            this.rdNascimentos.TabStop = true;
            this.rdNascimentos.Text = "Relatório de Crianças apresentadas";
            this.rdNascimentos.UseVisualStyleBackColor = true;
            // 
            // rdRelCasamento
            // 
            this.rdRelCasamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdRelCasamento.Location = new System.Drawing.Point(9, 80);
            this.rdRelCasamento.Name = "rdRelCasamento";
            this.rdRelCasamento.Size = new System.Drawing.Size(289, 35);
            this.rdRelCasamento.TabIndex = 13;
            this.rdRelCasamento.TabStop = true;
            this.rdRelCasamento.Text = "Relatório de Casamentos registrados";
            this.rdRelCasamento.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblQtd);
            this.groupBox1.Controls.Add(this.dgvDados);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(455, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 405);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados gerados no excel";
            // 
            // dgvDados
            // 
            this.dgvDados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDados.BackgroundColor = System.Drawing.Color.White;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(11, 50);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(816, 339);
            this.dgvDados.TabIndex = 0;
            // 
            // pgb1
            // 
            this.pgb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgb1.Location = new System.Drawing.Point(0, 684);
            this.pgb1.Name = "pgb1";
            this.pgb1.Size = new System.Drawing.Size(1298, 14);
            this.pgb1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgb1.TabIndex = 15;
            // 
            // lblPgb1Status
            // 
            this.lblPgb1Status.AutoSize = true;
            this.lblPgb1Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPgb1Status.Location = new System.Drawing.Point(-1, 665);
            this.lblPgb1Status.Name = "lblPgb1Status";
            this.lblPgb1Status.Size = new System.Drawing.Size(45, 16);
            this.lblPgb1Status.TabIndex = 16;
            this.lblPgb1Status.Text = "Status";
            this.lblPgb1Status.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdRelMembro);
            this.groupBox2.Controls.Add(this.rdNascimentos);
            this.groupBox2.Controls.Add(this.rdRelCasamento);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox2.Location = new System.Drawing.Point(14, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 122);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Relatório";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.BackgroundImage = global::csharp_Sqlite.Properties.Resources.pesquisa;
            this.btnPesquisa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisa.Location = new System.Drawing.Point(14, 474);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(104, 60);
            this.btnPesquisa.TabIndex = 20;
            this.btnPesquisa.Text = "Pesquisar";
            this.btnPesquisa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnLimparFiltro
            // 
            this.btnLimparFiltro.BackgroundImage = global::csharp_Sqlite.Properties.Resources.Refresh;
            this.btnLimparFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimparFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparFiltro.Location = new System.Drawing.Point(133, 474);
            this.btnLimparFiltro.Name = "btnLimparFiltro";
            this.btnLimparFiltro.Size = new System.Drawing.Size(104, 60);
            this.btnLimparFiltro.TabIndex = 18;
            this.btnLimparFiltro.Text = "Limpar Filtros";
            this.btnLimparFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimparFiltro.UseVisualStyleBackColor = true;
            this.btnLimparFiltro.Click += new System.EventHandler(this.btnLimparFiltro_Click);
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.BackgroundImage = global::csharp_Sqlite.Properties.Resources.excel;
            this.btnGerarRelatorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGerarRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarRelatorio.Location = new System.Drawing.Point(257, 474);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(104, 60);
            this.btnGerarRelatorio.TabIndex = 17;
            this.btnGerarRelatorio.Text = "Gerar Relatório";
            this.btnGerarRelatorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGerarRelatorio.UseVisualStyleBackColor = true;
            this.btnGerarRelatorio.Click += new System.EventHandler(this.btnGerarRelatorio_Click);
            // 
            // grpPeriodo
            // 
            this.grpPeriodo.Controls.Add(this.label2);
            this.grpPeriodo.Controls.Add(this.label1);
            this.grpPeriodo.Controls.Add(this.txtDt_fim);
            this.grpPeriodo.Controls.Add(this.txtDt_inicio);
            this.grpPeriodo.Location = new System.Drawing.Point(14, 392);
            this.grpPeriodo.Name = "grpPeriodo";
            this.grpPeriodo.Size = new System.Drawing.Size(426, 62);
            this.grpPeriodo.TabIndex = 21;
            this.grpPeriodo.TabStop = false;
            this.grpPeriodo.Text = "Período";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Até";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "De :";
            // 
            // txtDt_fim
            // 
            this.txtDt_fim.Location = new System.Drawing.Point(178, 30);
            this.txtDt_fim.Mask = "00/00/0000";
            this.txtDt_fim.Name = "txtDt_fim";
            this.txtDt_fim.Size = new System.Drawing.Size(90, 20);
            this.txtDt_fim.TabIndex = 1;
            this.txtDt_fim.ValidatingType = typeof(System.DateTime);
            // 
            // txtDt_inicio
            // 
            this.txtDt_inicio.Location = new System.Drawing.Point(44, 30);
            this.txtDt_inicio.Mask = "00/00/0000";
            this.txtDt_inicio.Name = "txtDt_inicio";
            this.txtDt_inicio.Size = new System.Drawing.Size(90, 20);
            this.txtDt_inicio.TabIndex = 0;
            this.txtDt_inicio.ValidatingType = typeof(System.DateTime);
            // 
            // lblQtd
            // 
            this.lblQtd.AutoSize = true;
            this.lblQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtd.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblQtd.Location = new System.Drawing.Point(15, 25);
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(0, 16);
            this.lblQtd.TabIndex = 1;
            // 
            // frmRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 699);
            this.Controls.Add(this.grpPeriodo);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLimparFiltro);
            this.Controls.Add(this.btnGerarRelatorio);
            this.Controls.Add(this.lblPgb1Status);
            this.Controls.Add(this.pgb1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmRelatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Relatorios_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grpPeriodo.ResumeLayout(false);
            this.grpPeriodo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rdRelMembro;
        private System.Windows.Forms.RadioButton rdNascimentos;
        private System.Windows.Forms.RadioButton rdRelCasamento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar pgb1;
        private System.Windows.Forms.Label lblPgb1Status;
        private System.Windows.Forms.Button btnGerarRelatorio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnLimparFiltro;
        private System.Windows.Forms.GroupBox grpPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtDt_fim;
        private System.Windows.Forms.MaskedTextBox txtDt_inicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQtd;
    }
}