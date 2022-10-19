using System; // EventArgs
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows; // window
using System.Windows.Controls;
using System.Windows.Input;

namespace F1 {
    public partial class CadastroPilotos : Window {

        private static readonly Regex _regexTXT = new Regex("[a-zA-Z]+"); //regex that matches disallowed text
        private static readonly Regex _regexNUMBERS = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        bool falecido = false;

        public CadastroPilotos() {
            InitializeComponent();
            comboBox.ItemsSource = ComboBoxPaises.MostrarPaises();
            input_paisFal.ItemsSource = ComboBoxPaises.MostrarPaises();
            comboBoxPaisLicenca.ItemsSource = ComboBoxPaises.MostrarPaises();
        }

        #region CHECK_BOX
        private void Falecido(object sender, RoutedEventArgs e) {
            txt_cidadeFal.Opacity = 1;
            txt_dataObito.Opacity = 1;
            txt_paisFalecimento.Opacity = 1;

            input_paisFal.IsEnabled = true;
            input_dataObito.IsEnabled = true;
            input_cidadeFalecimento.IsEnabled = true;

            falecido = true;
        }

        private void FalecidoUnchecked(object sender, RoutedEventArgs e) {
            txt_cidadeFal.Opacity = 0.2;
            txt_dataObito.Opacity = 0.2;
            txt_paisFalecimento.Opacity = 0.2;

            input_paisFal.IsEnabled = false;
            input_dataObito.IsEnabled = false;
            input_cidadeFalecimento.IsEnabled = false;

            falecido = false;
        }
        #endregion
        #region Campos digitáveis
        private void AdicionarPilotoAoBanco(object sender, RoutedEventArgs e) {
            Piloto p;
            if ((bool)isFalecido.IsChecked) {
                var t1 = DateTime.Parse(input_dataObito.Text);
                var t2 = DateTime.Parse(dataNascimento.Text);
                if (input_cidadeFalecimento.Text == "") {
                    PopUp("O campo 'Cidade de falecimento' está vazio", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (input_dataObito.Text == "") {

                    PopUp("O campo 'Data de Óbito' está vazio", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (input_paisFal.Text == "") {

                    PopUp("O campo 'País de falecimento' está vazio", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (t1.Ticks < t2.Ticks) {
                    PopUp("A data de óbito não pode ser menor que a data de nascimento", "ERRO", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else {
                    p = new Piloto(nomeCompleto.Text.Trim(), nomeProfissional.Text.Trim(), DateTime.Parse(dataNascimento.Text), comboBox.Text.Trim(), comboBoxCidade.Text.Trim(),
                    DateTime.Parse(input_dataObito.Text), input_cidadeFalecimento.Text.Trim(), falecido, input_paisFal.Text.Trim(), comboBoxPaisLicenca.Text.Trim());
                    Banco.AdicionarPiloto(p);
                    LimparCampos();
                }
            }
            else {
                if (nomeCompleto.Text == "") {
                    PopUp("O campo 'Nome profissional' está vazio", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (nomeProfissional.Text == "") {
                    PopUp("O campo 'Nome profissional' está vazio", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (comboBox.Text == "") {
                    PopUp("O campo 'Nacionalidade' está vazio", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                }

                else if (comboBoxCidade.Text == "") {
                    PopUp("O campo 'Cidade de nascimento' está vazio", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (dataNascimento.Text == "") {
                    PopUp("O campo 'Data de nascimento' está vazio", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (comboBoxPaisLicenca.Text == "") {
                    PopUp("O campo 'País da licença' está vazio", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else {

                    string nome = nomeCompleto.Text.Trim();
                    string nomeProfissionalTxt = nomeProfissional.Text.Trim();
                    DateTime dt = DateTime.Parse(dataNascimento.Text);
                    string nacionalidade = comboBox.Text.Trim();
                    string cidadeNascimento = comboBoxCidade.Text.Trim();
                    string paisDaLicenca = comboBoxPaisLicenca.Text.Trim();

                    p = new Piloto(nome, nomeProfissionalTxt, dt, nacionalidade, cidadeNascimento, false, paisDaLicenca);
                    Banco.AdicionarPiloto(p);
                    LimparCampos();
                }


            }
        }
        private void AdicionarCidadeAoBD(object sender, RoutedEventArgs e) {
            ComboBox? cb = e.Source as ComboBox;
            ComboBox? parente = ParenteCOMBO_BOX(cb);
            if (!BancoPaises.FiltrarCidades(cb.Text) && cb.Text != "" && cb.Text.Length > 2) {
                MessageBoxResult resposta = PopUp("A cidade não consta no banco de dados. Deseja adicioná-la?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resposta == MessageBoxResult.Yes) {
                    BancoPaises.AdicionarCidadesPT(cb.Text, parente.Text);
                }
                else {
                    cb.Text = "";
                }
            }
        }
        private void AdicionarPaisAoBD(object sender, RoutedEventArgs e) {
            ComboBox? cb = e.Source as ComboBox;

            if (!BancoPaises.FiltrarPaises(cb.Text) && cb.Text != "" && cb.Text.Length > 2) {
                MessageBoxResult resposta = PopUp("A cidade não consta no banco de dados. Deseja adicioná-la?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resposta == MessageBoxResult.Yes) {
                    BancoPaises.AdicionarPaisesPT(cb.Text);
                }
                else {
                    cb.Text = "";
                }
            }

        }
        private void AtivarCampoCidade(object sender, KeyEventArgs e) {
            ComboBox? cb = e.Source as ComboBox;
            if (cb.Text.Length > 0) {
                if (cb.Name == "comboBox") {
                    comboBoxCidade.IsEnabled = true;
                }
                else if (cb.Name == "input_paisFal") {
                    input_cidadeFalecimento.IsEnabled = true;
                }
            }
        }
        private void FiltrarCidades(object sender, RoutedEventArgs e) {
            ComboBox? cb = e.Source as ComboBox;
            List<string> lista = new();
            ComboBox? parente = ParenteCOMBO_BOX(cb);
            foreach (DataRow dr in BancoPaises.ObterTodosAsCidades().Rows) {
                if (dr["PAIS"].ToString() == parente.Text) {
                    lista.Add(dr["NOME"].ToString());
                }
            }
            cb.ItemsSource = lista;
        }
        private void NomeCompleto_LostFocus(object sender, RoutedEventArgs e) {
            TextBox? textBox = sender as TextBox;
            if (Banco.listaDePilotos(textBox.Text)) {
                PopUp($"O piloto '{textBox.Text}' consta no banco de dados", "Piloto já registrado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                textBox.Text = "";
            }

        }
        private void LimparCampos() {
            nomeCompleto.Text = "";
            nomeProfissional.Text = "";
            comboBox.Text = "";
            comboBoxCidade.Text = "";
            dataNascimento.Text = "05/03/1980";
            comboBoxPaisLicenca.Text = "";
            input_dataObito.Text = "";
            input_paisFal.Text = "";
            input_cidadeFalecimento.Text = "";
            isFalecido.IsChecked = false;
            PopUp("PILOTO ADICIONADO COM SUCESSO!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private ComboBox ParenteCOMBO_BOX(ComboBox? cb) {
            ComboBox? parente = cb.Name switch {
                "comboBoxCidade" => comboBox,
                "input_cidadeFalecimento" => input_paisFal,
                _ => null,
            };
            return parente;
        }
        #endregion


        private static bool IsTextAllowed(string text) {
            return !_regexTXT.IsMatch(text);
        }
        private static bool IsNumbersAllowed(string text) {
            return !_regexNUMBERS.IsMatch(text);
        }
        protected override void OnClosing(CancelEventArgs e) {
            Window? mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mw == null) {
                MainWindow main = new();
                main.Show();
            }
            else {
            }
            base.OnClosing(e);
        }
        private MessageBoxResult PopUp(string messageBoxText, string caption, MessageBoxButton msgBtn, MessageBoxImage msgImg) {
            MessageBoxButton button = msgBtn;
            MessageBoxImage icon = msgImg;
            MessageBoxResult result;


            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            return result;
        }

    }
}
