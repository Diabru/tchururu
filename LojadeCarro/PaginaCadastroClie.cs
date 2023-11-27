using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojadeCarro
{
    public partial class PaginaCadastroClie : Form
    {
        public PaginaCadastroClie()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Cadastrar_Click(object sender, EventArgs e)
        {

        }

        private void pEsquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///Leitores.codigo = "";
            ///paginaEstoque pesq = new paginaEstoque();
            ///pesq.showdialog();
            ///
            /// if (leitores.codigo != "")
            /// {
            ///     
            /*
             txtNome.Text = leitores.nome;
             txtEmail.Text = leitores.email;
             mskTelefone.Text = leitores.tel;
             mskCEP.Text = leitores.cep;
             cmbEstado.Text = leitores.estado;
             cmbCidade.Text = leitores.cidade;
             txtRua.Text = leitores.rua;
             txtNumero.Text = leitores.numero;
             txtComplemento.Text = leitores.comp;
             txtBairro.Text = leitores.bairro;]
             if (leitores.foto != null)
            {
                MemoryStream ms = new MemoryStream(leitores.foto);
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

            /*
            try
            {
                conexao.conectar();
                    string sql = @"UPDATE LEITORES SET 
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

            sqlcommand cmd = new sqlCommand(sql,conexao.conn);
            cmd.parameters.addwithvalues("CODIGO",leitores.codigo);
            cmd.parameters.addwithvalues("NOME", txtNome.text);
            cmd.parameters.addwithvalues("EMAIL", txtEmail.text);
            cmd.parameters.addwithvalues("TEL", txtTel.text);
            cmd.parameters.addwithvalues("RG", txtRG.text);
            cmd.parameters.addwithvalues("CPF", txtCPF.text);
            cmd.parameters.addwithvalues("CNPJ", txtCNPJ.text);
            cmd.parameters.addwithvalues("DATANAS", txtDataN.text);
            cmd.parameters.addwithvalues("RUA", txtRua.text);
            cmd.parameters.addwithvalues("CEP", txtCEP.text);
            cmd.parameters.addwithvalues("COMPLEMENTO", txtComp.text);
            cmd.parameters.addwithvalues("BAIRRO", txtBairro.text);
            cmd.parameters.addwithvalues("CIDADE", cmbCidade.text);
           
                sqlParameter fotoParam = new sqlParameter("foto", sqldbtype.image);
                
            if(conectaWebCam.image != null)
            {
                fotoparam.value = ConectaWebCam.image;
            }
            else
            {
                fotoParam.value = DBNull.Value;
            }
            cmd.parameters.add(fotoparam);

            }
            catch (Exception)
            {
                messagebox.show("Erro: " + ex.message);
            }  
            finaly
            {
                conexao.fechar();
            }
             */
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Btn_Deletar_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                conexao.conectar();
                string sql = new sqlcommand(sql,conexao.conn);
                cmd.parameters.addwithvalue("CODIGO" leitores.codigo);
                cmd.executenonQuery();

                messagebox.show("leitor excluido com sucesso! ")
                
                utils.limparcampos(this);
            }
            catch (Exception ex)
            {
                messagebox.show("Erro: " + ex message)
            }
            finaly
            {
                conexao.fechar();
            }
            */
        }
    }
}
