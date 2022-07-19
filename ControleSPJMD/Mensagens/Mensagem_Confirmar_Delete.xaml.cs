using ControleSPJMD.Controle;
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
 
    public partial class Mensagem_Confirmar_Delete : Window
    {
        Controle_Policiais control = new Controle_Policiais();
        public bool DelPM { get; set; }
        public string Id_PM { get; set; }
        public Mensagem_Confirmar_Delete()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            control.Confirmar_Delete_PM(Id_PM);
            btnFechar_Click(sender, e);
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
