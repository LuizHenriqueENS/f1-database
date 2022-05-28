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

        public static void AdicionarPiloto(Piloto p) {
            try {
                using var cmd = ConexaoBanco().CreateCommand();
                if (p.Falecido) {
                cmd.CommandText = "INSERT INTO tb_pilotos(NOME, NOME_PROFISSIONAL, NASCIMENTO, NACIONALIDADE, CIDADE_NAS, FALECIMENTO, PAISDELICENCA, PAIS_FAL, CIDADE_FAL, ESTAVIVO, CHAVEIDENTIFICACAO) VALUES (@Nome, @Nome_profissional, @Nascimento, @Nacionalidade, @Cidade_nascimento, @Falecimento, @Pais_licenca, @Pais_falecimento, @Cidade_falecimento, @Esta_vivo, @Chave)";
                cmd.Parameters.AddWithValue("@Nome", p.Nome);
                cmd.Parameters.AddWithValue("@Nome_profissional", p.NomeProfissional);
                cmd.Parameters.AddWithValue("@Nascimento", p.DataDoNascimento);
                cmd.Parameters.AddWithValue("@Nacionalidade", p.Nacionalidade);
                cmd.Parameters.AddWithValue("@Cidade_nascimento", p.CidadeNascimento);
                cmd.Parameters.AddWithValue("@Falecimento", p.DataDoFalecimento);
                cmd.Parameters.AddWithValue("@Pais_falecimento", p.PaisFalecimento);
                cmd.Parameters.AddWithValue("@Cidade_falecimento", p.CidadeFalecimento);
                cmd.Parameters.AddWithValue("@Pais_licenca", p.PaisDeLicenca);
                cmd.Parameters.AddWithValue("@Esta_vivo", p.Falecido);
                cmd.Parameters.AddWithValue("@Chave", p.Identificacao());
                
                cmd.ExecuteNonQuery();
                }
                else {
                    cmd.CommandText = "INSERT INTO tb_pilotos(NOME, NOME_PROFISSIONAL," +
                        " NASCIMENTO, NACIONALIDADE, CIDADE_NAS, PAISDELICENCA, ESTAVIVO," +
                        " CHAVEIDENTIFICACAO) VALUES (@Nome, @Nome_profissional, @Nascimento," +
                        " @Nacionalidade, @Cidade_nascimento, @Pais_licenca, @Esta_vivo, @Chave)";

                    cmd.Parameters.AddWithValue("@Nome", p.Nome);
                    cmd.Parameters.AddWithValue("@Nome_profissional", p.NomeProfissional);
                    cmd.Parameters.AddWithValue("@Nascimento", p.DataDoNascimento);
                    cmd.Parameters.AddWithValue("@Nacionalidade", p.Nacionalidade);
                    cmd.Parameters.AddWithValue("@Cidade_nascimento", p.CidadeNascimento);
                    cmd.Parameters.AddWithValue("@Pais_licenca", p.PaisDeLicenca);
                    cmd.Parameters.AddWithValue("@Esta_vivo", p.Falecido);
                    p.Identificacao();
                    cmd.Parameters.AddWithValue("@Chave", p.ChaveIdentificacao);
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
