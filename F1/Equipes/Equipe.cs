namespace F1.Equipes {
    internal class Equipe {
        public string? Nome { get; set; }
        public string? PaisDaLicenca { get; set; }
       // public List<Motor> Motores { get; set; }
        // public List<Construtor> Constutores { get; set; }   

        public Equipe() {
        }

        public Equipe(string? nome, string? paisDaLicenca) {
            Nome = nome;
            PaisDaLicenca = paisDaLicenca;
        }
    }
}
