using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace F1 {
    /// <summary>
    /// Interaction logic for Excluir.xaml
    /// </summary>
    public partial class Excluir : Window {
        public Excluir() {
            InitializeComponent();
            List<Piloto> dt = new();
            foreach (DataRow item in Banco.ObterTodosPilotos().Rows) {
                Console.WriteLine(item);
            }
            pilotos.ItemsSource = dt;
        }
    }
}
