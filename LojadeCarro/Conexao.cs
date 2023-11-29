using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LojadeCarro
{
    internal class Conexao
    {
        public static SqlConnection conn;
        public static string conexao =
            @"Data Source=SJC0557982W10-1;
              Initial Catalog = LojadeCarro;
              User Id = sa;
              Password = Senac123";

        public static void conectar()
        {
            conn = new SqlConnection(conexao);
            conn.Open();
        }
        public static void fechar()
        {
            conn.Close();
        }

    }
}
