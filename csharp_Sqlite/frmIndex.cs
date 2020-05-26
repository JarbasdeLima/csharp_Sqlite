using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Data;
using csharp_Sqlite.Models;

namespace csharp_Sqlite
{
    public partial class frmIndex : Form
    {
        public frmIndex()
        {
            InitializeComponent();
        }

        private void btnGerenciarMembro_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.ShowDialog();
            frmIndex frmindex = new frmIndex();
            frmindex.Visible = false;
        } // BTNGERENCIARMEMBRO

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            const string mensagem = "Deseja Encerrar ?";
            const string titulo = "Encerrar";
            var resultado = MessageBox.Show(mensagem, titulo,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        } // ENCERRAR BTNENCERRAR

        private void btnCriarTabelaEvento_Click(object sender, EventArgs e)
        {
            try
            {
                DalHelper.CriarTabelaSQlite();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        } //FECHA BTNCRIARTABELAEVENTOS
        private void RetQtdTpCadastro()
        {
            DataTable dt = new DataTable();
            dt = DalHelper.GetQtdTpCadastro();

            DataRow[] oDataRow = dt.Select();

            foreach (DataRow dr in oDataRow)
            {
                if (dr[1].ToString() == "Ficha de Membro")
                {
                    lblMembro.Text = dr[0].ToString();
                }
                if (dr[1].ToString() == "Recebeu Jesus")
                {
                    lblRetJesus.Text = dr[0].ToString();
                }
                if (dr[1].ToString() == "Ficha de Batismo")
                {
                    lblBatizou.Text = dr[0].ToString();
                }
                if (dr[1].ToString() == "Ficha de Transferencia")
                {
                    lblTransf.Text = dr[0].ToString();
                }
                if (dr[1].ToString() == "Ficha de Visita")
                {
                    lblVisit.Text = dr[0].ToString();
                }
                // Aniversariants
            }
        }
        private void RetornaAniversariantes()
        {

            try
            {
                DataTable dt = new DataTable();
                dt = DalHelper.GetAniversariantes();

                if (dt.Rows.Count != 0)
                {
                    dgvAniversariantes.DataSource = dt;
                    dgvAniversariantes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
                else
                {
                    dgvAniversariantes.DataSource = "Não existe aniversariantes neste mês";
                }
                dgvAniversariantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }
        private void frmIndex_Load(object sender, EventArgs e)
        {
            CarregadadosIniciais();
            DesabilitarCadNascimento();
            DesabilitarCadCasamento();

        }// FECHA LOAD 
        private void RetornaEventos()
        {

            try
            {
                DataTable dt = new DataTable();
                dt = DalHelper.GetEventos();

                if (dt.Rows.Count != 0)
                {
                    grdEventos.DataSource = dt;
                    grdEventos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
                else
                {
                    grdEventos.DataSource = "Não existe eventos neste mês.";
                }
                grdEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }
        private void RetronaQtdNascimento()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DalHelper.GetQtdNascimento();

                DataRow[] oDataRow = dt.Select();

                // iniciar os label's
                lblLocalNasc.Text = "0";
                lblVisitasNasc.Text = "0";

                foreach (DataRow dr in oDataRow)
                {
                    // totaliza os label's
                    if (dr[1].ToString() == "S") // se membro for local
                    {
                        lblLocalNasc.Text = dr[0].ToString();
                    }
                    if (dr[1].ToString() == "N") // se membro for visitante
                    {
                        lblVisitasNasc.Text = dr[0].ToString();
                    }

                }
            }
            catch (Exception )
            {
                MessageBox.Show("Não foi possivel carregar quantidade de crianças apresentadas!","ATENÇÃO");
            }
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            frmRelatorios frmRel = new frmRelatorios();
            frmRel.ShowDialog();
        }

        private void CarregadadosIniciais()
        {
            RetQtdTpCadastro();
            RetornaAniversariantes();
            RetornaEventos();
            RetronaQtdNascimento();

            int num1 = Convert.ToInt32(lblRetJesus.Text);
            int num2 = Convert.ToInt32(lblMembro.Text);
            int num3 = Convert.ToInt32(lblBatizou.Text);
            int num4 = Convert.ToInt32(lblTransf.Text);
            int num5 = Convert.ToInt32(lblVisit.Text);
            int res = num1 + num2 + num3 + num4 + num5;

            lblTotalGeral.Text = Convert.ToString(res);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregadadosIniciais();
            AtivaGruposInicial();
            DesabilitarCadNascimento();
        }

        private void btnImpressão_Click(object sender, EventArgs e)
        {
            frmImpressao frmimp = new frmImpressao();
            frmimp.ShowDialog();
        }

        private void btnNascimento_Click(object sender, EventArgs e)
        {
            DesativaGruposInicial();
            HabilitarCadNascimento();
            DesabilitarCadCasamento();
        }
        private void HabilitarCadNascimento()
        {
            pnCadNascimento.Visible = true;
        }
        private void HabilitarCadCasamento()
        {
            pnCadCasamento.Visible = true;
        }
        private void DesabilitarCadNascimento()
        {
            pnCadNascimento.Visible = false;
        }
        private void DesabilitarCadCasamento()
        {
            pnCadCasamento.Visible = false;
        }
        private void DesativaGruposInicial()
        {
            //grpMembrosCad.Visible = false;
            //grpRgNascidos.Visible = false;
            //grpRgCasados.Visible = false;
            //grpRgObito.Visible = false;
            //grpEvento.Visible = false;
            //grpRgAniversariantes.Visible = false;
            pnDashboard.Visible = false;
        }
        private void AtivaGruposInicial()
        {
            //grpMembrosCad.Visible = true;
           // grpRgNascidos.Visible = true;
            //grpRgCasados.Visible = true;
           // grpRgObito.Visible = true;
           // grpEvento.Visible = true;
           // grpRgAniversariantes.Visible = true;
            pnDashboard.Visible = true;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DesabilitarCadNascimento();
            CarregadadosIniciais();
            AtivaGruposInicial();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNmPai.Text = "";
            txtNmMae.Text = "";
            rdMembroLocalNao.Checked = false;
            rdMembroLocalSim.Checked = false;
            txtDataapresentacao.Text = "";
            txtNmCrianca.Text = "";
            txtDtNascimento.Text = "";
            txtNmPastor.Text = "";
        }

        private void btnCadNascimento_Click(object sender, EventArgs e)
        {
            string mblocal = "";

            if (txtNmMae.Text == "")
            {
                MessageBox.Show("Favor, insira um nome para Mãe.");
                return;
            }
            else
            if (txtNmPai.Text == "")
            {
                MessageBox.Show("Favor, insira um nome do Pai.");
                return;
            }else
            if (txtNmCrianca.Text == "")
            {
                MessageBox.Show("Favor, insira o nome da criança.");
                return;
            }
            else
            if (txtDtNascimento.Text == "" || txtDtNascimento.Text == "  /  /")
            {
                MessageBox.Show("Favor, digite uma data de nascimento válida!.");
                return;

            }
            if (txtNmPastor.Text == "")
            {
                MessageBox.Show("Favor, insira o nome do pastor que apresentou.");
                return;
            }
            else
            if (txtDataapresentacao.Text == "" || txtDataapresentacao.Text == "  /  /")
            {
                MessageBox.Show("Favor, digite uma data de apresentação válida!.");
                return;

            }
            else
            if (rdMembroLocalNao.Checked == true)
            {
                mblocal = "N";
            }
            else if (rdMembroLocalSim.Checked == true)
            {
                mblocal = "S";
            }
            else
            {
                MessageBox.Show("Marque uma opção para mebro local!");
                return;
            }

            try
                {
                    clsRegistros reg = new clsRegistros();

                    reg.Nomecrianca = txtNmCrianca.Text;
                    reg.Nomepai = txtNmPai.Text;
                    reg.Nomemae = txtNmMae.Text;
                    reg.dtapresentacao = txtDataapresentacao.Text;
                    reg.dtnascimento = txtDtNascimento.Text;
                    reg.Nomepastor = txtNmPastor.Text;
                    reg.membrolocal = mblocal;

                    DalHelper.AddNascimento(reg);
                    MessageBox.Show("Cadastramento realizado com sucesso!");

                    txtNmPai.Text = "";
                    txtNmMae.Text = "";
                    rdMembroLocalNao.Checked = false;
                    rdMembroLocalSim.Checked = false;
                    txtDataapresentacao.Text = "";
                    txtNmPastor.Text = "";
                    txtDtNascimento.Text = "";
                    txtNmCrianca.Text = "";

                    CarregadadosIniciais();
                    AtivaGruposInicial();
                    DesabilitarCadNascimento();

                }
                catch
                {
                    MessageBox.Show("Não foi possivel relizar o cadastro. Reinicie  o sistema e tente novamente", "Atenção");
                    MessageBox.Show("Se o erro persistir, acione o adminitrador.", "Atenção");

                    txtNmPai.Text = "";
                    txtNmMae.Text = "";
                    rdMembroLocalNao.Checked = false;
                    rdMembroLocalSim.Checked = false;
                    txtDataapresentacao.Text = "";
                    txtNmCrianca.Text = "";
                    txtDtNascimento.Text = "";
                    txtNmPastor.Text = "";

                    CarregadadosIniciais();
                    AtivaGruposInicial();
                    DesabilitarCadNascimento();
                }
            
            
        }

        private void btnCasamento_Click(object sender, EventArgs e)
        {
            HabilitarCadCasamento();
            DesabilitarCadNascimento();
            DesativaGruposInicial();
        }

        private void btnCadEncerra_Click(object sender, EventArgs e)
        {
            DesabilitarCadCasamento();
            DesabilitarCadNascimento();
            pnDashboard.Visible = true;
        }

        private void bntLimpar_Click(object sender, EventArgs e)
        {

        }

        private void btnatualizarDados_Click(object sender, EventArgs e)
        {

        }

        private void btnCadCasamento_Click(object sender, EventArgs e)
        {

        }
    } // FECHA CLASS

}// NAMESPACE
