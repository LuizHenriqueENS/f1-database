using System;
using System.Data;

namespace F1 {
    internal class Piloto {
        public string? Nome { get; set; }
        public string? NomeProfissional { get; set; }
        public DateTime? DataDoNascimento { get; set; }
        public string? Nacionalidade { get; set; }
        public string? CidadeNascimento { get; set; }
        public DateTime? DataDoFalecimento { get; set; }
        public string? CidadeFalecimento { get; set; }
        public bool Falecido { get; set; }
        public string? PaisFalecimento { get; set; }
        public string? PaisDeLicenca { get; set; }

        public string ChaveIdentificacao { get; set; }

        public Piloto() {
        }

        public Piloto(string? nome) {
            Nome = nome;
        }

        public Piloto(string? nome, string? nomeProfissional, DateTime? dataDoNascimento,
            string? nacionalidade, string? cidadeNascimento, DateTime? dataDoFalecimento,
            string? cidadeFalecimento, bool falecido, string? paisFalecimento, string? paisDeLicenca
            ) {
            Nome = nome;
            NomeProfissional = nomeProfissional;
            DataDoNascimento = dataDoNascimento;
            Nacionalidade = nacionalidade;
            CidadeNascimento = cidadeNascimento;
            DataDoFalecimento = dataDoFalecimento;
            CidadeFalecimento = cidadeFalecimento;
            Falecido = falecido;
            PaisFalecimento = paisFalecimento;
            PaisDeLicenca = paisDeLicenca;

        }
        public Piloto(string? nome, string? nomeProfissional, DateTime? dataDoNascimento,
           string? nacionalidade, string? cidadeNascimento, DateTime? dataDoFalecimento,
           string? cidadeFalecimento, bool falecido, string? paisFalecimento, string? paisDeLicenca, string chave
           ) {
            Nome = nome;
            NomeProfissional = nomeProfissional;
            DataDoNascimento = dataDoNascimento;
            Nacionalidade = nacionalidade;
            CidadeNascimento = cidadeNascimento;
            DataDoFalecimento = dataDoFalecimento;
            CidadeFalecimento = cidadeFalecimento;
            Falecido = falecido;
            PaisFalecimento = paisFalecimento;
            PaisDeLicenca = paisDeLicenca;
            ChaveIdentificacao = chave;
        }
        public Piloto(string? nome, string? nomeProfissional, DateTime? dataDoNascimento, string? nacionalidade, string? cidadeNascimento, bool falecido, string? paisDeLicenca) {
            Nome = nome;
            NomeProfissional = nomeProfissional;
            DataDoNascimento = dataDoNascimento;
            Nacionalidade = nacionalidade;
            CidadeNascimento = cidadeNascimento;
            Falecido = falecido;
            PaisDeLicenca = paisDeLicenca;

        }

        public Piloto(string? nome, string? nomeProfissional, DateTime? dataDoNascimento, string? nacionalidade, string? cidadeNascimento, bool falecido, string? paisDeLicenca, string chave) {
            Nome = nome;
            NomeProfissional = nomeProfissional;
            DataDoNascimento = dataDoNascimento;
            Nacionalidade = nacionalidade;
            CidadeNascimento = cidadeNascimento;
            Falecido = falecido;
            PaisDeLicenca = paisDeLicenca;
            ChaveIdentificacao = chave;
        }



        public string Identificacao() {
            string chave = "";

            string xyz = "";
            string[] nomes = Nome.Split(" ");
            string abc = Nome.Substring(0, 3);
            xyz = nomes[nomes.Length - 1].Length switch {
                2 => nomes[nomes.Length - 1] + "X",
                1 => nomes[nomes.Length - 1] + "XY",
                _ => nomes[nomes.Length - 1].Substring(0, 3),
            };
            chave = $"{DataDoNascimento?.ToString("yyyy")}{DataDoNascimento?.ToString("MM")}{DataDoNascimento?.ToString("dd")}{xyz.ToUpper()}{abc.ToUpper()}0";

            //chave = DataDoNascimento.Month switch {
            //    < 9 when DataDoNascimento.Day < 9 => $"{DataDoNascimento.Year}0{DataDoNascimento.Month}0{DataDoNascimento.Day}{xyz.ToUpper()}{abc.ToUpper()}0",
            //    > 9 when DataDoNascimento.Day < 9 => $"{DataDoNascimento.Year}{DataDoNascimento.Month}0{DataDoNascimento.Day}{xyz.ToUpper()}{abc.ToUpper()}0",
            //    < 9 when DataDoNascimento.Day > 9 => $"{DataDoNascimento.Year}0{DataDoNascimento.Month}{DataDoNascimento.Day}{xyz.ToUpper()}{abc.ToUpper()}0",
            //    _ => $"{DataDoNascimento.Year}{DataDoNascimento.Month}{DataDoNascimento.Day}{xyz.ToUpper()}{abc.ToUpper()}0",
            //};
            chave += 1;
            int i = 1;
            foreach (DataRow data in Banco.ObterTodosPilotos().Rows) {
                while (data["CHAVEIDENTIFICACAO"].ToString() == chave) {
                    i++;
                    string subChave = chave[..^2];
                    chave = subChave + "0" + i;
                }
            }
            ChaveIdentificacao = chave;
            return chave;
        }
        public override string ToString() {
            return Nome;
        }

    }
}
