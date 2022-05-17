using System;
using System.Globalization;

namespace F1 {
    internal class Piloto {
        public string? Nome { get; set; }
        public string? LocalDoNascimento { get; set; }
        public DateTime DataDoNascimento { get; set; }
        public DateTime DataDoFalecimento { get; set; }
        public string? PaisDeLicenca { get; set; }

        public string ChaveIdentificacao { get; set; }


        public Piloto(string? nome, string? localDoNascimento, DateTime dataDoNascimento, string? paisDeLicenca, string chaveIdentificacao) {
            Nome = nome;
            LocalDoNascimento = localDoNascimento;
            DataDoNascimento = dataDoNascimento.Date;
            PaisDeLicenca = paisDeLicenca;
            ChaveIdentificacao = chaveIdentificacao;
        }

        public Piloto(string? nome, string? localDoNascimento, DateTime dataDoNascimento, DateTime dataDoFalecimento, string? paisDeLicenca, string chaveIdentificacao) {
            Nome = nome;
            LocalDoNascimento = localDoNascimento;
            DataDoNascimento = dataDoNascimento;
            DataDoFalecimento = dataDoFalecimento;
            PaisDeLicenca = paisDeLicenca;
            ChaveIdentificacao = chaveIdentificacao;
        }

        public Piloto() {
        }

        public string Identificacao() {
            string chave = "";
            if (Nome != null) {
                int len = Nome.Length - 3;
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

            return "";


        }
        public override string ToString() {
            return $"{Identificacao()} + {Nome} -- {LocalDoNascimento} -- {DataDoNascimento} -- {DataDoFalecimento}, {PaisDeLicenca}";
        }
    }
}
