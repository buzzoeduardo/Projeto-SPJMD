using System.ComponentModel;

namespace ControleSPJMD.Enums
{
    [TypeConverter(typeof(Controle_Enums))]
    public enum PostGrad_Enum
    {
        [Description("Cel PM")]
        Cel = 0,
        [Description("Ten Cel PM")]
        TenCel = 1,
        [Description("Maj PM")]
        Maj = 2,
        [Description("Cap PM")]
        Cap = 3,
        [Description("1º Ten PM")]
        P_Ten = 4,
        [Description("2º Ten PM")]
        S_Ten = 5,
        [Description("Asp Of PM")]
        Asp_Of = 6,
        [Description("Subten PM")]
        Subten = 7,
        [Description("1º Sgt PM")]
        P_Sgt = 8,
        [Description("2º Sgt PM")]
        S_Sgt = 9,
        [Description("3º Sgt PM")]
        T_Sgt = 10,
        [Description("Cb PM")]
        Cb = 11,
        [Description("Sd 1ª Cl PM")]
        Sd_P = 12,
        [Description("Sd 2ª Cl PM")]
        Sd_S = 13
    }
}
