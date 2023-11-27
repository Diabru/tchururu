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

namespace LojadeCarro
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            try
            {

                Conexão.conectar();

                string sql = @"SELECT* FROM carr.Login
                               WHERE USUARIO = @usuario
                               AND SENHA = @senha";
                SqlCommand cmd = new SqlCommand(sql, Conexão.conn);
                cmd.Parameters.AddWithValue("usuario", txtLogin.Text);
                cmd.Parameters.AddWithValue("senha", txtSenha.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                //Verificar se houve retorno de algum registro
                if (dr.HasRows)
                {
                    //Abrir o sistema - LOGIN EFETUADO
                    dr.Read();
                    if (dr["TIPO_USUARIO"].ToString() == "Administrador")
                    {
                        Pagina_Inicial menu = new Pagina_Inicial();
                        Visible = false;
                        menu.ShowDialog();
                        Visible = true;
                        txtLogin.Clear();
                        txtSenha.Clear();
                        txtLogin.Focus();
                    }
                    else if (dr["TIPO_USUARIO"].ToString() == "Usuario")
                    {
                        Pagina_Inicial menu = new Pagina_Inicial();
                        Visible = false;
                        menu.menuCadastro.Visible = false;
                        menu.ShowDialog();
                        Visible = true;
                        txtLogin.Clear();
                        txtSenha.Clear();
                        txtLogin.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Usuário e/ou senha inválidos!");
                    }
                    Conexão.fechar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
        }


    }
  }
