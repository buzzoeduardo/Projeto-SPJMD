using ControleSPJMD.Controle;
using System.Windows;

namespace ControleSPJMD.Mensagens
{
    public partial class CancelarNumerador : Window
    {
        Controle_Numerador control = new Controle_Numerador();
        public string? IdNum { get; set; }
        public string? Referencia { get; set; }
        public string? Anexo { get; set; }
        public string? Destino { get; set; }   
        
        public CancelarNumerador()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            control.Editar_Numerador(IdNum, Referencia, Anexo, Destino, "ANULADO - " + txtObsCancelaNum.Text.ToUpper());
            btnFechar_Click(sender, e);
        }
    }
}
