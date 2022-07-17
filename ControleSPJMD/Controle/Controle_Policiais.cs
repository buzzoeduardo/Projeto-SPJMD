using ControleSPJMD.Comandos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleSPJMD.Controle
{
    public class Controle_Policiais
    {
        Cmd_Policiais cmd = new Cmd_Policiais();
        DataTable dt = new DataTable();

        public string? Resultado { get; set; }

        public string Salvar_Policial(string re, string dig, string posto, string nome, string email, string cpf, string rg, string dataNasc, string dataAdm, string telefone, string telefone2, string situacao)
        {
            cmd.SalvarPolicial(re, dig, posto, nome, email, cpf, rg, dataNasc, dataAdm, telefone, telefone2, situacao);
            return  Resultado = cmd.ResultPM;
        }

        public DataTable PM_Principal()
        {
          return dt = cmd.PmPrincipal();
        }

        public DataTable Pesquisa_PM(string entrada)
        {
            return dt = cmd.PesquisaPM(entrada);
        }

        public DataTable Editar_PM(string entrada)
        {
            return dt = cmd.EditarPM(entrada);
        }
    }
}
