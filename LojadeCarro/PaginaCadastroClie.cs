using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Biblioteca;
using static LojadeCarro.ConectaWebcam;
using System.IO;

namespace LojadeCarro
{
    public partial class PaginaCadastroClie : Form
    {

        public PaginaCadastroClie()
        {
            InitializeComponent();
        }
        bool tiraFoto = true;

        public object ConectaWebCam { get; private set; }

        public void LocalizarCEP()
        {
            using (var ws = new WSCEP.AtendeClienteClient())
            {
                try
                {
                    var resultado = ws.consultaCEP(mskCEP.Text);
                    cmbCidade.Text = resultado.cidade;
                    cmbEstado.Text = resultado.uf;
                    txtRua.Text = resultado.end;
                    txtBairro.Text = resultado.bairro;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }

            }
        }
        public void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tiraFoto == true)
                {
                    //procurar a WEBCAM
                    ConectaWebcan.procurarDispositivo();
                    //ligar webcam
                    ConectaWebcan.verificarWebCamLigada();
                    tiraFoto = false;
                    pcbFotoCliente.Text = "Tirar foto";
                }
                else
                {
                    //Tirar a Foto
                    ConectaWebcan.tiraFoto();
                    ConectaWebcan.tirarFotoSalvarBD();
                    tiraFoto = true;
                    pcbFotoCliente.Text = "Ligar Webcam";
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public void label12_Click(object sender, EventArgs e)
        {
            
        }
            private void Btn_Cadastrar_Click(object sender, EventArgs e)
            {
            {
                if (txtNome.Text.Trim().Length == 0)
                {
                    erpPreencherCampos.SetError(txtNome, "Preencha o campo nome");
                    return;
                }
                else
                {
                    erpPreencherCampos.SetError(txtNome, "");
                }
                if (txtTel.Text.Trim().Length == 0)
                {
                    erpPreencherCampos.SetError(txtTel, "Preencha o campo celular");
                    return;
                }
                else
                {
                    erpPreencherCampos.SetError(txtTel, "");
                }
                try
                {
                    Conexao.conectar();


                    string sql = @"INSERT INTO carr.Cliente 
                        Values
                        (NOME = @NOME,
                        EMAIL = @EMAIL,
                        TEL = @TEL,
                        RG = @RG,
                        CPF = @CPF,
                        CNJP = @CNPJ , 
                        DATANAS = @DATAN,
                        RUA = @RUA, 
                        CEP = @CEP,
                        COMPLEMENTO = @COMPLEMENTO,
                        BAIRRO = @BAIRRO,
                        CIDADE = @CIDADE)";

                    SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

                    cmd.Parameters.AddWithValue("NOME", txtNome.Text);
                    cmd.Parameters.AddWithValue("EMAIL", txtEmail.Text);
                    cmd.Parameters.AddWithValue("TEL", txtTel.Text);
                    cmd.Parameters.AddWithValue("RG", txtRG.Text);
                    cmd.Parameters.AddWithValue("CPF", txtCPF.Text);
                    cmd.Parameters.AddWithValue("CNPJ", txtCNPJ.Text);
                    cmd.Parameters.AddWithValue("DATANAS", txtDataN.Text);
                    cmd.Parameters.AddWithValue("RUA", txtRua.Text);
                    cmd.Parameters.AddWithValue("CEP", mskCEP.Text);
                    cmd.Parameters.AddWithValue("COMPLEMENTO", txtComp.Text);
                    cmd.Parameters.AddWithValue("BAIRRO", txtBairro.Text);
                    cmd.Parameters.AddWithValue("CIDADE", cmbCidade.Text);
                    SqlParameter fotoParam = new SqlParameter("Foto", SqlDbType.Image);
                    if (ConectaWebcam.imagem != null)
                    {
                        fotoParam.Value = ConectaWebcam.imagem;
                    }
                    else
                    {
                        fotoParam.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(fotoParam);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente cadastrado com sucesso!");

                    Conexao.fechar();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
                finally
                {
                    Conexao.fechar();
                }
                Utils.LimparCampos(this);
            }
        }

            private void pEsquisarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ///Clientes.codigo = "";
                ///paginaEstoque pesq = new paginaEstoque();
                ///pesq.showdialog();
                ///
                /// if (Clientes.codigo != "")
                /// {
                ///     
                /*
                 txtNome.Text = Clientes.nome;
                 txtEmail.Text = Clientes.email;
                 mskTelefone.Text = Clientes.tel;
                 mskCEP.Text = Clientes.cep;
                 cmbEstado.Text = Clientes.estado;
                 cmbCidade.Text = Clientes.cidade;
                 txtRua.Text = Clientes.rua;
                 txtNumero.Text = Clientes.numero;
                 txtComplemento.Text = Clientes.comp;
                 txtBairro.Text = Clientes.bairro;]
                 if (Clientes.foto != null)
                {
                    MemoryStream ms = new MemoryStream(Clientes.foto);
                    Image img = Image.FromStream(ms);
                    pcbFoto.Image = img;
                }

                btnAlterar.enable = true;
                btnExluir.enable  = true;

                btnCadastrar.Enable = False;

                 */
                /// }

            }

            private void label10_Click(object sender, EventArgs e)
            {

            }

            private void label18_Click(object sender, EventArgs e)
            {

            }

            private void cmbCidade_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {

            try
            {
                Conexao.conectar();
                string sql = @"UPDATE carr.Cliente SET 
                NOME = @NOME,
                EMAIL = @EMAIL,
                TEL = @TEL,
                RG = @RG,
                CPF = @CPF,
                CNJP = @CNPJ , 
                DATANAS = @DATAN,
                RUA = @RUA, 
                CEP = @CEP,
                COMPLEMENTO = @COMPLEMENTO,
                BAIRRO = @BAIRRO,
                CIDADE = @CIDADE";

                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
                cmd.Parameters.AddWithValue("CODIGO", Clientes.Clie_ID);
                cmd.Parameters.AddWithValue("NOME", txtNome.Text);
                cmd.Parameters.AddWithValue("EMAIL", txtEmail.Text);
                cmd.Parameters.AddWithValue("TEL", txtTel.Text);
                cmd.Parameters.AddWithValue("RG", txtRG.Text);
                cmd.Parameters.AddWithValue("CPF", txtCPF.Text);
                cmd.Parameters.AddWithValue("CNPJ", txtCNPJ.Text);
                cmd.Parameters.AddWithValue("DATANAS", txtDataN.Text);
                cmd.Parameters.AddWithValue("RUA", txtRua.Text);
                cmd.Parameters.AddWithValue("CEP", mskCEP.Text);
                cmd.Parameters.AddWithValue("COMPLEMENTO", txtComp.Text);
                cmd.Parameters.AddWithValue("BAIRRO", txtBairro.Text);
                cmd.Parameters.AddWithValue("CIDADE", cmbCidade.Text);

                SqlParameter fotoParam =
                           new SqlParameter("foto", SqlDbType.Image);
                if (ConectaWebcan.imagem != null)
                {
                    fotoParam.Value = ConectaWebcan.imagem;
                }
                else
                {
                    fotoParam.Value = DBNull.Value;
                }
                cmd.Parameters.Add(fotoParam);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cliente cadastrado com sucesso");

                Conexao.fechar();

                Utils.LimparCampos(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.Message);
            }
            finally
                    {
                Conexao.fechar();
                    } 
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
            {
            Clientes.Clie_ID = "";
            paginaEstoque pesq = new paginaEstoque();
            pesq.ShowDialog();
            if (Clientes.Clie_ID != "")
            {
                txtNome.Text = Clientes.Clie_NM;
                txtEmail.Text = Clientes.Clie_Email;
                txtTel.Text = Clientes.Clie_Tel;
                mskCEP.Text = Clientes.Clie_CEP;
                cmbEstado.Text = Clientes.Clie_Estado;
                cmbCidade.Text = Clientes.Clie_Cida;
                txtRua.Text = Clientes.Clie_Rua;
                txtNum.Text = Clientes.Clie_N;
                txtComp.Text = Clientes.Clie_Complemento;
                txtBairro.Text = Clientes.Clie_Bairro;
                if (Clientes.foto != null)
                {
                    MemoryStream ms = new MemoryStream(Clientes.foto);
                    Image img = Image.FromStream(ms);
                    pcbFotoCliente.Image = img;
                }

                //Habilitar os botões Alterar e Excluir
                btn_Alterar.Enabled = true;
                Btn_Deletar.Enabled = true;
                //Desabilite o botão Cadastrar
                Btn_Cadastrar.Enabled = false;
            }
        }

        private void Btn_Deletar_Click(object sender, EventArgs e)
            {
            try
            {
                Conexao.conectar();
                string sql = @"Delete from carr.Clientes where Codigo = @Codigo";
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
                cmd.Parameters.AddWithValue("Codigo", Clientes.Clie_ID);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cliente excluído com sucesso!");

                Utils.LimparCampos(this);
                txtNome.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Conexao.fechar();
            }
        }

            private void maskCEP_Leave(object sender, EventArgs e)
            {
                LocalizarCEP();
            }

            private void pictureBox3_Click(object sender, EventArgs e)
            {
                Close();
            }

            private void label13_Click(object sender, EventArgs e)
            {
                
            }

        private void mskCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
    }


