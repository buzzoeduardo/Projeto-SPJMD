using ControleSPJMD.Conexao;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

namespace ControleSPJMD.Comandos
{
    public class Cmd_Numerador
    {
        private MySqlCommand cmd = new MySqlCommand();
        private Conection con = new Conection();
        private DataTable dt = new DataTable();
        private MySqlDataReader? dr;

        public int Qtd { get; private set; }
        public string? Numero { get; private set; }
        public string? Tipo { get; private set; }
        public string? IdUsuario { get; private set; }
        public bool Existe { get; set; }

        public string ResultNum = "";


        public string SalvarNumerador(string tipo, string assunto, string destino, string referencia, string anexo, string idUsuario)
        {
            Tipo = tipo.ToUpper();
            IdUsuario = idUsuario;
            try
            {
                cmd.CommandText = "select count(id) from numerador where (year(data) = year(curdate())) and tipo = ?";
                cmd.Parameters.Clear();               
                cmd.Parameters.Add("@tipo", MySqlDbType.VarChar, 20).Value = Tipo;
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                dr.Read();
                Existe = dr.HasRows;
                Qtd = dr.GetInt32(0);
                dr.Close();
                con.Desconectar();

                if (Qtd == 0)
                {
                    Numero = "1";
                }
                else
                {
                    Numero = (Qtd + 1).ToString();
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            DateTime data = DateTime.Now;
            data.ToString("yyyy/MM/dd").Replace("/", "-");

            try
            {
                cmd.CommandText = "insert into numerador values (default, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@numero", MySqlDbType.Int32).Value = Numero;
                cmd.Parameters.Add("@tipo", MySqlDbType.VarChar, 20).Value = Tipo;
                cmd.Parameters.Add("@assunto", MySqlDbType.VarChar, 50).Value = assunto.ToUpper();
                cmd.Parameters.Add("@destino", MySqlDbType.VarChar, 60).Value = destino.ToUpper();
                cmd.Parameters.Add("@referencia", MySqlDbType.VarChar, 120).Value = referencia.ToUpper();
                cmd.Parameters.Add("@anexo", MySqlDbType.VarChar, 120).Value = anexo.ToUpper();
                cmd.Parameters.Add("@observacao", MySqlDbType.VarChar, 60).Value = "";
                cmd.Parameters.Add("@data", MySqlDbType.Date).Value = data;
                cmd.Parameters.Add("@idUsuario", MySqlDbType.Int32).Value = IdUsuario;
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ResultNum = Tipo + " Nº 9BPMI-" + Numero + "/13/" + data.ToString("yy");
            return ResultNum;
        }


        public DataTable PesqNumAnoAtual(string entrada)
        {
            try
            {
                cmd.CommandText = "select usuario.nome, numerador.id, numerador.tipo, numerador.numero, numerador.assunto, date_format(numerador.data, '%d-%m-%y')" +
                    "as data, numerador.destino, numerador.referencia, numerador.anexo, numerador.observacao from usuario join numerador on usuario.id = numerador.idUsuario " +
                    "where (year(numerador.data) = year(curdate())) and" +
                    "(numerador.assunto like '%" + entrada + "%'" +
                    "or numerador.destino like '%" + entrada + "%'" +
                    "or numerador.referencia like '%" + entrada + "%'" +
                    "or numerador.observacao like '%" + entrada + "%'" +
                    "or numerador.anexo like '%" + entrada + "%') order by tipo";
                cmd.Parameters.Clear();
                cmd.Connection = con.Conectar();
                dt.Clear();
                dt.Load(cmd.ExecuteReader());
                con.Desconectar();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }

        public DataTable PesqNumAnterior(string entrada)
        {
            try
            {
                cmd.CommandText = "select usuario.nome, numerador.id, numerador.tipo, numerador.numero, numerador.assunto, date_format(numerador.data, '%d-%m-%y')" +
                   "as data, numerador.destino, numerador.referencia, numerador.anexo, numerador.observacao from usuario join numerador on usuario.id = numerador.idUsuario " +
                   "where (year(numerador.data) != year(curdate())) and" +
                   "(numerador.assunto like '%" + entrada + "%'" +
                   "or numerador.destino like '%" + entrada + "%'" +
                   "or numerador.referencia like '%" + entrada + "%'" +
                   "or numerador.observacao like '%" + entrada + "%'" +
                   "or numerador.anexo like '%" + entrada + "%') order by tipo";
                cmd.Parameters.Clear();
                cmd.Connection = con.Conectar();
                dt.Clear();
                dt.Load(cmd.ExecuteReader());
                con.Desconectar();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }

        public DataTable NumeradorPrincipal(string entrada, string dataInicio, string dataFim)
        {
            try
            {
                cmd.CommandText = "select usuario.nome, numerador.id, numerador.tipo, numerador.numero, numerador.assunto, date_format(numerador.data, '%d-%m-%y')" +
                   "as data, numerador.destino, numerador.referencia, numerador.anexo, numerador.observacao from usuario join numerador on usuario.id = numerador.idUsuario " +
                   "where (numerador.data between date(?) and date(?)) and numerador.tipo = ? order by numerador.numero";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@dataInicio", MySqlDbType.Date).Value = dataInicio;
                cmd.Parameters.Add("@dataFin", MySqlDbType.Date).Value = dataFim;
                cmd.Parameters.Add("@idUsuario", MySqlDbType.VarChar, 20).Value = entrada;
                cmd.Connection = con.Conectar();
                dt.Clear();
                dt.Load(cmd.ExecuteReader());
                con.Desconectar();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }

        public async Task EditarNumerador(string id, string referencia, string anexo, string destino, string obs)
        {
            try
            {
                cmd.CommandText = "update numerador set referencia = ?, anexo = ?, destino = ?, observacao = ? where id = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@referencia", MySqlDbType.String, 120).Value = referencia.ToUpper();
                cmd.Parameters.Add("@anexo", MySqlDbType.String, 120).Value = anexo.ToUpper();
                cmd.Parameters.Add("@destino", MySqlDbType.String, 60).Value = destino.ToUpper();
                cmd.Parameters.Add("@observacao", MySqlDbType.String, 60).Value = obs;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Connection = con.Conectar();
                await cmd.ExecuteNonQueryAsync();
                con.Desconectar();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public DataTable PesquisarNumPorId(string id)
        {
            try
            {
                cmd.CommandText = "select usuario.nome, numerador.id, numerador.tipo, numerador.numero, numerador.assunto, date_format(numerador.data, '%d-%m-%y')" +
                   "as data, numerador.destino, numerador.referencia, numerador.anexo, numerador.observacao from usuario join numerador on usuario.id = numerador.idUsuario " +
                   "where numerador.id = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Connection = con.Conectar();
                dt.Clear();
                dt.Load(cmd.ExecuteReader());
                con.Desconectar();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }
    }
}
