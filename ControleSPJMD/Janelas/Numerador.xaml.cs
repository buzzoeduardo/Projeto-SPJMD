using ControleSPJMD.Controle;
using ControleSPJMD.Mensagens;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ControleSPJMD.Janelas
{
    public partial class Numerador : Window
    {
        Controle_Numerador control = new Controle_Numerador();
        DataTable dt = new DataTable();
        RadioButton rb = new RadioButton();

        public string? IdUsuario { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Numero { get; set; }
        public string? IdNumerador { get; set; }

        public Numerador(string? idUsuario, string nomeUsuario, string? numero, string? idNumerador)
        {
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            Numero = numero;
            IdNumerador = idNumerador;
        }

        public Numerador()
        {
            InitializeComponent();
            lblBuzzoDeveloper.Content = "Buzzo® Developer - " + DateTime.Now.Year.ToString();
            lblNomeGridNum.Content = "NUMERADORES";
            dataNumInicio.Text = "01/01/" + DateTime.Now.Year.ToString();
            dataNumFim.Text = DateTime.Now.ToString();
        }

        public void GridInicial(object sender, RoutedEventArgs e)
        {
            btnRetornar.Visibility = Visibility.Collapsed;
            gridPrincipalNum.Visibility = Visibility.Visible;
            gridNovoNumerador.Visibility = Visibility.Collapsed;
            gridPesqNum.Visibility = Visibility.Collapsed;
            gridEditarNumerador.Visibility = Visibility.Collapsed;
            AcionarCalendarioNum(sender, e);
            lblNomeGridNum.Content = "NUMERADORES";
            dataNumInicio.Text = "01/01/" + DateTime.Now.Year.ToString();
            dataNumFim.Text = DateTime.Now.ToString();
            lblQtdRegistrosPesquisaNum.Content = null;
            btnEditarNum.Visibility = Visibility.Collapsed;
            rb.IsChecked = false;
        }

        public void ResetarVariaveis()
        {
            dt.Clear();
            rb.IsChecked = false;
        }

        private void btnRetornar_Click(object sender, RoutedEventArgs e)
        {
            GridInicial(sender, e);
        }

        private void btnFecharPrograma_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnNovoNum_Click(object sender, RoutedEventArgs e)
        {
            ResetarVariaveis();
            btnRetornar.Visibility = Visibility.Visible;
            btnEditarNum.Visibility=Visibility.Collapsed;
            if (gridNovoNumerador.Visibility == Visibility.Collapsed)
            {
                gridNovoNumerador.Visibility = Visibility.Visible;
                lblNomeGridNum.Content = btnNovoNum.Content;
                gridPrincipalNum.Visibility = Visibility.Collapsed;
                gridPesqNum.Visibility = Visibility.Collapsed;
                gridEditarNumerador.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSalvarNumerador_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbxTipoDocumento.Text) || string.IsNullOrEmpty(txtAssuntoNum.Text))
            {
                MessageBox.Show("Preencha os Campo Obrigatórios", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (txtAssuntoNum.Text.Length < 4)
                {
                    MessageBox.Show("Texto muito curto. \n\rPara uma melhor segurança e controle, insira um texto com mais de 4 (quatro) caracteres no campo \"Assunto\".", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    control.Salvar_Numerador(cbxTipoDocumento.Text.ToString(), txtAssuntoNum.Text, txtDestinoNum.Text, txtReferenciaNum.Text, txtAnexoNum.Text, IdUsuario);
                    Numero = control.Resultado;
                    Mensagem_Num_Cadastrado men = new Mensagem_Num_Cadastrado();
                    men.MensagemNum = Numero;
                    men.ShowDialog();
                    btnLimparNumerador_Click(sender, e);
                    GridInicial(sender, e);
                }
            }
        }

        private void btnLimparNumerador_Click(object sender, RoutedEventArgs e)
        {
            cbxTipoDocumento.SelectedIndex = -1;
            txtAssuntoNum.Clear();
            txtReferenciaNum.Clear();
            txtAnexoNum.Clear();
            txtDestinoNum.Clear();
        }

        private void btnPesqNumerador_Click(object sender, RoutedEventArgs e)
        {
            ResetarVariaveis();
            btnRetornar.Visibility = Visibility.Visible;
            btnEditarNum.Visibility = Visibility.Collapsed;
            if (gridPesqNum.Visibility == Visibility.Collapsed)
            {
                gridPesqNum.Visibility = Visibility.Visible;
                lblNomeGridNum.Content = btnPesqNumerador.Content;
                gridPrincipalNum.Visibility = Visibility.Collapsed;
                gridNovoNumerador.Visibility = Visibility.Collapsed;
                gridEditarNumerador.Visibility = Visibility.Collapsed;
            }
        }


        private void btnPesquisaNum_Click(object sender, RoutedEventArgs e)
        {
            if (txtPesquisaNum.Text.Length < 3)
            {
                MessageBox.Show("Digite 3 (três) ou mais caracteres para pesquisar.", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (rdbAnoAtualNum.IsChecked == true)
                {
                    dt = control.Pesq_NumAtual(txtPesquisaNum.Text);
                    dtNumeradores.DataContext = dt;
                    lblQtdRegistrosPesquisaNum.Content = dt.Rows.Count + " registros";
                }
                else
                {
                    dt = control.Pesq_NumAnterior(txtPesquisaNum.Text);
                    dtNumeradores.DataContext = dt;
                    lblQtdRegistrosPesquisaNum.Content = dt.Rows.Count + " registros";
                }
            }
            txtPesquisaNum.Clear();
        }

        private void rdbMemorando_Click(object sender, RoutedEventArgs e)
        {
            rb = (RadioButton)sender;
            btnEditarNum.Visibility = Visibility.Collapsed;
            if (dataNumFim.SelectedDate < dataNumInicio.SelectedDate)
            {
                AcionarCalendarioNum(sender, e);
                MessageBox.Show("A Data de término não pode ser anterior a data de início.", "ATENÇÃO!", MessageBoxButton.OK, MessageBoxImage.Warning);
                dataNumFim.Text = DateTime.Now.ToString();
                dataNumInicio.Text = "01/01/" + DateTime.Now.Year.ToString();
            }
            else
            {
                var dataInicio = DateTime.Parse(dataNumInicio.Text).ToString("yyyy/MM/dd");
                var dataFin = DateTime.Parse(dataNumFim.Text).ToString("yyy/MM/dd");
                dt.Clear();
                dt = control.Numerador_Principal(rb.Content.ToString(), dataInicio.Replace("/", "-"), dataFin.Replace("/", "-"));

                dtNumPrinc.DataContext = dt;
                lblQtdResNumPrincipal.Content = dt.Rows.Count + " registros";
            }
        }

       
        private void AcionarCalendarioNum(object sender, RoutedEventArgs e)
        {
            ResetarVariaveis();            
           
            dtNumPrinc.DataContext = dt;
            lblQtdResNumPrincipal.Content = null;
            btnEditarNum.Visibility = Visibility.Collapsed;
        }

        private void MudarTextoDataNum(object sender, TextCompositionEventArgs e)
        {
            AcionarCalendarioNum(sender, e);
        }


        private void dtNumPrinc_RowDetailsVisibilityChanged(object sender, DataGridRowDetailsEventArgs e)
        {            
            if (gridPrincipalNum.Visibility == Visibility.Visible)
            {
                DataRowView? x = dtNumPrinc.SelectedItem as DataRowView;
               
                if (x?[0].ToString() == NomeUsuario && x?.Row[9] == "")
                {
                    IdNumerador = x?[1].ToString();
                    if (btnEditarNum.Visibility == Visibility.Collapsed)
                    {
                        btnEditarNum.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    if (btnEditarNum.Visibility == Visibility.Visible)
                    {
                        btnEditarNum.Visibility = Visibility.Collapsed;
                    }
                }
            }
            if (gridPesqNum.Visibility == Visibility.Visible)
            {
                var x = dtNumeradores.SelectedItem as DataRowView;
                var xx = x[9].ToString();
                if (x?[0].ToString() == NomeUsuario && xx == "")
                {
                    IdNumerador = x?[1].ToString();
                    if (btnEditarNum.Visibility == Visibility.Collapsed)
                    {
                        btnEditarNum.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    if (btnEditarNum.Visibility == Visibility.Visible)
                    {
                        btnEditarNum.Visibility = Visibility.Collapsed;
                    }
                }
            }           
        }

        private void btnEditarNum_Click(object sender, RoutedEventArgs e)
        {
            rb.IsChecked = false;
            btnRetornar.Visibility = Visibility.Visible;
            gridEditarNumerador.Visibility = Visibility.Visible;
            gridPrincipalNum.Visibility = Visibility.Collapsed;
            gridPesqNum.Visibility = Visibility.Collapsed;
            gridNovoNumerador.Visibility = Visibility.Collapsed;
            btnEditarNum.Visibility = Visibility.Collapsed;
            lblNomeGridNum.Content = btnEditarNum.Content;

            dt = control.Pesq_Num_Por_Id(IdNumerador);

            DateTime da = DateTime.Parse(dt.Rows[0][5].ToString());

            lblNumeroCompleto.Content = dt.Rows[0][2].ToString() + " Nº 9BPMI-" + dt.Rows[0][3].ToString() + "/13/" + da.ToString("yy");
            lblAssuntoEditar.Content = dt.Rows[0][4].ToString();
            txtAnexoEditarNum.Text = dt.Rows[0][8].ToString();
            txtDestinoEditarNum.Text = dt.Rows[0][6].ToString();
            txtReferenciaEditarNum.Text = dt.Rows[0][7].ToString();
        }

        private void btnSalvarEditarNum_Click(object sender, RoutedEventArgs e)
        {
            control.Editar_Numerador(IdNumerador, txtReferenciaEditarNum.Text, txtAnexoEditarNum.Text, txtDestinoEditarNum.Text, "");
            btnRetornar_Click(sender, e);
        }

        private void btnCancelarNumerador_Click(object sender, RoutedEventArgs e)
        {
            CancelarNumerador cancelar = new CancelarNumerador();
            cancelar.IdNum = IdNumerador;
            cancelar.Referencia = txtReferenciaEditarNum.Text;
            cancelar.Anexo = txtAnexoEditarNum.Text;
            cancelar.Destino = txtDestinoEditarNum.Text;
            cancelar.ShowDialog();
            btnRetornar_Click(sender, e);
        }
    }
}
