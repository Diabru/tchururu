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
                // bryan dps tu arruma saporra. não to conectado com o banco 🥰💀🙄🤬🤓😜☺️🙃🤠😳 

                ///conexao.conectar();
                ///
                ///string sql = "select * from carrCliente";
                ///sqlcommand cmd = new sqlcommand(sql, conexao.conn);
                ///
                // datatable - copia a tabela pra memoria
                /// data table dt = new datatable();
                /// 
                // carregar o datatable com dados da tabela
                /// dt.load(cmd.executereader());
                /// dgvleitores.datasource = dt;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);
            }
            finally
            {
                ///conexao.fechar();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // bryan dps tu arruma saporra. não to conectado com o banco 🥰💀🙄🤬🤓😜☺️🙃🤠😳 

                ///conexao.conectar();
                ///
                ///string sql = "select * from carrCliente
                /// where nome like '" + txtPesquisa + "%'";
                ///sqlcommand cmd = new sqlcommand(sql, conexao.conn);
                ///
                // datatable - copia a tabela pra memoria
                /// data table dt = new datatable();
                /// 
                // carregar o datatable com dados da tabela
                /// dt.load(cmd.executereader());
                /// dgvleitores.datasource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);
            }
            finally
            {
                ///conexao.fechar();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ///datagridviewrow linha;
            /// linha = dgvleitores.currentrow;
            /// leitores.codigo = linha.cells["Clie_ID"].value.tostring();
            /// leitores.codigo = linha.cells["Clie_NM"];
            /// leitores.codigo = linha.cells["Clie_Tel"];
            /// leitores.codigo = linha.cells["Clie_Email"];
            /// leitores.codigo = linha.cells["Clie_CPF"];
            /// leitores.codigo = linha.cells["Clie_CNPJ"];
            /// leitores.codigo = linha.cells["Clie_RG"];
            /// leitores.codigo = linha.cells["Clie_DataE"];
            /// leitores.codigo = linha.cells["Clie_Nat"];
            /// leitores.codigo = linha.cells["Clie_END"];
            /// leitores.codigo = linha.cells["Clie_CEP"];
            /// leitores.codigo = linha.cells["Clie_Cida"];
            /// if (linha.cells["foto"].value.tostring() != "")
            ///       leitores.foto = (byte[])linha.cells["Foto"].value;
            /// else
            ///     leitores.fote = null;
            /// close();
        }

        private void dgvleitores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }   
}
