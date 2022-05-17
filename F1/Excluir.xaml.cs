using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
            foreach (DataRow row in Banco.ObterTodosPilotos().Rows) {
                if (row["DT_DATAFALECIMENTO"].ToString() == "") {
                    dt.Add(new Piloto(
                    row["T_NOMEPILOTO"].ToString(),
                    row["T_LOCALNASCIMENTO"].ToString(),
                    DateTime.Parse(row["DT_NASCIMENTO"].ToString()),
                    row["T_PAISDELICENCA"].ToString(),
                    row["T_CHAVEIDENTIFICACAO"].ToString()));
  
                }
                else {
                    dt.Add(new Piloto(
                        row["T_NOMEPILOTO"].ToString(),
                        row["T_LOCALNASCIMENTO"].ToString(),
                        DateTime.Parse(row["DT_NASCIMENTO"].ToString()).Date,
                        DateTime.Parse(row["DT_DATAFALECIMENTO"].ToString()).Date,
                        row["T_PAISDELICENCA"].ToString(),
                        row["T_CHAVEIDENTIFICACAO"].ToString()));
                    
                }
            }

            pilotos.ItemsSource = dt;

        }

        public ListView Pilotos() {
            return pilotos;
        }
    }
}
