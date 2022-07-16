using System.ComponentModel;

namespace ControleSPJMD.Enums
{
    [TypeConverter(typeof(Controle_Enums))]
    public enum Situacao_PM_Enum
    {
        [Description("Ativo")]
        Ativo = 0,
        [Description("Inativo")]
        Inativo = 1,
        [Description("Movimentado")]
        Movimentado = 2,
        [Description("Exonerado")]
        Exonerado = 3,
        [Description("Expulso")]
        Expulso = 4,
        [Description("Demitido")]
        Demitido = 5
    }
}
