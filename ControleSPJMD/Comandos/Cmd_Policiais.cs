﻿using ControleSPJMD.Conexao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        private MySqlDataReader? dr;

        public int Qtd { get; private set; }
        public string? ResultPM { get; private set; }
        public string? Posto { get; private set; }
        public string? Re { get; private set; }
        public string? Dig { get; private set; }
        public string? Nome { get; private set; }
        public bool PM_Vinculado { get; private set; }
        public bool Qtd_Process { get; private set; }


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

            try
            {
                cmd.CommandText = "select id from policial where re = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@re", MySqlDbType.VarChar, 6).Value = re;
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                dr.Read();
                Qtd_Process = dr.HasRows;
                dr.Close();
                con.Desconectar();
               
                Qtd = dt.Rows.Count;

                if (Qtd_Process == true) 
                {
                    MessageBox.Show("Re já cadastrado no Banco de Dados", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    cmd.Dispose();
                    try
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
                        cmd.Connection = con.Conectar();
                        cmd.ExecuteNonQuery();
                        con.Desconectar();
                        ResultPM = Posto + " " + Re + "-" + Dig + " " + Nome;
                    }
                    catch (MySqlException e)
                    {
                        MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return ResultPM;
        }

        public DataTable PmPrincipal()
        {
            try
            {
                cmd.CommandText = "select posto, re, dig, nome from policial where situacao = 'Ativo' order by " +
                    "posto = 'SD 2ª CL PM', posto = 'SD 1ª CL PM', posto = 'CB PM', posto = '3º SGT PM', " +
                    "posto = '2º SGT PM', posto = '1º SGT PM', posto = 'SUBTEN PM', posto = 'ASP OF PM', " +
                    "posto = '1º TEN PM', posto = '2º TEN PM', posto = 'CAP PM', posto = 'MAJ PM', posto = 'TEN CEL PM', posto = 'CEL PM'";                
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

        public DataTable PesquisaPM(string entrada)
        {
            try
            {
                cmd.CommandText = "select posto, re, dig, nome from policial where (re like '%" + entrada + "%' or nome like '%" + entrada + "%') order by " +
                    "posto = 'SD 2ª CL PM', posto = 'SD 1ª CL PM', posto = 'CB PM', posto = '3º SGT PM', " +
                    "posto = '2º SGT PM', posto = '1º SGT PM', posto = 'SUBTEN PM', posto = 'ASP OF PM', " +
                    "posto = '1º TEN PM', posto = '2º TEN PM', posto = 'CAP PM', posto = 'MAJ PM', posto = 'TEN CEL PM', posto = 'CEL PM'";               
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

        public DataTable EditarPM(string entrada)
        {
            try
            {
                cmd.CommandText = "select id, re, dig, posto, nome, email, cpf, rg, date_format(dataNasc, '%d-%m-%y'), date_format(dataAdm, '%d-%m-%y'), telefone, telefone2, situacao from policial where re = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@re", MySqlDbType.VarChar, 6).Value = entrada;
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
            try
            {
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
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                ResultPM = Posto + " " + Re + "-" + Dig + " " + Nome;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return ResultPM;
        }

        public bool DeletarPM(string id)
        {
            PM_Vinculado = true;            
            try
            {
                cmd.CommandText = "select id_procedimento from procedimento where id_pm = ? or id_encarregado = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@id2", MySqlDbType.Int32).Value = id;
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                dr.Read();
                Qtd_Process = dr.HasRows;               
                dr.Close();
                con.Desconectar();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (Qtd_Process == true)
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
            try
            {
                cmd.CommandText = "delete from policial where id = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                PM_Vinculado = true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro com o Banco de Dados" + e, "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
