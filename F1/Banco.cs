using System;
using System.Data;
using System.Data.SQLite;

namespace F1 {
    internal class Banco {

        private static SQLiteConnection conexao;

        private static string caminho = Environment.CurrentDirectory;
        private static string nomeBanco = "banco_pilotos.db";
        private static string caminhoBanco = caminho + @"\banco\";


        private static SQLiteConnection ConexaoBanco() {
            conexao = new SQLiteConnection(@"Data Source =" + caminhoBanco + nomeBanco);
            conexao.Open();
            return conexao;
        }

        public static DataTable ObterTodosPilotos() {
            SQLiteDataAdapter? da = null;
            DataTable dt = new DataTable();
            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "SELECT * FROM tb_pilotos";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public static void Caminho() {
            Console.WriteLine(caminhoBanco + nomeBanco);
        }

        public static void AdicionarPiloto(Piloto piloto) {
            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "INSERT INTO tb_pilotos(NOME, NOME_PROFISSIONAL, NASCIMENTO, NACIONALIDADE, CIDADE_NAS, FALECIMENTO, PAISDELICENCA, PAIS_FAL, CIDADE_FAL, ESTAVIVO, CHAVEIDENTIFICACAO)" +
                        " values (@Nome, @Nome_Profissional, @Nascimento, @Nacionalidade, @Cidade_Nas, @Falecimento, @Pais_de_Licenca, @Pais_Fal, @Cidade_Fal, @EstaVivo, @Chave)";
                    cmd.Parameters.AddWithValue("@Nome", piloto.Nome);
                    cmd.Parameters.AddWithValue("@Nome_Profissional", piloto.NomeProfissional);
                    cmd.Parameters.AddWithValue("@Nascimento", piloto.DataDoNascimento);
                    cmd.Parameters.AddWithValue("@Nacionalidade", piloto.Nacionalidade);
                    cmd.Parameters.AddWithValue("@Cidade_Nas", piloto.CidadeNascimento);
                    cmd.Parameters.AddWithValue("@Falecimento", piloto.DataDoFalecimento);
                    cmd.Parameters.AddWithValue("@Pais_Fal", piloto.PaisFalecimento);
                    cmd.Parameters.AddWithValue("@Cidade_Fal", piloto.CidadeFalecimento);
                    cmd.Parameters.AddWithValue("@EstaVivo", piloto.Falecido);
                    cmd.Parameters.AddWithValue("@Chave", piloto.ChaveIdentificacao);
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

    }
}
