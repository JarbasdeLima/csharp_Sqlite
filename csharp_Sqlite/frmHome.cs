using System;
using System.Data;
using System.Windows.Forms;
using csharp_Sqlite.Models;
using System.Drawing;

namespace csharp_Sqlite
{
    public partial class frmHome : Form
    {
        string strSexo = "";
        string strTpCadastro = "";
        string tp = "Incluir";

        public frmHome()
        {
            InitializeComponent();
        }

        private void btnCriarBancoDados_Click(object sender, EventArgs e)
        {
            try
            {
                DalHelper.CriarBancoSQLite();
                btnCriarBancoDados.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }
        private void btnCriarTabela_Click(object sender, EventArgs e)
        {
            try
            {
                DalHelper.CriarTabelaSQlite();
                btnCriarTabela.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void btnExibirDados_Click(object sender, EventArgs e)
        {
            ExibirDados(false);
            LimpaDados();
            DesativaFicha();
            pnGrid.Enabled = true;
        }
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
                DesativaFicha();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void DesativaFicha()
        {
            rdMembro.Checked = false;
            rdVisitas.Checked = false;
            rdRecebeJesus.Checked = false;
            rdBatismo.Checked = false;
        }
        private void btnIncluirDados_Click(object sender, EventArgs e)
        {
            if (!Valida("Incluir"))
            {
                MessageBox.Show("Existem dados a serem preenchidos. * ", "Atenção");
                return;
            }

            try
            {
                string mat = txtDataNasc.Text;
                string DataBatismo;

                if (txtDataBatismo.Text == "  /  /")
                {
                    DataBatismo = "";
                }else
                {
                    DataBatismo = txtDataBatismo.Text;
                }
                
                Membro cli = new Membro();
                cli.Id = Convert.ToInt32(mat.Replace("/",""));
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
                cli.telefone1 = txtTelefone1.Text.Replace("(","").Replace(")","").Replace("-","");
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

                ExibirDados(false);
                LimpaDados();
                pnGrid.Enabled = true;
                rdFeminino.Checked = false;
                rdMasc.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void btnAtualizarDados_Click(object sender, EventArgs e)
        {
            if (!Valida("Atualizar"))
            {
                //MessageBox.Show("Informe os dados cliente a atualizar", "Atenção");
                return;
            }

            try
            {

                Membro cli = new Membro();
                cli.Id = Convert.ToInt32(txtMatricula.Text);
                cli.Nome = txtNome.Text;
                cli.datanascimento = txtDataNasc.Text;
                cli.nmpai = txtNmPai.Text;
                cli.nmmae           = txtNmMae.Text;
                cli.estadocivil = txtEstadoCivil.Text;
                cli.idade = txtIdade.Text;
                cli.profissao = txtProfissao.Text;
                cli.endereco = txtEndereco.Text;
                cli.numero = txtNumero.Text;
                cli.bairro = txtBairro.Text;
                cli.cidade          = txtCidade.Text;
                cli.referencia      = txtReferencia.Text;
                cli.cep = txtCep.Text.Replace("-", "");
                cli.telefone1 = txtTelefone1.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                cli.telefone2 = txtTelefone2.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                cli.databatismo     = txtDataBatismo.Text;
                cli.nmigreja        = txtNmIgreja.Text;
                cli.nmpastor        = txtNmPastor.Text;
                cli.tempofrequencia = txtTempoIgreja.Text;
                cli.cargo           = txtCargo.Text;
                cli.funcao          = txtFuncao.Text;
                cli.grupo           = txtGrupo.Text;
                cli.sexo = strSexo;
                cli.tpcadastro = strTpCadastro;
                //cli.log = strlog;

                DalHelper.Update(cli);
                ExibirDados(false);
                MessageBox.Show("Dados atualizados com sucesso!");
                LimpaDados();
                desabilitarBotoes();
                pnGrid.Enabled = true;
                rdFeminino.Checked = false;
                rdMasc.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void btnExcluirDados_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("Selecione um nome na lista para inativar!", "Atenção");
                return;
            }

            try
            {
                int codigo = Convert.ToInt32(txtMatricula.Text);
                string strTp = "N";

                DalHelper.Delete(codigo, strTp);
                ExibirDados(false);
                MessageBox.Show("O membro foi desativado, para ativa-lo, faça uma pesquisa!", "Atenção");
                LimpaDados();
                desabilitarBotoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            const string mensagem = "Deseja Sair ?";
            const string titulo = "Sair";
            var resultado = MessageBox.Show(mensagem, titulo,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Dispose();
            }
        }
        private bool Valida(string tp)
        {
            string strData;
            strData = txtDataNasc.Text;

            if (rdMasc.Checked == true) {
                strSexo = "M";
            }
            if (rdFeminino.Checked == true)
            {
                strSexo = "F";
            }
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
            if (ValidaData.isDate(strData,"")){

                MessageBox.Show("Verifique a data de nascimento!", "Atenção");
                return false;
            }

            if (string.IsNullOrEmpty(txtNome.Text) && string.IsNullOrEmpty(txtDataNasc.Text) || txtDataNasc.Text == "  /  /")
            {
                MessageBox.Show("Verifique os campos nome e data de nascimento!", "Atenção");
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
        }
        
        private void LimpaDados()
        {
            txtMatricula.Text = "";
            txtNome.Text        = "";
            txtDataNasc.Text    = "";
            txtNmPai.Text       = "";
            txtNmMae.Text       = "";
            txtEstadoCivil.Text = "";
            txtIdade.Text       = "";
            txtProfissao.Text   = "";
            txtEndereco.Text    = "";
            txtNumero.Text      = "";
            txtBairro.Text      = "";
            txtCidade.Text      = "";
            txtReferencia.Text  = "";
            txtCep.Text         = "";
            txtTelefone1.Text   = "";
            txtTelefone2.Text   = "";
            txtDataBatismo.Text = "";
            txtNmIgreja.Text    = "";
            txtNmPastor.Text    = "";
            txtTempoIgreja.Text = "";
            txtGrupo.Text = "";
            txtCargo.Text = "";
            txtFuncao.Text = "";
            picFoto.Load("C:/Program IBNFU/Fotos/Sem Foto.jpg");
            picFoto.SizeMode = PictureBoxSizeMode.StretchImage;

            desabilitarBotoes();
        }

        private void dgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgvDados.Rows[e.RowIndex];
                txtMatricula.Text   = row.Cells["Matrícula"].Value.ToString();
                txtNome.Text        = row.Cells["Nome"].Value.ToString();
                txtDataNasc.Text    = row.Cells["Dt_Nascimento"].Value.ToString();
                txtNmPai.Text       = row.Cells["Nm_pai"].Value.ToString();
                txtNmMae.Text       = row.Cells["Nm_mae"].Value.ToString();
                txtEstadoCivil.Text = row.Cells["Estado_civil"].Value.ToString();
                txtIdade.Text       = row.Cells["Idade"].Value.ToString();
                txtProfissao.Text   = row.Cells["Profissao"].Value.ToString();
                txtEndereco.Text    = row.Cells["Endereco"].Value.ToString();
                txtNumero.Text      = row.Cells["Numero"].Value.ToString();
                txtBairro.Text      = row.Cells["Bairro"].Value.ToString();
                txtCidade.Text      = row.Cells["Cidade"].Value.ToString();
                txtReferencia.Text  = row.Cells["Referencia"].Value.ToString();
                txtCep.Text         = row.Cells["Cep"].Value.ToString().Replace(" ", "");
                txtTelefone1.Text   = row.Cells["Telefone1"].Value.ToString().Replace(" ","");
                txtTelefone2.Text   = row.Cells["Telefone2"].Value.ToString().Replace(" ", "");
                txtDataBatismo.Text = row.Cells["Dt_batismo"].Value.ToString();
                txtNmIgreja.Text    = row.Cells["Nm_igreja"].Value.ToString();
                txtNmPastor.Text    = row.Cells["Nm_pastor"].Value.ToString();
                txtTempoIgreja.Text = row.Cells["Tempo_freq_Igreja_local"].Value.ToString();
                txtGrupo.Text       = row.Cells["Grupo"].Value.ToString();
                txtCargo.Text       = row.Cells["Cargo"].Value.ToString();
                txtFuncao.Text      = row.Cells["Funcao"].Value.ToString();

                string s = row.Cells["Sexo"].Value.ToString();

                if (s == "M")
                {
                    rdMasc.Checked = true;
                }
                if (s == "F")
                {
                    rdFeminino.Checked = true;
                }

                habilitarBotoes();
                btnIncluirDados.Enabled = false;
                //pnPesquisa.Visible = true;
                btnAtualizarDados.Visible = true;
                btnIncluirDados.Visible = false;
                try
                {
                    picFoto.Load("C:/Program IBNFU/Fotos/" + txtNome.Text + ".jpg");
                    picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    picFoto.Load("C:/Program IBNFU/Fotos/Sem Foto.jpg");
                    picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdMembro_CheckedChanged(object sender, EventArgs e)
        {
            grpCad.Text = "FICHA DE MEMBRO";
            grpCad.Enabled = true;
            btnIncluirDados.Enabled = true;
            grpCad.BackColor = Color.SteelBlue;
            pnMenuCadastro.BackColor = Color.SteelBlue;
            pnCadastro.BackColor = Color.SteelBlue;
            btnAtualizarDados.Visible = false;
            btnIncluirDados.Visible = true;
            pnGrid.Enabled = false;
        }

        private void rdVisitas_CheckedChanged(object sender, EventArgs e)
        {
            grpCad.Text = "FICHA DE VISITANTES";
            grpCad.Enabled = true;
            btnIncluirDados.Enabled = true;
            grpCad.BackColor = Color.Firebrick;
            pnMenuCadastro.BackColor = Color.Firebrick;
            pnCadastro.BackColor = Color.Firebrick;
            btnAtualizarDados.Visible = false;
            btnIncluirDados.Visible = true;
            pnGrid.Enabled = false;
        }

        private void rdBatismo_CheckedChanged(object sender, EventArgs e)
        {
            grpCad.Text = "FICHA DE BATISMO";
            grpCad.Enabled = true;
            btnIncluirDados.Enabled = true;
            grpCad.BackColor = Color.DarkOrange;
            pnMenuCadastro.BackColor = Color.DarkOrange;
            pnCadastro.BackColor = Color.DarkOrange;
            btnAtualizarDados.Visible = false;
            btnIncluirDados.Visible = true;
            pnGrid.Enabled = false;
        }

        private void rdRecebeJesus_CheckedChanged(object sender, EventArgs e)
        {
            grpCad.Text = "RECEBEU A JESUS";
            grpCad.Enabled = true;
            btnIncluirDados.Enabled = true;
            grpCad.BackColor = Color.DarkSeaGreen;
            pnMenuCadastro.BackColor = Color.DarkSeaGreen;
            pnCadastro.BackColor = Color.DarkSeaGreen;
            btnAtualizarDados.Visible = false;
            btnIncluirDados.Visible = true;
            pnGrid.Enabled = false;
        }
        private void habilitarBotoes()
        {
            grpCad.Enabled        = true;
            btnAtualizarDados.Enabled = true;
            btnExcluirDados.Enabled   = true;
        }
        private void desabilitarBotoes()
        {
            grpCad.Enabled        = false;
            btnAtualizarDados.Enabled = false;
            btnExcluirDados.Enabled   = false;
            btnAtualizarDados.Visible = false;
            btnIncluirDados.Visible = false;
            rdBatismo.Checked     = false;
            rdRecebeJesus.Checked = false;
            rdMembro.Checked      = false;
            rdVisitas.Checked     = false;
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            CarregaCombo();
            desabilitarBotoes();
            //pnPesquisa.Visible = false;
            ExibirDados(false);
            btnAtualizarDados.Visible = false;
            btnIncluirDados.Visible   = false;
        }
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
        }

        private void btnLocalizarDados_Click(object sender, EventArgs e)
        {
            // panel2
            //if (pnPesquisa.Visible == false)
            if (panel2.Visible == false)
            {
                //pnPesquisa.Visible = true;
                panel2.Visible = true;
                MessageBox.Show("Digite a matrícula ou o nome do membro.");
                //pnPesquisa.Visible = true;
                panel2.Visible = true;
                grpCad.Enabled = false;
            }
            else
            {
                ExibirDados(true);
                txtMatPesquisa.Text = "";
                txtNmPesquisa.Text = "";
                //pnPesquisa.Visible = false;
                LimpaDados();
            }
            pnGrid.Enabled = true;
        }

        private void btAtivarMembro_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("Selecione um nome na lista para ativar!", "Atenção");
                return;
            }

            try
            {
                int codigo = Convert.ToInt32(txtMatricula.Text);
                string strTp = "S";

                DalHelper.Delete(codigo, strTp);
                ExibirDados(false);
                MessageBox.Show("O membro foi ativado!", "Atenção");
                LimpaDados();
                desabilitarBotoes();
                picFoto.Load("C:\\Program IBNFU\\Fotos\\Sem Foto.jpg");
                //picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaDados();
            pnGrid.Enabled = true;
            CarregaCombo();
        }

        private void btnFotografar_Click(object sender, EventArgs e)
        {
            Membro.nm = Convert.ToString(txtNome.Text);
            if(txtNome.Text == "")
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

        }

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.Cargo = cbCargo.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DesativaFicha();
        }

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.Grupo = cbGrupo.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DesativaFicha();
        }

        private void cbFuncao_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.Funcao = cbFuncao.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DesativaFicha();
        }

        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.Sexo = cbSexo.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DesativaFicha();
        }

        private void cbTipoCadastro_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.TpCadastro = cbTipoCadastro.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DesativaFicha();
        }

        private void cbEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CarregaDadosBD bd = new CarregaDadosBD();
            bd.EstadoCivil = cbEstadoCivil.Text;

            dt = DalHelper.GetDadosFiltro(bd);

            dgvDados.DataSource = dt;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DesativaFicha();
        }

        private void txtNmMae_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdTranferencia_CheckedChanged(object sender, EventArgs e)
        {
            grpCad.Text = "FICHA DE TRANFERENCIA";
            grpCad.Enabled = true;
            btnIncluirDados.Enabled = true;
            grpCad.BackColor = Color.DarkSeaGreen;
            pnMenuCadastro.BackColor = Color.DarkSeaGreen;
            pnCadastro.BackColor = Color.DarkSeaGreen;
            btnAtualizarDados.Visible = false;
            btnIncluirDados.Visible = true;
            pnGrid.Enabled = false;
        }

        private void grpCad_Enter(object sender, EventArgs e)
        {

        }
    }
}
