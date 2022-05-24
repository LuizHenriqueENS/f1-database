using System;
using System.Data;
using System.Data.SQLite;

namespace F1 {
    internal class BancoPaises {
        private static SQLiteConnection conexao;

        private static string caminho = Environment.CurrentDirectory;
        private static string nomeBanco = "banco_paises.db";
        private static string caminhoBanco = caminho + @"\banco\";


        #region Iniciar conexao com BD
        private static SQLiteConnection ConexaoBanco() {
            conexao = new SQLiteConnection("Data Source =" + caminhoBanco + nomeBanco);
            conexao.Open();
            return conexao;
        } 
        #endregion

        #region Obter todos os paises
        public static DataTable ObterTodosOsPaises() {
            SQLiteDataAdapter? da = null;

            DataTable dt = new DataTable();

            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "SELECT * FROM tb_paises";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex) {

                throw ex;
            }
        }
        #endregion
        #region Obter todos os paisesPT
        public static DataTable ObterTodosOsPaisesPT() {
            SQLiteDataAdapter? da = null;

            DataTable dt = new DataTable();

            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "SELECT * FROM tb_paisesPT";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex) {

                throw ex;
            }
        }
        #endregion
        #region Obter todos os estados
        public static DataTable ObterTodosOsEstados() {
            SQLiteDataAdapter? da = null;

            DataTable dt = new DataTable();

            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "SELECT * FROM tb_estados";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex) {

                throw ex;
            }
        }
        #endregion
        #region Obter todos os cidades
        public static DataTable ObterTodosAsCidades() {
            SQLiteDataAdapter? da = null;

            DataTable dt = new DataTable();

            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "SELECT * FROM tb_cidades";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex) {

                throw ex;
            }
        }
        #endregion

        #region AdicionarPaises
        public static void AdicionarPaises(Paises paises) {
            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "INSERT INTO tb_paises(ID, T_PAIS, ISO2) values (@Id, @Pais, @Iso2)";
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
        #endregion

        #region AdicionarPaisesPT
        public static void AdicionarPaisesPT(string pais) {
            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "INSERT INTO tb_paisesPT(NAME) values (@Pais)";
                    cmd.Parameters.AddWithValue("@Pais", pais);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }
        #endregion

        #region Adicionar Estados
        public static void AdicionarEstados(Estado estados) {
            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "INSERT INTO tb_estado(I_ID, T_NOME, I_ID_PAIS, T_CODIGO_PAIS, I_ISO2) values (@Id, @Nome, @Id_Pais, @Codigo_pais, @Iso2)";
                    cmd.Parameters.AddWithValue("@Id", estados.ID);
                    cmd.Parameters.AddWithValue("@Nome", estados.Name);
                    cmd.Parameters.AddWithValue("@Id_Pais", estados.Country_Id);
                    cmd.Parameters.AddWithValue("@Codigo_pais", estados.Country_Code);
                    cmd.Parameters.AddWithValue("@Iso2", estados.ISO2);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }
        #endregion
        public static void AdicionarCidades(Cidades cidades) {
            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "INSERT INTO tb_cidades(ID, NAME, ID_PAIS) values (@Id, @Nome, @Id_Pais)";
                    cmd.Parameters.AddWithValue("@Id", cidades.ID);
                    cmd.Parameters.AddWithValue("@Nome", cidades.Name);
                    cmd.Parameters.AddWithValue("@Id_Pais", cidades.ID_Pais);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

    }
}
