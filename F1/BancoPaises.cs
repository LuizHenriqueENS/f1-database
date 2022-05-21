using System;
using System.Data;
using System.Data.SQLite;

namespace F1 {
    internal class BancoPaises {
        private static SQLiteConnection conexao;

        private static string caminho = Environment.CurrentDirectory;
        private static string nomeBanco = "banco_paises.db";
        private static string caminhoBanco = caminho + @"\banco\";


        private static SQLiteConnection ConexaoBanco() {
            conexao = new SQLiteConnection("Data Source =" + caminhoBanco + nomeBanco);
            conexao.Open();
            return conexao;
        }

        public static DataTable ObterTodosOsPaises() {
            SQLiteDataAdapter? da = null;

            DataTable dt = new DataTable();

            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "SELECT * FROM bd_paises";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        public static void AdicionarPaises(Paises paises) {
            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "INSERT INTO bd_paises(ID, T_PAIS, ISO2) values (@Id, @Pais, @Iso2)";
                    cmd.Parameters.AddWithValue("@Id", paises.Id);
                    cmd.Parameters.AddWithValue("@Pais", paises.Name);
                    cmd.Parameters.AddWithValue("@Iso2", paises.Iso2);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }


        public static void AdicionarCidades(Cidades cidades) {
            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "INSERT INTO bd_cidades(I_ID, T_NOME, I_ID_PAIS, T_CODIGO_PAIS, I_ISO2) values (@Id, @Nome, @Id_Pais, @Codigo_pais, @Iso2)";
                    cmd.Parameters.AddWithValue("@Id", cidades.ID);
                    cmd.Parameters.AddWithValue("@Nome", cidades.Name);
                    cmd.Parameters.AddWithValue("@Id_Pais", cidades.Country_Id);
                    cmd.Parameters.AddWithValue("@Codigo_pais", cidades.Country_Code);
                    cmd.Parameters.AddWithValue("@Iso2", cidades.ISO2);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
