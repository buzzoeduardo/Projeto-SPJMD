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
        DataTable dt2 = new DataTable();

        //public DataTable? Dt { get; private set; }
        public string? Resultado { get; private set; }
        public bool PM_Vinc { get; private set; }
        public int Qtd_Process { get; private set; }
        public string? Id_Procedimento { get; private set; }
        public string? Id_PM { get; private set; }
        public int? Qtd_SIndicancia { get; private set; }
        public int? Qtd_Ipm { get; private set; }
        public int? Qtd_Ip { get; private set; }
        public int? Qtd_Apuracao { get; private set; }
        public string? Id_Encarregado { get; private set; }
        public int? Qtd_Dp { get; private set; }
        public int? Qtd_ProcessRegular { get; private set; }

        public void FecharDataTable()
        {
            if(dt.Rows.Count > 0)
            {
                dt.Clear();
                dt.Dispose();
            }           
        }

        public string Salvar_Policial(string re, string dig, string posto, string nome, string email, string cpf, string rg, string dataNasc, string dataAdm, string telefone, string telefone2, string situacao)
        {
            FecharDataTable();
            cmd.SalvarPolicial(re, dig, posto, nome, email, cpf, rg, dataNasc, dataAdm, telefone, telefone2, situacao);
            return  Resultado = cmd.ResultPM;
        }

        public DataTable PM_Principal()
        {
            FecharDataTable();
            return dt = cmd.PmPrincipal();
        }

        public DataTable Pesquisa_PM(string entrada)
        {
            FecharDataTable();
            return dt = cmd.PesquisaPM(entrada);
        }

        public DataTable Editar_PM(string entrada)
        {
            FecharDataTable();
            return dt = cmd.EditarPM(entrada);
        }

        public string Salvar_Edit_PM(string id, string re, string dig, string posto, string nome, string email, string cpf, string rg, string dataNasc, string dataAdm,
            string telefone, string telefone2, string situacao)
        {
            FecharDataTable();
            cmd.SalvarEditPM(id, re, dig, posto, nome, email, cpf, rg, dataNasc, dataAdm, telefone, telefone2, situacao);
            return Resultado = cmd.ResultPM;
        }

        public bool Deletar_PM(string id)
        {
            FecharDataTable();
            cmd.DeletarPM(id);
            return PM_Vinc = cmd.PM_Vinculado;
        }

        public void Confirmar_Delete_PM(string id)
        {
            FecharDataTable();
            cmd.ConfirmarDeletePM(id);           
        }

        public void Qtd_Process_PM(string id)
        {
            FecharDataTable();
            cmd.QtdProcedimentosPorPM(id);
            Qtd_Process = cmd.Qtd_Process;
            Qtd_Apuracao = cmd.Qtd_Apuracao;
            Qtd_Dp = cmd.Qtd_Pd;
            Qtd_Ip = cmd.Qtd_Ip;
            Qtd_Ipm = cmd.Qtd_Ipm;
            Qtd_ProcessRegular = cmd.Qtd_ProcessRegular;
            Qtd_SIndicancia = cmd.Qtd_Sindicancia;
        }

        public DataTable Process_PM_Selecionado(int valorRd, string id)
        {
            FecharDataTable();
            return dt2 = cmd.ProcessPMSelecionado(valorRd, id);
        }
    }
}
