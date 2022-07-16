using ControleSPJMD.Controle;
using ControleSPJMD.Janelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControleSPJMD
{

    public partial class MainWindow : Window
    {
        public string? IdPM { get; set; }
        public string? NomeUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            txtLogin.Focus();
            lblBuzzoDeveloper.Content = "Buzzo® Developer - " + DateTime.Now.Year.ToString();
        }

        private void btnFecharPrograma_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void gridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnSairLogin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            Controle_Login control = new Controle_Login();
            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                MessageBox.Show("Preencha o campo Usuário (RE)", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtLogin.Focus();
            }
            else if (string.IsNullOrEmpty(txtSenha.Password))
            {
                MessageBox.Show("Preencha o campo Senha", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtSenha.Focus();
            }
            else
            {
               await control.Login_(txtLogin.Text, txtSenha.Password.ToString());
                if (control.NomePM != null)
                {
                    gridPrincipal.Visibility = Visibility.Visible;
                    gridLogin.Visibility = Visibility.Collapsed;
                    NomeUser = control.NomePM;
                    lblPM_Logado.Content = "BEM-VINDO " + NomeUser;
                    IdPM = control.IdPM;
                }
                else
                {
                    txtLogin.Clear();
                    txtSenha.Clear();
                    txtLogin.Focus();
                }
            }
        }

        private void txtLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void btnCalendario_Click(object sender, RoutedEventArgs e)
        {
            if (gridCalendario.Visibility == Visibility.Collapsed)
            {
                gridCalendario.Visibility = Visibility.Visible;
            }
            else
            {
                gridCalendario.Visibility = Visibility.Collapsed;
            }
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLogin.Text.Length == 6)
            {
                txtSenha.Focus();
            }
        }

        private void btnNumerador_Click(object sender, RoutedEventArgs e)
        {
            Numerador num = new Numerador();
            num.IdUsuario = IdPM;
            num.NomeUsuario = NomeUser;
            num.ShowDialog();
        }
    }
}
