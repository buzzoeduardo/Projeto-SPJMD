using ControleSPJMD.Controle;
using ControleSPJMD.Mensagens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        public string? PM_Cadastrado { get; private set; }
        public string? RE_PM { get; private set; }
        public string? Id_PM { get; set; }

        public bool Del_PM = false;
        public Policial()
        {
            InitializeComponent();
            lblBuzzoDeveloper.Content = "Buzzo® Developer - " + DateTime.Now.Year.ToString();
            lblNomeGridPM.Content = "POLICIAIS MILITARES";
            gridPmPrincipal.DataContext = control.PM_Principal();
        }

        private void PermitirNumeros(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        public void GridInicial(object sender, RoutedEventArgs e)
        {
            btn_Limpar(sender, e);  
            gridPmPrincipal.DataContext = control.PM_Principal();
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
            txtEmail.Text = "@policiamilitar.sp.gov.br";
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
                btnRetornar.Visibility = Visibility.Visible;
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
                    if (txtNomePM.Text.Length < 3)
                    {
                        MessageBox.Show("Nome muito curto. \n\rInsira um nome com 3 (três) ou mais caracteres.",
                            "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        string dtNasc = "";
                        string dtAdm = "";
                        if (string.IsNullOrEmpty(dataNasc.Text))
                        {
                            dtNasc = DateTime.MinValue.ToString();
                        }
                        else
                        {
                            dtNasc = dataNasc.Text;
                        }
                        if (string.IsNullOrEmpty(dataAdm.Text))
                        {
                            dtAdm = DateTime.MinValue.ToString();
                        }
                        else
                        {
                            dtAdm = dataAdm.Text;
                        }
                        control.Salvar_Policial(txtRE.Text, txtDig.Text, cbxPostGrad.Text, txtNomePM.Text, txtEmail.Text, txtCpf.Text, txtRg.Text,
                            dtNasc, dtAdm, txtTelefone.Text, txtTelefone2.Text, "Ativo");
                        PM_Cadastrado = control.Resultado;
                        if (!string.IsNullOrEmpty(PM_Cadastrado))
                        {
                            Mensagem_PM_Cadastrado men = new Mensagem_PM_Cadastrado();
                            men.Mensagem = PM_Cadastrado;
                            men.ShowDialog();
                            btn_Limpar(sender, e);
                            GridInicial(sender, e);
                        }
                        else
                        {
                            txtRE.Clear();
                            txtDig.Clear();
                        }
                    }
                }

            }
        }

        private void btnPesquisaPm_Click(object sender, RoutedEventArgs e)
        {
            if (txtPesquisaPm.Text.Length < 3)
            {
                MessageBox.Show("Digite 3 (três) ou mais caracteres para pesquisar.", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                gridPmPrincipal.DataContext = control.Pesquisa_PM(txtPesquisaPm.Text);
            }
            txtPesquisaPm.Clear();
        }

        private void btnAtualizarPm_Click(object sender, RoutedEventArgs e)
        {
            gridPmPrincipal.DataContext = control.PM_Principal();
        }

        private void dtPmPrincipal_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (btnEditarPm.Visibility == Visibility.Collapsed)
            {
                btnEditarPm.Visibility = Visibility.Visible;
                DataRowView? x = dtPmPrincipal.SelectedItem as DataRowView;

                RE_PM = x?[1].ToString();
            }
        }

        private void btnEditarPm_Click(object sender, RoutedEventArgs e)
        {
            if (gridEditarPM.Visibility == Visibility.Collapsed)
            {
                gridEditarPM.Visibility = Visibility.Visible;
                gridPmPrincipal.Visibility = Visibility.Collapsed;
            }

            DataTable dt = new DataTable();
            dt = control.Editar_PM(RE_PM);

            Id_PM = dt.Rows[0][4].ToString();

            cbxPostGrad_Editar.SelectedItem = dt.Rows[0][0].ToString();
            txtRE_Editar.Text = dt.Rows[0][1].ToString();
            txtDig_Editar.Text = dt.Rows[0][2].ToString();
            txtNomePM_Editar.Text = dt.Rows[0][3].ToString();          
            txtEmail_Editar.Text = dt.Rows[0][5].ToString().Trim();
            txtCpf_Editar.Text = dt.Rows[0][6].ToString();
            txtRg_Editar.Text = dt.Rows[0][7].ToString();
            
            string? nasc = dt.Rows[0][8].ToString();
            DateTime dtNasc = DateTime.Parse(nasc);            
            dataNasc_Editar.Text = dtNasc.ToString("dd/MM/yyyy");

            string? adm = dt.Rows[0][9].ToString();
            DateTime dtAdm = DateTime.Parse(adm);
            dataAdm_Editar.Text = dtAdm.ToString("dd/MM/yyyy");

            txtTelefone_Editar.Text = dt.Rows[0][10].ToString();
            txtTelefone2_Editar.Text = dt.Rows[0][11].ToString();
            cbxSituacao_Editar.SelectedItem = dt.Rows[0][12];            
        }

        private void btnSalvarPM_Editar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbxPostGrad_Editar.Text) || string.IsNullOrEmpty(txtNomePM_Editar.Text) || string.IsNullOrEmpty(txtRE_Editar.Text) || string.IsNullOrEmpty(txtDig_Editar.Text))
            {
                MessageBox.Show("Preencha os Campo Obrigatórios", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (txtRE_Editar.Text.Length != 6)
                {
                    MessageBox.Show("RE inválido. O RE precisa conter 6 (seis) dígitos.", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    if (txtNomePM_Editar.Text.Length < 3)
                    {
                        MessageBox.Show("Nome muito curto. \n\rInsira um nome com 3 (três) ou mais caracteres.",
                            "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        string dtNasc = "";
                        string dtAdm = "";
                        if (string.IsNullOrEmpty(dataNasc_Editar.Text))
                        {
                            dtNasc = DateTime.MinValue.ToString();
                        }
                        else
                        {
                            dtNasc = dataNasc_Editar.Text;
                        }
                        if (string.IsNullOrEmpty(dataAdm_Editar.Text))
                        {
                            dtAdm = DateTime.MinValue.ToString();
                        }
                        else
                        {
                            dtAdm = dataAdm_Editar.Text;
                        }
                        control.Salvar_Edit_PM(Id_PM, txtRE_Editar.Text, txtDig_Editar.Text, cbxPostGrad_Editar.Text, txtNomePM_Editar.Text, 
                            txtEmail_Editar.Text, txtCpf_Editar.Text, txtRg_Editar.Text,
                            dtNasc, dtAdm, txtTelefone_Editar.Text, txtTelefone2_Editar.Text, cbxSituacao_Editar.Text);
                        PM_Cadastrado = control.Resultado;
                        if (!string.IsNullOrEmpty(PM_Cadastrado))
                        {
                            Mensagem_PM_Editado men = new Mensagem_PM_Editado();
                            men.Mensagem = PM_Cadastrado;
                            men.Situacao = cbxSituacao_Editar.Text.ToString();
                            men.ShowDialog();
                            btn_Limpar(sender, e);
                            GridInicial(sender, e);
                        }
                        else
                        {
                            txtRE.Clear();
                            txtDig.Clear();
                        }
                    }
                }

            }
        }

        private void btnDeletarPM_Click(object sender, RoutedEventArgs e)
        {
            control.Deletar_PM(Id_PM);
            if(control.PM_Vinc == false)
            {
                Del_PM = true;
                Mensagem_Confirmar_Delete men = new Mensagem_Confirmar_Delete();
                men.DelPM = Del_PM;
                men.Id_PM = Id_PM;
                men.ShowDialog();                
                Retornar(sender, e);
            }
            Del_PM = false;
        }
      
    }
}
