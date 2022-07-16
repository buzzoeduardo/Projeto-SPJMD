using System.ComponentModel;

namespace ControleSPJMD.Enums
{
    [TypeConverter(typeof(Controle_Enums))]
    public enum TipoDocumento_Enum
    {
        [Description("Mensagem Eletrônica")]
        Mensagem = 0,
        [Description("Ofício")]
        Oficio = 1,
        [Description("Despacho")]
        Despacho = 2,
        [Description("Ordem de Serviço")]
        Ordem_Servico = 3,
        [Description("Parte")]
        Parte = 4,
        [Description("Memorando")]
        Memorando = 5        
    }
}
