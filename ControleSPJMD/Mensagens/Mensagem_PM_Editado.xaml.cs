using System.Windows;
using System.Windows.Media;

namespace ControleSPJMD.Mensagens
{

    public partial class Mensagem_PM_Editado : Window
    {
        public string? Mensagem { get; set; }
        public string? Situacao { get; set; }
        public Mensagem_PM_Editado()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblPMEditado.Content = Mensagem;
            switch (Situacao)
            {
                case "Ativo": lblPMSituacaoPM.Foreground = new SolidColorBrush(Colors.Green); break;
                case "Inativo": lblPMSituacaoPM.Foreground = new SolidColorBrush(Colors.Orange); break;
                case "Movimentado": lblPMSituacaoPM.Foreground = new SolidColorBrush(Colors.Blue); break;
                case "Exonerado": lblPMSituacaoPM.Foreground = new SolidColorBrush(Colors.Red); break;
                case "Demitido": lblPMSituacaoPM.Foreground = new SolidColorBrush(Colors.Red); break;
                case "Expluso": lblPMSituacaoPM.Foreground = new SolidColorBrush(Colors.Red); break;
            }
            lblPMSituacaoPM.Content = Situacao;
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
