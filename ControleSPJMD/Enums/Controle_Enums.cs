using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Markup;

namespace ControleSPJMD.Enums
{
    public class Controle_Enums : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public Controle_Enums(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
            {
                throw new Exception("EnumType não é do tipo Enum ou é nulo.");
            }
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (EnumType == null) throw new ArgumentNullException(nameof(EnumType));

            return Enum.GetValues(EnumType).Cast<Enum>().Select(EnumToDescriptionOrString);
        }

        private string EnumToDescriptionOrString(Enum valor)
        {
            return valor.GetType().GetField(valor.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false)
                       .Cast<DescriptionAttribute>().FirstOrDefault()?.Description ?? valor.ToString();
        }
    }
}
