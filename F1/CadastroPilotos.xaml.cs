using System; // EventArgs
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows; // window
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections;

namespace F1 {
    public partial class CadastroPilotos : Window {

        private static readonly Regex _regexTXT = new Regex("[a-zA-Z]+"); //regex that matches disallowed text
        private static readonly Regex _regexNUMBERS = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        bool falecido = false;
        List<Cidades> cidades = new();

        public CadastroPilotos() {
            InitializeComponent();
            comboBox.ItemsSource = ComboBoxPaises.MostrarPaises();
            input_paisFal.ItemsSource = ComboBoxPaises.MostrarPaises();
            comboBoxPaisLicenca.ItemsSource = ComboBoxPaises.MostrarPaises();
        }

        //private void AbrirPopUp(object sender, RoutedEventArgs e) {
        //    bool tudoOK = true;
        //    if (IsTextAllowed(campo_nome.Text)) {
        //        PopUp("O campo NOME possui caracteres inválidos", "Continuar", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        tudoOK = false;
        //    }
        //    if (IsTextAllowed(campo_nascimento.Text)) {
        //        PopUp("O campo LOCAL DO NASCIMENTO possui caracteres inválidos", "Continuar", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        tudoOK = false;
        //    }
        //    if (IsTextAllowed(campo_licenca.Text)) {
        //        PopUp("O campo País de Licença possui caracteres inválidos", "Continuar", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        tudoOK = false;
        //    }

        //    if (tudoOK) {
        //        MessageBoxResult result = PopUp($"Você deseja cadastrar o piloto '{campo_nome.Text}'?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.None);
        //        if (result == MessageBoxResult.Yes) {
        //            AdicionarPilotoAoBanco();
        //        }
        //    }


        //}

        private MessageBoxResult PopUp(string messageBoxText, string caption, MessageBoxButton msgBtn, MessageBoxImage msgImg) {
            MessageBoxButton button = msgBtn;
            MessageBoxImage icon = msgImg;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            return result;
        }

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

        private void AdicionarPilotoAoBanco(object sender, RoutedEventArgs e) {
            Piloto p = new();
            if ((bool)isFalecido.IsChecked) {
                
            }
            else {

            }
         //   Banco.AdicionarPiloto(p);
        }


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

    }

}
