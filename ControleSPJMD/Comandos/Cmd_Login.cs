using MySql.Data.MySqlClient;
using ControleSPJMD.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ControleSPJMD.Janelas;

namespace ControleSPJMD.Comandos
{
    public class Cmd_Login
    {
        private MySqlCommand cmd = new MySqlCommand();
        private Conection con = new Conection();
        private MySqlDataReader? rd;
        public string? NomePM { get; private set; }
        public string? IdPM { get; private set; }

        public async Task Login(string login, string senha)
        {
            cmd.CommandText = "select id, nome from usuario where re = ? and senha = ?";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@re", MySqlDbType.Int32).Value = login.ToString();
            cmd.Parameters.Add("@senha", MySqlDbType.String, 10).Value = senha.ToString();
            try
            {
                cmd.Connection = con.Conectar();
                rd = (MySqlDataReader)await cmd.ExecuteReaderAsync();
                var valor = rd.Read();
                if (valor == false)
                {
                    MessageBox.Show("Usuário e/ou Senha inválido(a)" + "\n\r \n\r" + "Caso não possua cadastro, entre em contato com um Administrador.", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    IdPM = rd.GetString(0).ToString();
                    NomePM = rd.GetString(1).ToString().ToUpper();
                }
                con.Desconectar();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
