using System;
using System.Data;
using System.Data.SQLite;

namespace F1 {
    internal class Banco {

        private static SQLiteConnection conexao;

        private static string caminho = Environment.CurrentDirectory;
        private static string nomeBanco = "banco_pilotos.db";
        private static string caminhoBanco = caminho+@"\banco\";
        

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
                    cmd.CommandText = "INSERT INTO tb_pilotos(T_NOMEPILOTO, T_LOCALNASCIMENTO, DT_NASCIMENTO, DT_DATAFALECIMENTO, T_PAISDELICENCA, T_CHAVEIDENTIFICACAO, B_ESTAVIVO) values (@Nome, @Local, @DtNascimento, @DtFalecimento, @Paisdelicenca, @ChaveDeIdentificacao, @Estavivo)";
                    cmd.Parameters.AddWithValue("@Nome", piloto.Nome);
                    cmd.Parameters.AddWithValue("@Local", piloto.LocalDoNascimento);
                    cmd.Parameters.AddWithValue("@DtNascimento", piloto.DataDoNascimento.ToString("dd/MM/yyyy"));
                    if (piloto.DataDoFalecimento.Ticks == 0) {
                        cmd.Parameters.AddWithValue("@DtFalecimento", null);
                        cmd.Parameters.AddWithValue("@Estavivo", true);
                    }
                    else {
                        cmd.Parameters.AddWithValue("@DtFalecimento", piloto.DataDoFalecimento.ToString("dd/MM/yyyy"));
                        cmd.Parameters.AddWithValue("@Estavivo", false);
                    }
                    cmd.Parameters.AddWithValue("@Paisdelicenca", piloto.PaisDeLicenca);
                    cmd.Parameters.AddWithValue("@ChaveDeIdentificacao", piloto.Identificacao());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

    }
}
