using MySql.Data.MySqlClient;
using System.Data;

namespace ControleSPJMD.Conexao
{
    public class Conection
    {
        MySqlConnection conexao = new MySqlConnection();

        public Conection()
        {
            conexao.ConnectionString = "SERVER=localhost;DATABASE=gerenciasj;UID=root;PASSWORD=W37bt12201;Allow Zero Datetime=True";
        }

        public MySqlConnection Conectar()
        {
            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }
            return conexao;
        }

        public void Desconectar()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
