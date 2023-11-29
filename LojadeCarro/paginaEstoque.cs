using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojadeCarro
{
    public partial class paginaEstoque : Form
    {
        public paginaEstoque()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void paginaEstoque_Load(object sender, EventArgs e)
        {
            try
            {
                Conexao.conectar();
                string sql = "Select * from carr.Cliente";
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
                //DataTable - Cópia da tabela para memória
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvClientes.DataSource = dt;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                try
                {
                    Conexao.conectar();
                    string sql = @"Select * from carr.Cliente
                       where Clie_NM like '" + txtPesquisa.Text + "%'";
                    SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
                    //DataTable - Cópia da tabela para memória
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dgvClientes.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataGridViewRow linha;
            linha = dgvClientes.CurrentRow;
            Clientes.Clie_ID = linha.Cells["Codigo"].Value.ToString();
            Clientes.Clie_NM = linha.Cells["Nome"].Value.ToString();
            Clientes.Clie_Tel = linha.Cells["Telefone"].Value.ToString();
            Clientes.Clie_CEP = linha.Cells["CEP"].Value.ToString();
            Clientes.Clie_Estado = linha.Cells["Estado"].Value.ToString();
            Clientes.Clie_Cida = linha.Cells["Cidade"].Value.ToString();
            Clientes.Clie_Rua = linha.Cells["Rua"].Value.ToString();
            Clientes.Clie_N = linha.Cells["Numero"].Value.ToString();
            Clientes.Clie_Complemento = linha.Cells["Complemento"].Value.ToString();
            Clientes.Clie_Bairro = linha.Cells["Bairro"].Value.ToString();
            if (linha.Cells["Foto"].Value.ToString() != "")
            {
                Clientes.foto = (byte[])linha.Cells["Foto"].Value;
            }
            else
            {
                Clientes.foto = null;
            }
            Close();
        }

        private void dgvleitores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paginaEstoque menu = new paginaEstoque();
            menu.ShowDialog();
        }
    }   
}
