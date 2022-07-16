using ControleSPJMD.Comandos;
using System.Data;

namespace ControleSPJMD.Controle
{
    public class Controle_Numerador
    {
        Cmd_Numerador cmd = new Cmd_Numerador();
        DataTable dt = new DataTable();

        public string? Resultado { get; set; }
       
        public string Salvar_Numerador(string tipo, string assunto, string destino, string referencia, string anexo, string idUsuario)
        {
            cmd.SalvarNumerador(tipo, assunto, destino, referencia, anexo, idUsuario);
            return Resultado = cmd.ResultNum;            
        }

        public DataTable Pesq_NumAtual(string entrada)
        {
            dt = cmd.PesqNumAnoAtual(entrada);
            return dt;
        }

        public DataTable Pesq_NumAnterior(string entrada)
        {
            dt = cmd.PesqNumAnterior(entrada);
            return dt;
        }

        public DataTable Numerador_Principal(string entrada, string dataInicio, string dataFim)
        {
            dt = cmd.NumeradorPrincipal(entrada, dataInicio, dataFim);
           return dt;
        }

        public async void Editar_Numerador(string id, string referencia, string anexo, string destino, string obs)
        {
            await cmd.EditarNumerador(id, referencia, anexo, destino, obs);
        }

        public DataTable Pesq_Num_Por_Id(string id)
        {
            dt = cmd.PesquisarNumPorId(id);
            return dt;
        }
    }
}
