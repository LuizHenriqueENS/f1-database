using System; // EventArgs
using System.Collections.Generic;
using System.ComponentModel; // CancelEventArgs
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows; // window
using System.Windows.Controls;

namespace F1 {
    /// <summary>
    /// Interaction logic for CadastroPilotos.xaml
    /// </summary>
    public partial class CadastroPilotos : Window {
        public CadastroPilotos() {
            InitializeComponent();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
            Window? mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mw == null) {
                MainWindow main = new();
                main.Show();
            }
            else {
                Console.WriteLine("Teste");
            }

            base.OnClosing(e);
        }

        private void Gerenciador_Input(object sender, System.Windows.Input.MouseButtonEventArgs e) {

        }

        private void CampoSelecionado(object sender, RoutedEventArgs e) {

        }

        private void CampoDesselecionado(object sender, RoutedEventArgs e) {
            TextBox? txt = sender as TextBox;
        }

        private void FalecidoCheck(object sender, RoutedEventArgs e) {
            campo_dataFalecimento.IsEnabled = true;
        }

        private void FalecidoUnchecked(object sender, RoutedEventArgs e) {
            campo_dataFalecimento.IsEnabled = false;
        }

        private static readonly Regex _regexTXT = new Regex("[a-zA-Z]+"); //regex that matches disallowed text
        private static readonly Regex _regexNUMBERS = new Regex("[^0-9.-]+"); //regex that matches disallowed text
      //  private static readonly Regex _regexDate = new Regex(@"[^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec)))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)(?:0?2|(?:Feb))\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text) {
            return !_regexTXT.IsMatch(text);
        }
        private static bool IsNumbersAllowed(string text) {
            return !_regexNUMBERS.IsMatch(text);
        }


        private void AbrirPopUp(object sender, RoutedEventArgs e) {
            bool tudoOK = true;
            if (IsTextAllowed(campo_nome.Text)) {
                PopUp("O campo NOME possui caracteres inválidos", "Continuar", MessageBoxButton.OK, MessageBoxImage.Warning);
                tudoOK = false;
            }
            if (IsTextAllowed(campo_nascimento.Text)) {
                PopUp("O campo LOCAL DO NASCIMENTO possui caracteres inválidos", "Continuar", MessageBoxButton.OK, MessageBoxImage.Warning);
                tudoOK = false;
            }
            if (IsTextAllowed(campo_licenca.Text)) {
                PopUp("O campo País de Licença possui caracteres inválidos", "Continuar", MessageBoxButton.OK, MessageBoxImage.Warning);
                tudoOK = false;
            }

            if (tudoOK) {
                MessageBoxResult result = PopUp($"Você deseja cadastrar o piloto '{campo_nome.Text}'?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.None);
                if (result == MessageBoxResult.Yes) {
                    AdicionarPilotoAoBanco();

                    
                    Excluir excluir = new();
                    excluir.Show();
                }
            }


        }

        private MessageBoxResult PopUp(string messageBoxText, string caption, MessageBoxButton msgBtn, MessageBoxImage msgImg) {
            MessageBoxButton button = msgBtn;
            MessageBoxImage icon = msgImg;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            return result;
        }

        private void AdicionarPilotoAoBanco() {
            Piloto p = new();
            if (campo_dataFalecimento.Text.Trim() == "") {
                p = new(campo_nome.Text, campo_nascimento.Text, DateTime.Parse(campo_dataNascimento.Text).Date, campo_licenca.Text, p.Identificacao());
            }
            else {
                p = new(campo_nome.Text, campo_nascimento.Text, DateTime.Parse(campo_dataNascimento.Text), DateTime.Parse(campo_dataFalecimento.Text).Date, campo_licenca.Text, p.Identificacao());
            }

            Banco.AdicionarPiloto(p);
        }
    }

}
