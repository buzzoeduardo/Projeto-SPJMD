using System;
using System.Windows;

namespace ControleSPJMD.Mensagens
{
    public partial class Mensagem_PM_Cadastrado : Window
    {
        public string? Mensagem { get; set; }
                       

        public Mensagem_PM_Cadastrado()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblPMCadastrado.Content = Mensagem;
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
