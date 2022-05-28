using System;

namespace F1 {
    internal class Piloto {
        public string Nome { get; set; }
        public string NomeProfissional { get; set; }
        public DateTime DataDoNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public string CidadeNascimento { get; set; }
        public DateTime DataDoFalecimento { get; set; }
        public string CidadeFalecimento { get; set; }
        public bool Falecido { get; set; }
        public string PaisFalecimento { get; set; }
        public string PaisDeLicenca { get; set; }

        public string ChaveIdentificacao { get; set; }

        public Piloto() {
        }

        public Piloto(string? nome, string? nomeProfissional, DateTime dataDoNascimento,
            string? nacionalidade, string? cidadeNascimento, DateTime dataDoFalecimento,
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

        public Piloto(string? nome, string? nomeProfissional, DateTime dataDoNascimento, string? nacionalidade, string? cidadeNascimento, bool falecido, string? paisDeLicenca) {
            Nome = nome;
            NomeProfissional = nomeProfissional;
            DataDoNascimento = dataDoNascimento;
            Nacionalidade = nacionalidade;
            CidadeNascimento = cidadeNascimento;
            Falecido = falecido;
            PaisDeLicenca = paisDeLicenca;
        }



        public string Identificacao() {
            string chave = "";

            string[] nomes = Nome.Split(" ");
            string abc = Nome.Substring(0, 3);
            string xyz = nomes[nomes.Length - 1].Substring(0, 3);
            if (DataDoNascimento.Month < 9 && DataDoNascimento.Day < 9) {
                chave = $"{DataDoNascimento.Year}0{DataDoNascimento.Month}0{DataDoNascimento.Day}{xyz.ToUpper()}{abc.ToUpper()}";
            }
            else if (DataDoNascimento.Month > 9 && DataDoNascimento.Day < 9) {
                chave = $"{DataDoNascimento.Year}{DataDoNascimento.Month}0{DataDoNascimento.Day}{xyz.ToUpper()}{abc.ToUpper()}";
            }
            else if (DataDoNascimento.Month < 9 && DataDoNascimento.Day > 9) {
                chave = $"{DataDoNascimento.Year}0{DataDoNascimento.Month}{DataDoNascimento.Day}{xyz.ToUpper()}{abc.ToUpper()}";
            }
            else {
                chave = $"{DataDoNascimento.Year}{DataDoNascimento.Month}{DataDoNascimento.Day}{xyz.ToUpper()}{abc.ToUpper()}";
            }
            ChaveIdentificacao = chave;
            return chave;
        }
        public override string ToString() {
            return $"{Identificacao()} + {Nome} -- {Nacionalidade} -- {DataDoNascimento} -- {DataDoFalecimento}, {PaisDeLicenca}";
        }
    }
}
