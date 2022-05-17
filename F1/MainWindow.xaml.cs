using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
