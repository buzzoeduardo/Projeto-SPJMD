using ControleSPJMD.Controle;
using ControleSPJMD.Mensagens;
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
using System.Windows.Shapes;

namespace ControleSPJMD.Janelas
{   
    public partial class Policial : Window
    {
        Controle_Policiais control = new Controle_Policiais();
        public string PM_Cadastrado { get; set; }
        public Policial()
        {
            InitializeComponent();
            lblBuzzoDeveloper.Content = "Buzzo® Developer - " + DateTime.Now.Year.ToString();
            lblNomeGridPM.Content = "POLICIAIS MILITARES";
        }

        private void PermitirNumeros(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        public void GridInicial(object sender, RoutedEventArgs e)
        {
            btnRetornar.Visibility = Visibility.Collapsed;
            gridPmPrincipal.Visibility = Visibility.Visible;
            gridNovoPM.Visibility = Visibility.Collapsed;
            gridEditarPM.Visibility = Visibility.Collapsed;
            lblNomeGridPM.Content = "POLICIAIS MILITARES";
            lblQtdPMPrincipal.Content = null;
            btnEditarPm.Visibility = Visibility.Collapsed;
        }

        private void Retornar(object sender, RoutedEventArgs e)
        {
            GridInicial(sender, e);
        }

        private void btnFecharPrograma_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
      

        private void btn_Limpar(object sender, RoutedEventArgs e)
        {
            cbxPostGrad.SelectedIndex = -1;
            cbxPostGrad_Editar.SelectedIndex = -1;
            cbxSituacao_Editar.SelectedIndex = -1;
            txtCpf.Clear();
            txtCpf_Editar.Clear();
            txtDig.Clear();
            txtDig_Editar.Clear();
            txtEmail.Clear();
            txtEmail_Editar.Clear();
            txtNomePM.Clear();
            txtNomePM_Editar.Clear();
            txtRE.Clear();
            txtRE_Editar.Clear();
            txtRg.Clear();
            txtRg_Editar.Clear();
            txtTelefone.Clear();
            txtTelefone2.Clear();
            txtTelefone2_Editar.Clear();
            txtTelefone_Editar.Clear();
            dataAdm.Text = null;
            dataAdm_Editar.Text = null;
            dataNasc.Text = null;
            dataNasc_Editar.Text = null;
        }

        private void btnNovoPM_Click(object sender, RoutedEventArgs e)
        {
            if (gridNovoPM.Visibility == Visibility.Collapsed)
            {
                gridPmPrincipal.Visibility = Visibility.Collapsed;
                gridEditarPM.Visibility = Visibility.Collapsed;
                gridNovoPM.Visibility = Visibility.Visible;
                lblNomeGridPM.Content = btnNovoPM.Content.ToString();
            }
        }

        private void btnSalvarPM_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbxPostGrad.Text) || string.IsNullOrEmpty(txtNomePM.Text) || string.IsNullOrEmpty(txtRE.Text) || string.IsNullOrEmpty(txtDig.Text))
            {
                MessageBox.Show("Preencha os Campo Obrigatórios", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (txtRE.Text.Length != 6)
                {
                    MessageBox.Show("RE inválido. O RE precisa conter 6 (seis) dígitos.", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    if (txtNomePM.Text.Length < 4)
                    {
                        MessageBox.Show("Nome muito curto. \n\rPara uma melhor segurança e controle, insira um nome com mais de 4 (quatro) caracteres.",
                            "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        string dtNasc = dataNasc.Text.ToString();
                        string dtAdm = dataAdm.Text.ToString();
                        if (string.IsNullOrEmpty(dtNasc))
                        {
                            dtNasc = DateTime.MinValue.ToString();
                        }
                        if (string.IsNullOrEmpty(dtAdm))
                        {
                            dtAdm = DateTime.MinValue.ToString();
                        }
                        control.Salvar_Policial(txtRE.Text, txtDig.Text, cbxPostGrad.Text, txtNomePM.Text, txtEmail.Text, txtCpf.Text, txtRg.Text,
                            dtNasc, dtAdm, txtTelefone.Text, txtTelefone2.Text, "ATIVO");
                        PM_Cadastrado = control.Resultado;
                        Mensagem_PM_Cadastrado men = new Mensagem_PM_Cadastrado();
                        men.Mensagem = PM_Cadastrado;
                        men.ShowDialog();
                        btn_Limpar(sender, e);
                        GridInicial(sender, e);
                    }
                }
                              
            }
        }
    }
}
