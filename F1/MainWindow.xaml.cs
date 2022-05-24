using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
namespace F1 {
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
    }
}
