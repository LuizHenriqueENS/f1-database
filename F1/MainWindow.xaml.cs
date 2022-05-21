using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace F1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void ResizeWindowsOrMove(object sender, RoutedEventArgs e) {
            string ws = WindowStyle.ToString();

            if (ws == "None") {

                WindowStyle = WindowStyle.ThreeDBorderWindow;
            }
            else {
                WindowStyle = WindowStyle.None;

            }

        }
        private void QuitApp(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void TelaCadastroDePilotos(object sender, RoutedEventArgs e) {
            CadastroPilotos? telasAbertas = Application.Current.Windows.OfType<CadastroPilotos>().FirstOrDefault();

            if (telasAbertas == null) {
                CadastroPilotos p = new();
                p.Show();

                Window? mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                if (mw != null) { mw.Close(); }

            }
            else {
                Console.WriteLine("Já está aberta");
            }

        }

        private async void AddPaises(object sender, RoutedEventArgs e) {
            AdicionarAoBD();
        }

        public async void AdicionarAoBD() {

            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Add("X-CSCAPI-KEY", "MHBlNDdEMUM3aGJ6UWZIdTdoQU0xaGQweGM4WW13R1NsVzB5WW9uRQ==");
                var result = await client.GetStringAsync("https://api.countrystatecity.in/v1/states");
                var lista = JsonConvert.DeserializeObject<List<Cidades>>(result);
                foreach (var ache in lista) {
                    BancoPaises.AdicionarCidades(new Cidades(ache.ID, ache.Name, ache.Country_Id, ache.Country_Code, ache.ISO2));
                }

            }
        }
    }
}
