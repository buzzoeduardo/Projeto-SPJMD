using ControleSPJMD.Conexao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ControleSPJMD.Comandos
{
    public class Cmd_Policiais
    {
        private MySqlCommand cmd = new MySqlCommand();
        private Conection con = new Conection();
        private DataTable dt = new DataTable();
        private DataTable dtProcess = new DataTable();
        private MySqlDataReader? dr;

        //public DataTable? Dt { get; private set; }
        public int Qtd_PM { get; private set; }
        public string? ResultPM { get; private set; }
        public string? Posto { get; private set; }
        public string? Re { get; private set; }
        public string? Dig { get; private set; }
        public string? Nome { get; private set; }
        public bool PM_Vinculado { get; private set; }
        public bool Existe_Process { get; private set; }
        public int Qtd_Process { get; private set; }
        public string? Qtd_Procedimento { get; private set; }
        public int? Id_PM { get; private set; }
        public int? Qtd_Sindicancia { get; private set; } = 0;
        public int? Qtd_Ipm { get; private set; } = 0;
        public int? Qtd_Ip { get; private set; } = 0;
        public int? Qtd_Apuracao { get; private set; } = 0;
        public int? Qtd_Encarregado { get; private set; } = 0;
        public int? Qtd_Pd { get; private set; } = 0;
        public int? Qtd_ProcessRegular { get; private set; } = 0;

        public string SalvarPolicial(string re, string dig, string posto, string nome, string email, string cpf, string rg, string dataNasc, string dataAdm,
            string telefone, string telefone2, string situacao)
        {
            ResultPM = null;
            Re = re;
            Dig = dig;
            Posto = posto;
            Nome = nome.ToUpper();
            DateTime dtNasc = new DateTime();
            DateTime dtAdm = new DateTime();
            dtNasc = DateTime.Parse(dataNasc);
            dtNasc.ToString("yyyy/MM/dd").Replace("/", "-");
            dtAdm = DateTime.Parse(dataAdm);
            dtAdm.ToString("yyyy/MM/dd").Replace('/', '-');

            cmd.CommandText = "select id from policial where re = ?";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@re", MySqlDbType.VarChar, 6).Value = re;
            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                dr.Read();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Existe_Process = dr.HasRows;
                Qtd_PM = dt.Rows.Count;
                dr.Close();
                con.Desconectar();
                cmd.Dispose();
            }
            if (Existe_Process == true)
            {
                MessageBox.Show("Re já cadastrado no Banco de Dados", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                cmd.CommandText = "insert into policial values (default, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@re", MySqlDbType.VarChar, 6).Value = Re;
                cmd.Parameters.Add("@dig", MySqlDbType.VarChar, 1).Value = Dig;
                cmd.Parameters.Add("@posto", MySqlDbType.VarChar, 15).Value = Posto;
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 70).Value = Nome;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar, 70).Value = email.ToLower();
                cmd.Parameters.Add("@cpf", MySqlDbType.VarChar, 11).Value = cpf;
                cmd.Parameters.Add("@rg", MySqlDbType.VarChar, 10).Value = rg;
                cmd.Parameters.Add("@dataNasc", MySqlDbType.Date).Value = dtNasc;
                cmd.Parameters.Add("@dataAdm", MySqlDbType.Date).Value = dtAdm;
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar, 11).Value = telefone;
                cmd.Parameters.Add("@telefone2", MySqlDbType.VarChar, 11).Value = telefone2;
                cmd.Parameters.Add("@situacao", MySqlDbType.VarChar, 15).Value = situacao;
                try
                {
                    cmd.Connection = con.Conectar();
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    con.Desconectar();
                    cmd.Dispose();
                    ResultPM = String.Format("{0} {1}-{2} {3}", Posto, Re, Dig, Nome); 
                }
            }
            return ResultPM;
        }

        public DataTable PmPrincipal()
        {
            cmd.CommandText = "select posto, re, dig, nome from policial where situacao = 'Ativo' order by " +
                    "posto = 'SD 2ª CL PM', posto = 'SD 1ª CL PM', posto = 'CB PM', posto = '3º SGT PM', " +
                    "posto = '2º SGT PM', posto = '1º SGT PM', posto = 'SUBTEN PM', posto = 'ASP OF PM', " +
                    "posto = '1º TEN PM', posto = '2º TEN PM', posto = 'CAP PM', posto = 'MAJ PM', posto = 'TEN CEL PM', posto = 'CEL PM'";
            try
            {
                cmd.Connection = con.Conectar();
                dt.Clear();
                dt.Load(cmd.ExecuteReader());
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Desconectar();
                cmd.Dispose();
            }
            return dt;
        }

        public DataTable PesquisaPM(string entrada)
        {
            cmd.CommandText = "select posto, re, dig, nome from policial where (re like '%" + entrada + "%' or nome like '%" + entrada + "%') order by " +
                   "posto = 'SD 2ª CL PM', posto = 'SD 1ª CL PM', posto = 'CB PM', posto = '3º SGT PM', " +
                   "posto = '2º SGT PM', posto = '1º SGT PM', posto = 'SUBTEN PM', posto = 'ASP OF PM', " +
                   "posto = '1º TEN PM', posto = '2º TEN PM', posto = 'CAP PM', posto = 'MAJ PM', posto = 'TEN CEL PM', posto = 'CEL PM'";
            try
            {
                cmd.Connection = con.Conectar();
                dt.Clear();
                dt.Load(cmd.ExecuteReader());
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Desconectar();
                cmd.Dispose();
            }
            return dt;
        }

        public DataTable EditarPM(string entrada)
        {
            cmd.CommandText = "select id, re, dig, posto, nome, email, cpf, rg, date_format(dataNasc, '%d-%m-%y') as data, date_format(dataAdm, '%d-%m-%y') as data, telefone, telefone2, situacao from policial where re = ?";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@re", MySqlDbType.VarChar, 6).Value = entrada;
            try
            {
                cmd.Connection = con.Conectar();
                dt.Clear();
                dt.Load(cmd.ExecuteReader());
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Desconectar();
                cmd.Dispose();
            }
            return dt;
        }

        public string SalvarEditPM(string id, string re, string dig, string posto, string nome, string email, string cpf, string rg, string dataNasc, string dataAdm,
            string telefone, string telefone2, string situacao)
        {
            ResultPM = null;
            Re = re;
            Dig = dig;
            Posto = posto;
            Nome = nome.ToUpper();
            DateTime dtNasc = new DateTime();
            DateTime dtAdm = new DateTime();
            dtNasc = DateTime.Parse(dataNasc);
            dtNasc.ToString("yyyy/MM/dd").Replace("/", "-");
            dtAdm = DateTime.Parse(dataAdm);
            dtAdm.ToString("yyyy/MM/dd").Replace('/', '-');

            cmd.CommandText = "update policial set re = ?, dig = ?, posto = ?, nome = ?, email = ?, cpf = ?, rg = ?, dataNasc = ?, dataAdm = ?, telefone = ?, " +
                   "telefone2 = ?, situacao = ? where id = ?";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@re", MySqlDbType.VarChar, 6).Value = Re;
            cmd.Parameters.Add("@dig", MySqlDbType.VarChar, 1).Value = Dig;
            cmd.Parameters.Add("@posto", MySqlDbType.VarChar, 15).Value = Posto;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 70).Value = Nome;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar, 70).Value = email.ToLower();
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar, 11).Value = cpf;
            cmd.Parameters.Add("@rg", MySqlDbType.VarChar, 10).Value = rg;
            cmd.Parameters.Add("@dataNasc", MySqlDbType.Date).Value = dtNasc;
            cmd.Parameters.Add("@dataAdm", MySqlDbType.Date).Value = dtAdm;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar, 11).Value = telefone;
            cmd.Parameters.Add("@telefone2", MySqlDbType.VarChar, 11).Value = telefone2;
            cmd.Parameters.Add("@situacao", MySqlDbType.VarChar, 15).Value = situacao;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Desconectar();
                cmd.Dispose();
                ResultPM = String.Format("{0} {1}-{2} {3}", Posto, Re, Dig, Nome); 
            }
            return ResultPM;
        }

        public bool DeletarPM(string id)
        {
            PM_Vinculado = true;

            cmd.CommandText = "select id_procedimento from procedimento where id_pm = ? or id_encarregado = ?";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            cmd.Parameters.Add("@id2", MySqlDbType.Int32).Value = id;
            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                dr.Read();
                Existe_Process = dr.HasRows;
                dr.Close();
                con.Desconectar();
                cmd.Dispose();
            }

            if (Existe_Process == true)
            {
                MessageBox.Show("Não é possível excluir o Policial Militar selecionado. \n\rO Policial está vinculado à Processo/Procedimento. \n\r" +
                    "Se realmente quiser excluir esse Policial da base de dados do sistema, desvincule-o do referido feito.", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                PM_Vinculado = false;
            }
            return PM_Vinculado;
        }

        public void ConfirmarDeletePM(string id)
        {
            cmd.CommandText = "delete from policial where id = ?";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Desconectar();
                cmd.Dispose();
                PM_Vinculado = true;
            }
        }

        public void QtdProcedimentosPorPM(string id)
        {
            cmd.CommandText = "select id_procedimento, id_processregular, id_ipm, id_sindicancia, id_ip, id_pd, id_apura_preliminar " +
                "from procedimento where id_pm = ?";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@id_pm", MySqlDbType.Int32).Value = id;

            DataTable dt = new DataTable();
            try
            {
                cmd.Connection = con.Conectar();
                dt.Clear();
                dt.Load(cmd.ExecuteReader());

                Qtd_Process = dt.Rows.Count;

                if (Qtd_Process > 0)
                {
                    for (int i = 0; i < Qtd_Process; i++)
                    {
                        Qtd_ProcessRegular = Qtd_ProcessRegular + dt.Rows[i][1].ToString().Count();
                        Qtd_Ipm = Qtd_Ipm + dt.Rows[i][2].ToString().Count();
                        Qtd_Sindicancia = Qtd_Sindicancia + dt.Rows[i][3].ToString().Count();
                        Qtd_Ip = Qtd_Ip + dt.Rows[i][4].ToString().Count();
                        Qtd_Pd = Qtd_Pd + dt.Rows[i][5].ToString().Count();
                        Qtd_Apuracao = Qtd_Apuracao + dt.Rows[i][6].ToString().Count();
                    }
                }
                else
                {
                    Qtd_ProcessRegular = 0;
                    Qtd_Ipm = 0;
                    Qtd_Sindicancia = 0;
                    Qtd_Ip = 0;
                    Qtd_Pd = 0;
                    Qtd_Apuracao = 0;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally {
                con.Desconectar();
                cmd.Dispose();
            }
        }

        public DataTable ProcessPMSelecionado(string valorRd, string id)
        {
            string nomeProcess = "";
            switch (valorRd)
            {
                case "Processo Regular": nomeProcess = "processregular"; break;
                case "IPM": nomeProcess = "ipm"; break;
                case "Sindicância": nomeProcess = "sindicancia"; break;
                case "IP": nomeProcess = "ip"; break;
                case "PD": nomeProcess = "pd"; break;
                case "Apuração Preliminar": nomeProcess = "apura_preliminar"; break;
            }
            cmd.CommandText = String.Format("select {0}.tipificacao, {0}.numero, {0}.prefixo, date_format({0}.dataInstaura, '%d-%m-%y') as dataInstaura, " +
                "date_format({0}.dataEncerra, '%d-%m-%y') as dataEncerra from {0} join procedimento on {0}.id = procedimento.id_{0} where procedimento.id_pm = ?", nomeProcess);
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@id_pm", MySqlDbType.Int32).Value = id;
            
            try
            {
                cmd.Connection = con.Conectar();
                dtProcess.Clear();
                dtProcess.Load(cmd.ExecuteReader());
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Desconectar();
                cmd.Dispose();
            }
            return dtProcess;
        }
    }
}
