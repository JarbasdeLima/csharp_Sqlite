using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace csharp_Sqlite
{
    public partial class frmRelatorios : Form
    {
        string Qtd = "";

        public frmRelatorios()
        {
            InitializeComponent();
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            
            GeraExcel();

        }
        private void GeraExcel()
        {
            Cursor = Cursors.WaitCursor;

            Excel.Application XcelApp = new Excel.Application();

            if (dgvDados.Rows.Count > 0)
            { 
                lblPgb1Status.Text = "Iniciando...";
                int cont = 1;

                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgvDados.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvDados.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < dgvDados.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dgvDados.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgvDados.Rows[i].Cells[j].Value.ToString();

                            if(cont != dgvDados.Rows.Count)
                            {
                                pgb1.Value = cont;
                                lblPgb1Status.Text = cont + "%";
                                cont++;
                            }

                        }
                    }
                    pgb1.Value = 100;
                    lblPgb1Status.Text = 100 + "%";

                    //
                    XcelApp.Columns.AutoFit();
                    //

                    XcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                    Cursor = Cursors.Default;
                }

                pgb1.Value = 0;
            }

            Cursor = Cursors.Default;
        }
        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            rdRelMembro.Checked = false;
            rdNascimentos.Checked = false;
            rdRelCasamento.Checked = false;
            dgvDados.DataSource = "";
            btnGerarRelatorio.Enabled = false;
            pgb1.Value = 0;
            Qtd = "";
            lblQtd.Text = "";


        }

        private void Relatorios_Load(object sender, EventArgs e)
        {
            btnGerarRelatorio.Enabled = false;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string tp = "";

            if (rdRelMembro.Checked == true)
            {
                tp = "Membro";
            }
            else if (rdNascimentos.Checked == true)
            {
                tp = "Rg_Nascimento";
            }
            else if (rdRelCasamento.Checked == true)
            {
                tp = "Rg_Casamento";
            }
            else
            {
                MessageBox.Show("Você precisa selecionar o tipo de Relatório que deseja!");
                return;
            }

            string dt_ini, dt_fim;
            lblQtd.Text = "Total: ";

            dt_ini = txtDt_inicio.Text;
            dt_fim = txtDt_fim.Text;

            DataTable dt = new DataTable();
            dt = DalHelper.GetRelatorio(tp, dt_ini, dt_fim);

            Qtd = Convert.ToString (dt.Rows.Count);

            lblQtd.Text = lblQtd.Text + Qtd;            

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Não houve dados para esse relatório.");
                Cursor = Cursors.Default;
                return;
            }

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            btnGerarRelatorio.Enabled = true;
            
            Cursor = Cursors.Default;
        }
    }
}
