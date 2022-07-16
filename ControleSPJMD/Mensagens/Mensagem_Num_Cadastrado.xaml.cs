using ControleSPJMD.Comandos;
using ControleSPJMD.Controle;
using ControleSPJMD.Janelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControleSPJMD.Mensagens
{
    
    public partial class Mensagem_Num_Cadastrado : Window
    {
        public string? MensagemNum { get; set; }

        public Mensagem_Num_Cadastrado()
        {            
            InitializeComponent();   
        }

      
        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            Close();    
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {           
            lblNumeroCadastrado.Content = MensagemNum;
        }
    }
}
