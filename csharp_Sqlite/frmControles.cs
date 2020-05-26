using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Data;
using csharp_Sqlite.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace csharp_Sqlite
{
    public partial class frmControles : Form
    {
        string strSexo = "";
        string strTpCadastro = "";
        string tp = "Incluir";

        public frmControles()
        {
            InitializeComponent();
        }

        private void frmControles_Load(object sender, EventArgs e)
        {
            CarregadadosIniciais();
            ExibirDados(false);
            CarregaCombo();
        }// load
        private void CarregaCombo()
        {
            DataTable dt = new DataTable();

            // Carrega cargo
            dt = DalHelper.GetCombos("Cargo");
            cbCargo.DataSource = dt;
            cbCargo.ValueMember = "Cargo";
            cbCargo.Text = "Todos";

            // Carrega Grupo
            dt = DalHelper.GetCombos("Grupo");
            cbGrupo.DataSource = dt;
            cbGrupo.ValueMember = "Grupo";
            cbGrupo.Text = "Todos";

            // Carrega Funcao
            dt = DalHelper.GetCombos("Funcao");
            cbFuncao.DataSource = dt;
            cbFuncao.ValueMember = "Funcao";
            cbFuncao.Text = "Todos";

            // Carrega Sexo
            dt = DalHelper.GetCombos("Sexo");
            cbSexo.DataSource = dt;
            cbSexo.ValueMember = "Sexo";
            cbSexo.Text = "Todos";

            // Carrega TpCadastro
            dt = DalHelper.GetCombos("TpCadastro");
            cbTipoCadastro.DataSource = dt;
            cbTipoCadastro.ValueMember = "Tp_Cadastro";
            cbTipoCadastro.Text = "Todos";

            // Carrega Estado civil
            dt = DalHelper.GetCombos("Estadocivil");
            cbEstadoCivil.DataSource = dt;
            cbEstadoCivil.ValueMember = "Estado_civil";
            cbEstadoCivil.Text = "Todos";
        } // carregaCombo
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
        }// CarregaIniciais
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
        }// RetQdttipocadastro
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
        }// RetornaAniversariantes
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
        }// RetornaEventos
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
            catch (Exception)
            {
                MessageBox.Show("Não foi possivel carregar quantidade de crianças apresentadas!", "ATENÇÃO");
            }
        }// RetronaQtdNascimento

        private void btnIncluirDados_Click(object sender, EventArgs e)
        {
            if (!Valida("Incluir"))
            {
                //MessageBox.Show("Existem dados a serem preenchidos. * ", "Atenção");
                return;
            }

            try
            {
                string mat = txtDataNasc.Text;
                string DataBatismo;

                if (txtDataBatismo.Text == "  /  /")
                {
                    DataBatismo = "";
                }
                else
                {
                    DataBatismo = txtDataBatismo.Text;
                }

                Membro cli = new Membro();
                cli.Id = Convert.ToInt32(mat.Replace("/", ""));
                cli.Nome = txtNome.Text;
                cli.datanascimento = txtDataNasc.Text;
                cli.nmpai = txtNmPai.Text;
                cli.nmmae = txtNmMae.Text;
                cli.estadocivil = txtEstadoCivil.Text;
                cli.idade = txtIdade.Text;
                cli.profissao = txtProfissao.Text;
                cli.endereco = txtEndereco.Text;
                cli.numero = txtNumero.Text;
                cli.bairro = txtBairro.Text;
                cli.cidade = txtCidade.Text;
                cli.referencia = txtReferencia.Text;
                cli.cep = txtCep.Text.Replace("-", "");
                cli.telefone1 = txtTelefone1.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                cli.telefone2 = txtTelefone2.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                cli.databatismo = DataBatismo;
                cli.nmigreja = txtNmIgreja.Text;
                cli.nmpastor = txtNmPastor.Text;
                cli.tempofrequencia = txtTempoIgreja.Text;
                cli.cargo = txtCargo.Text;
                cli.funcao = txtFuncao.Text;
                cli.grupo = txtGrupo.Text;
                cli.sexo = strSexo;
                cli.tpcadastro = strTpCadastro;
                cli.status = "S";

                DalHelper.Add(cli);

                //ExibirDados(false);
                LimpaDados();
                //pnGrid.Enabled = true;
                rdFeminino.Checked = false;
                rdMasc.Checked = false;

                MessageBox.Show("Cadastramento realizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }// btnIncluirDados
        private bool Valida(string tp)
        {
            string strData;
            strData = txtDataNasc.Text;
            if (tp == "Incluir")
            {
                if (rdMembro.Checked == true)
                {
                    strTpCadastro = "Ficha de Membro";
                }
                else
                    if (rdVisitas.Checked == true)
                {
                    strTpCadastro = "Ficha de Visitas";
                }
                else
                    if (rdBatismo.Checked == true)
                {
                    strTpCadastro = "Ficha de Batismo";
                }
                else
                    if (rdRecebeJesus.Checked == true)
                {
                    strTpCadastro = "Recebeu Jesus";
                }
                else
                    if (rdVisitas.Checked == true)
                {
                    strTpCadastro = "Ficha de Visita";
                }
                else
                    if (rdTranferencia.Checked == true)
                {
                    strTpCadastro = "Ficha de Transferencia";
                }
                else
                {
                    MessageBox.Show("Selecione um tipo de Cadastro!", "Atenção");
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtNome.Text) && string.IsNullOrEmpty(txtDataNasc.Text) || txtDataNasc.Text == "  /  /")
            {
                MessageBox.Show("Verifique os campos nome e data de nascimento!", "Atenção");
                return false;
            }
            if (string.IsNullOrEmpty(txtNmMae.Text))
            {
                MessageBox.Show("Verifique o campo Nome Mãe!", "Atenção");
                return false;
            }
            if (rdMasc.Checked == true)
            {
                strSexo = "M";
            }
            if (rdFeminino.Checked == true)
            {
                strSexo = "F";
            }
            if (ValidaData.isDate(strData, ""))
            {
                MessageBox.Show("Verifique a data de nascimento!", "Atenção");
                return false;
            }
            if (string.IsNullOrEmpty(strSexo))
            {
                MessageBox.Show("Selecione o sexo!", "Atenção");
                return false;
            }
            if (string.IsNullOrEmpty(txtEndereco.Text) || string.IsNullOrEmpty(txtBairro.Text) || string.IsNullOrEmpty(txtCidade.Text) || string.IsNullOrEmpty(txtCep.Text) || string.IsNullOrEmpty(txtNumero.Text))
            {
                MessageBox.Show("Verificar os campos de endereço!", "Atenção");
                return false;
            }
            if (string.IsNullOrEmpty(txtTelefone1.Text) && string.IsNullOrEmpty(txtTelefone2.Text))
            {
                MessageBox.Show("Deve-se digitar ao menos um telefone de contato", "Atenção");
                return false;
            }
            if (string.IsNullOrEmpty(txtGrupo.Text) || string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Verificar os campos Cargo, Função e Grupo!", "Atenção");
                return false;
            }
            if (string.IsNullOrEmpty(txtEstadoCivil.Text))
            {
                MessageBox.Show("Selecione o estado civil!", "Atenção");
                return false;
            }
            return true;
        }// Valida
        //private void ExibirDados(bool pesquisa)
        //{
        //    string stid = txtMatPesquisa.Text;
        //    string stnm = txtNmPesquisa.Text;

        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt = DalHelper.GetMembro(pesquisa, stid, stnm);

        //        if (dt.Rows.Count == 0)
        //        {
        //            MessageBox.Show("Membro não encontrado!");
        //            return;
        //        }

        //        dgvDados.DataSource = dt;
        //        dgvDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //        dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //        DesativaFicha();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro : " + ex.Message);
        //    }
        //}// ExibirDados(pesquisa)
        private void LimpaDados()
        {
            txtMatricula.Text = "";
            txtNome.Text = "";
            txtDataNasc.Text = "";
            txtNmPai.Text = "";
            txtNmMae.Text = "";
            txtEstadoCivil.Text = "";
            txtIdade.Text = "";
            txtProfissao.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtReferencia.Text = "";
            txtCep.Text = "";
            txtTelefone1.Text = "";
            txtTelefone2.Text = "";
            txtDataBatismo.Text = "";
            txtNmIgreja.Text = "";
            txtNmPastor.Text = "";
            txtTempoIgreja.Text = "";
            txtGrupo.Text = "";
            txtCargo.Text = "";
            txtFuncao.Text = "";
            picFoto.Load("C:/Program IBNFU/Fotos/Sem Foto.jpg");
            picFoto.SizeMode = PictureBoxSizeMode.StretchImage;

            desabilitarBotoes();
        }// limpadados
        private void desabilitarBotoes()
        {
            //grpCad.Enabled = false;
            //btnAtualizarDados.Enabled = false;
            //btnExcluirDados.Enabled = false;
            //btnAtualizarDados.Visible = false;
            btnIncluirDados.Enabled = false;
            rdBatismo.Checked = false;
            rdRecebeJesus.Checked = false;
            rdMembro.Checked = false;
            rdVisitas.Checked = false;
        }//desabilitarBotoes

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaDados();
        }//BtnLimpar

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            btnIncluirDados.Enabled = true;
        }//txtNome_TextChanged

        private void btnFotografar_Click(object sender, EventArgs e)
        {
            Membro.nm = Convert.ToString(txtNome.Text);
            if (txtNome.Text == "")
            {
                MessageBox.Show("Você precisa digitar primeiro um nome");
                return;
            }
            else
            {
                frmFotografar frmfoto = new frmFotografar();
                frmfoto.ShowDialog();
                try
                {
                    picFoto.Load("C:/Program IBNFU/Fotos/" + txtNome.Text + ".jpg");
                    picFoto.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    MessageBox.Show("Foto não carregada.");
                    picFoto.Load("C:/Program IBNFU/Fotos/Sem Foto.jpg");
                    picFoto.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }//btnFotografar_Click

        private void dgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{

            //    DataGridViewRow row = dgvDados.Rows[e.RowIndex];
            //    txtMatricula.Text = row.Cells["Matrícula"].Value.ToString();
            //    txtNome.Text = row.Cells["Nome"].Value.ToString();
            //    txtDataNasc.Text = row.Cells["Dt_Nascimento"].Value.ToString();
            //    txtNmPai.Text = row.Cells["Nm_pai"].Value.ToString();
            //    txtNmMae.Text = row.Cells["Nm_mae"].Value.ToString();
            //    txtEstadoCivil.Text = row.Cells["Estado_civil"].Value.ToString();
            //    txtIdade.Text = row.Cells["Idade"].Value.ToString();
            //    txtProfissao.Text = row.Cells["Profissao"].Value.ToString();
            //    txtEndereco.Text = row.Cells["Endereco"].Value.ToString();
            //    txtNumero.Text = row.Cells["Numero"].Value.ToString();
            //    txtBairro.Text = row.Cells["Bairro"].Value.ToString();
            //    txtCidade.Text = row.Cells["Cidade"].Value.ToString();
            //    txtReferencia.Text = row.Cells["Referencia"].Value.ToString();
            //    txtCep.Text = row.Cells["Cep"].Value.ToString().Replace(" ", "");
            //    txtTelefone1.Text = row.Cells["Telefone1"].Value.ToString().Replace(" ", "");
            //    txtTelefone2.Text = row.Cells["Telefone2"].Value.ToString().Replace(" ", "");
            //    txtDataBatismo.Text = row.Cells["Dt_batismo"].Value.ToString();
            //    txtNmIgreja.Text = row.Cells["Nm_igreja"].Value.ToString();
            //    txtNmPastor.Text = row.Cells["Nm_pastor"].Value.ToString();
            //    txtTempoIgreja.Text = row.Cells["Tempo_freq_Igreja_local"].Value.ToString();
            //    txtGrupo.Text = row.Cells["Grupo"].Value.ToString();
            //    txtCargo.Text = row.Cells["Cargo"].Value.ToString();
            //    txtFuncao.Text = row.Cells["Funcao"].Value.ToString();

            //    string s = row.Cells["Sexo"].Value.ToString();

            //    if (s == "M")
            //    {
            //        rdMasc.Checked = true;
            //    }
            //    if (s == "F")
            //    {
            //        rdFeminino.Checked = true;
            //    }
            //   // try
            //   // {
            //   //     picFoto.Load("C:/Program IBNFU/Fotos/" + txtNome.Text + ".jpg");
            //   //     picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            //   // }
            //   // catch
            //   // {
            //   //     picFoto.Load("C:/Program IBNFU/Fotos/Sem Foto.jpg");
            //   //     picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            //   // }
            //   //
            //}
        }//dgvDados_CellContentClick

        private void btnLocalizarDados_Click(object sender, EventArgs e)
        {
            if (txtMatPesquisa.Text == "" && txtNmPesquisa.Text == "")
            {
                MessageBox.Show("Digite a matrícula ou o nome do membro.");
            }
            else
            {
                ExibirDados(true);
                txtMatPesquisa.Text = "";
                txtNmPesquisa.Text = "";
            }
            
        }//BtnLocalizardados
        private void ExibirDados(bool pesquisa)
        {
            string stid = txtMatPesquisa.Text;
            string stnm = txtNmPesquisa.Text;

            try
            {
                DataTable dt = new DataTable();
                dt = DalHelper.GetMembro(pesquisa, stid, stnm);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Membro não encontrado!");
                    return;
                }

                dgvDados.DataSource = dt;
                dgvDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //DesativaFicha();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }//ExibirDados

        private void btnExibirDados_Click(object sender, EventArgs e)
        {
            ExibirDados(false);
        }//btnExibirDados_Click

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.Cargo = cbCargo.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //DesativaFicha();
        }//cbCargo

        private void cbEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.EstadoCivil = cbEstadoCivil.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //DesativaFicha();
        }//cbEstadoCivil

        private void cbTipoCadastro_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.TpCadastro = cbTipoCadastro.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //DesativaFicha();
        }//cbTipoCadastro

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.Grupo = cbGrupo.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //DesativaFicha();
        }//cbGrupo

        private void cbFuncao_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.Funcao = cbFuncao.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //DesativaFicha();

        }//cbFuncao

        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.Sexo = cbSexo.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //DesativaFicha();
        }//cbSexo

        private void tabPesquisar_Load(object sender, EventArgs e)
        {
            
        }//tabPesquisaLoad

        private void rdMembro_CheckedChanged(object sender, EventArgs e)
        {
            grpCad.Text = "FICHA DE MEMBRO";
            grpCad.Enabled = true;
            //btnIncluirDados.Enabled = true;
            grpCad.BackColor = Color.SteelBlue;
            //pnMenuCadastro.BackColor = Color.SteelBlue;
            grpCad.BackColor = Color.SteelBlue;
            //btnAtualizarDados.Visible = false;
            btnIncluirDados.Visible = true;
            //pnGrid.Enabled = false;
        }//rdMembro_CheckedChanged 

        private void rdVisitas_CheckedChanged(object sender, EventArgs e)
        {
            grpCad.Text = "FICHA DE VISITANTES";
            grpCad.Enabled = true;
            btnIncluirDados.Enabled = true;
            grpCad.BackColor = Color.Firebrick;
            //pnMenuCadastro.BackColor = Color.Firebrick;
            //pnCadastro.BackColor = Color.Firebrick;
            //btnAtualizarDados.Visible = false;
            //btnIncluirDados.Visible = true;
            //pnGrid.Enabled = false;
        } // rdVisitas 

        private void rdRecebeJesus_CheckedChanged(object sender, EventArgs e)
        {
            grpCad.Text = "RECEBEU A JESUS";
            grpCad.Enabled = true;
            btnIncluirDados.Enabled = true;
            grpCad.BackColor = Color.DarkSeaGreen;
        }// rdRecebeJesus

        private void rdBatismo_CheckedChanged(object sender, EventArgs e)
        {
            grpCad.Text = "FICHA DE BATISMO";
            grpCad.Enabled = true;
            btnIncluirDados.Enabled = true;
            grpCad.BackColor = Color.DarkOrange;
        }// rdBatismo

        private void rdTranferencia_CheckedChanged(object sender, EventArgs e)
        {
            grpCad.Text = "RECEBEU A JESUS";
            grpCad.Enabled = true;
            btnIncluirDados.Enabled = true;
            grpCad.BackColor = Color.DarkSeaGreen;
        }// rdTranferencia_CheckedChanged

        private void button1_Click(object sender, EventArgs e)
        {
            txtNmPai.Text = "";
            txtNmMae.Text = "";
            rdMembroLocalNao.Checked = false;
            rdMembroLocalSim.Checked = false;
            txtDataapresentacao.Text = "";
            txtNmCrianca.Text = "";
            txtDtNascimento.Text = "";
            txtNmPastor.Text = "";
            rdbFemin.Checked = false;
            rdbMasc.Checked = false;

        }// button1_Click

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
            }
            else
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

            }else
            if (rdbMasc.Checked == false && rdbFemin.Checked == false)
            {
                MessageBox.Show("Favor, selecione o sexo da criança.");
                return;
            }
            else
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
            }

        }// btnCadNascimento_Click

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
                Cursor = Cursors.Default;
                return;
            }

            string dt_ini, dt_fim, Qtd;
            lblQtd.Text = "Total: ";

            dt_ini = txtDt_inicio.Text;
            dt_fim = txtDt_fim.Text;

            DataTable dt = new DataTable();
            dt = DalHelper.GetRelatorio(tp, dt_ini, dt_fim);

            Qtd = Convert.ToString(dt.Rows.Count);

            lblQtd.Text = lblQtd.Text + Qtd;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Não houve dados para esse relatório.");
                Cursor = Cursors.Default;
                return;
            }

            dgvRelDados.DataSource = dt;
            dgvRelDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            btnGerarRelatorio.Enabled = true;

            Cursor = Cursors.Default;
        }// btnPesquisa_Click

        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            rdRelMembro.Checked = false;
            rdNascimentos.Checked = false;
            rdRelCasamento.Checked = false;
            dgvRelDados.DataSource = "";
            btnGerarRelatorio.Enabled = false;
            pgb1.Value = 0;
            //Qtd = "";
            lblQtd.Text = "";
        }// btnLimparFiltro_Click

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
           GeraExcel();
        }// btnGerarRelatorio_Click

        private void GeraExcel()
        {
            Cursor = Cursors.WaitCursor;

            Excel.Application XcelApp = new Excel.Application();

            if (dgvRelDados.Rows.Count > 0)
            {
               // lblPgb1Status.Text = "Iniciando...";
                int cont = 1;

                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgvRelDados.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvRelDados.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < dgvRelDados.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dgvRelDados.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgvRelDados.Rows[i].Cells[j].Value.ToString();

                            if (cont != dgvRelDados.Rows.Count)
                            {
                                pgb1.Value = cont;
                               // lblPgb1Status.Text = cont + "%";
                                cont++;
                            }

                        }
                    }
                    pgb1.Value = 100;
                    //lblPgb1Status.Text = 100 + "%";

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
        }// GeraExcel

    }// fecha frmControles
}// fecha namespace
