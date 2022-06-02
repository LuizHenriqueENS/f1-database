using F1.Equipes;
using F1.Temporadas.Interface;
using System;
using System.Collections.Generic;
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
        public string? ChaveIdentificacao { get; set; }
        public List<Equipe?> Equipes { get; set; }
        public List<ITemporada?> Temporadas { get; set; }
        public List<ICorridas?> Corridas { get; set; }

        public Piloto() { }

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
            string[] nomes = NomeProfissional.Split(" ");
            string abc = NomeProfissional[..3];
            string xyz = nomes[nomes.Length - 1].Length switch {
                2 => nomes[^1] + "X",
                1 => nomes[^1] + "XY",
                _ => nomes[^1][..3],
            };
            string chave = $"{DataDoNascimento?.ToString("yyyyMMdd")}{xyz.ToUpper()}{abc.ToUpper()}0";
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
