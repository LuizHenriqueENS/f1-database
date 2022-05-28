using System;
using System.Collections.Generic;
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

        public static void AdicionarPiloto(Piloto piloto) {
            try {
                using (var cmd = ConexaoBanco().CreateCommand()) {
                    cmd.CommandText = "INSERT INTO tb_pilotos(NOME, NOME_PROFISSIONAL, NASCIMENTO, NACIONALIDADE," +
                        " CIDADE_NAS, PAISDELICENCA, ESTAVIVO, CHAVEIDENTIFICACAO, FALECIMENTO, PAIS_FAL, CIDADE_FAL)" +
                        " VALUES (@Nome, @Nome_Profissional, @Nascimento, @Nacionalidade, @Cidade_Nas, @Pais_DeLicenca, " +
                        "@EstaVivo, @Chave, @Falecimento, @Pais_Fal, @Cidade_Fal)";
                    
                    cmd.Parameters.AddWithValue("@Nome", piloto.Nome);
                    Console.WriteLine(piloto.Nome);
                    cmd.Parameters.AddWithValue("@Nome_Profissional", piloto.NomeProfissional);
                    Console.WriteLine(piloto.NomeProfissional);
                    cmd.Parameters.AddWithValue("@Nascimento", piloto.DataDoNascimento);
                    Console.WriteLine(piloto.DataDoNascimento);
                    cmd.Parameters.AddWithValue("@Nacionalidade", piloto.Nacionalidade);
                    Console.WriteLine(piloto.Nacionalidade);
                    cmd.Parameters.AddWithValue("@Cidade_Nas", piloto.CidadeNascimento);
                    Console.WriteLine(piloto.CidadeNascimento);
                    cmd.Parameters.AddWithValue("@Pais_DeLicenca", piloto.PaisDeLicenca);
                    Console.WriteLine(piloto.PaisDeLicenca);
                    cmd.Parameters.AddWithValue("@EstaVivo", piloto.Falecido);
                    Console.WriteLine(piloto.Falecido);
                    
                    cmd.Parameters.AddWithValue("@Chave", piloto.Identificacao());
                    Console.WriteLine(piloto.ChaveIdentificacao);

                    if (piloto.DataDoFalecimento.Ticks > 0) {
                        cmd.Parameters.AddWithValue("@Falecimento", piloto.DataDoFalecimento);
                        cmd.Parameters.AddWithValue("@Pais_Fal", piloto.PaisFalecimento);
                        cmd.Parameters.AddWithValue("@Cidade_Fal", piloto.CidadeFalecimento);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static bool listaDePilotos(string nome) {
            bool existeNoBanco = false;
            var x = ObterTodosPilotos();
            foreach (DataRow dataRow in x.Rows) {
                if (dataRow[0].ToString().ToLower() == nome.ToLower()) {
                    return true;
                }
            }
            return existeNoBanco;
        }
    }
}
