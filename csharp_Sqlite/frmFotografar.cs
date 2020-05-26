using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;
using csharp_Sqlite.Models;
using System.IO;

namespace csharp_Sqlite
{
    public partial class frmFotografar : Form
    {
        public DirectX.Capture.Filter Camera;
        public DirectX.Capture.Capture CaptureInfo;
        public DirectX.Capture.Filters CamContainer;
        Image capturaImagem;
        public string caminhoImagemSalva = null;

        public frmFotografar()
        {
            InitializeComponent();
        }
        public void AtualizaImagem(PictureBox frame)
        {
            try
            {
                capturaImagem = frame.Image;
                picImagem.Image = capturaImagem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
        }
        private void btnCaptura_Click(object sender, EventArgs e)
        {
            try
            {
                CaptureInfo.CaptureFrame();
                btnSalvar.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Serviço interrompido. Verifique se a câmera está conectada.");
                MessageBox.Show("Tente desconectar e conectar novamente a câmera.");
                MessageBox.Show("Se ainda apresentar problemas comunique o administrador do sistema.");
            }
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            // var fileContent = string.Empty;
            // var filePath = string.Empty;
            //
            // using (OpenFileDialog openFileDialog = new OpenFileDialog())
            // {
            //     openFileDialog.InitialDirectory = "c:\\";
            //     openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            //     openFileDialog.FilterIndex = 2;
            //     openFileDialog.RestoreDirectory = true;
            //     openFileDialog.ShowDialog();
            //     filePath = openFileDialog.FileName;
            //
            //     //if ( == DialogResult.OK)
            //     //{
            //     //Get the path of specified file
            //     //filePath = openFileDialog.FileName;
            //     //Read the contents of the file into a stream
            //     //var fileStream = openFileDialog.OpenFile();
            //     //using (StreamReader reader = new StreamReader(fileStream))
            //     //{
            //     //    fileContent = reader.ReadToEnd();
            //     //}
            //     //}
            // }

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            
            string nome = "";
            nome = Membro.nm;

            if (nome == "")
            {
                MessageBox.Show("Você precisa digitar primeiro um nome");
                Dispose();
            }
            try
            {
                caminhoImagemSalva = @"C:\Program IBNFU\Fotos\" + nome+ ".jpg";
                picImagem.Image.Save(caminhoImagemSalva, ImageFormat.Jpeg);
                MessageBox.Show("Imagem salva com sucesso");
                CaptureInfo.DisposeCapture();

            }
            catch
            {
               // caminhoImagemSalva = @"C:\Program IBNFU\Fotos\Sem Foto.jpg";
               // picImagem.Image.Save(caminhoImagemSalva, ImageFormat.Jpeg);
                MessageBox.Show("Foto não carregada.");
                CaptureInfo.DisposeCapture();
            }

            Dispose();
        }

        private void frmFotografar_Load(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;

            CamContainer = new DirectX.Capture.Filters();
            try
            {
                int no_of_cam = CamContainer.VideoInputDevices.Count;

                for (int i = 0; i < no_of_cam; i++)
                {
                    try
                    {
                        // obtém o dispositivo de entrada do vídeo
                        Camera = CamContainer.VideoInputDevices[i];

                        // inicializa a Captura usando o dispositivo
                        CaptureInfo = new DirectX.Capture.Capture(Camera, null);

                        // Define a janela de visualização do vídeo
                        CaptureInfo.PreviewWindow = picWebCam;

                        // Capturando o tratamento de evento
                        CaptureInfo.FrameCaptureComplete += AtualizaImagem;

                        // Captura o frame do dispositivo

                        CaptureInfo.CaptureFrame();

                        // Se o dispositivo foi encontrado e inicializado então sai sem checar o resto
                        break;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro interno. Tente novamente!");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            const string mensagem = "Deseja Encerrar ?";
            const string titulo = "Encerrar";
            var resultado = MessageBox.Show(mensagem, titulo,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                CaptureInfo.DisposeCapture();
                //Application.Exit();
                Dispose();
            }
        }
    }
}
