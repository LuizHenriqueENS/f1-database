using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace F1 {
    /// <summary>
    /// Interaction logic for Tabela.xaml
    /// </summary>
    public partial class Tabela : Window {
        public Tabela() {
            InitializeComponent();
            CriarListaPilotos();
        }

        private void CriarListaPilotos() {
            List<Piloto> p = new();
            var x = Banco.ObterTodosPilotos();
            foreach (DataRow dr in x.Rows) {
                if (!(bool)dr["ESTAVIVO"]) {
                    p.Add(new Piloto(dr["NOME"].ToString(),
                    dr["NOME_PROFISSIONAL"].ToString(),
                    DateTime.Parse(dr["NASCIMENTO"].ToString()),
                    dr["NACIONALIDADE"].ToString(), dr["CIDADE_NAS"].ToString(),
                    (bool)dr["ESTAVIVO"], dr["PAISDELICENCA"].ToString(), dr["CHAVEIDENTIFICACAO"].ToString()));
                }
                else {
                    p.Add(new Piloto(dr["NOME"].ToString(),
                        dr["NOME_PROFISSIONAL"].ToString(),
                        dataDoNascimento: DateTime.Parse(dr["NASCIMENTO"].ToString()),
                        dr["NACIONALIDADE"].ToString(), dr["CIDADE_NAS"].ToString(),
                        DateTime.Parse(dr["FALECIMENTO"].ToString()), dr["CIDADE_FAL"].ToString(), (bool)dr["ESTAVIVO"], dr["PAIS_FAL"].ToString(), dr["PAISDELICENCA"].ToString(), dr["CHAVEIDENTIFICACAO"].ToString()));
                }
            }
            tabela.ItemsSource = p;
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e) {
            ListViewItem? li = sender as ListViewItem;
            _ = li.Content as Piloto;

        }

        private void ClickDuplok(object sender, MouseButtonEventArgs e) {
            ListViewItem? li = sender as ListViewItem;
            Piloto? p = li.Content as Piloto;
            MessageBoxResult result = MessageBox.Show($"Você deseja deletar {p.Nome} do banco de dados?", "Deletar?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes) {
                Banco.DeletarPiloto(p.Nome);
                CriarListaPilotos();
            }
        }
    }
}
