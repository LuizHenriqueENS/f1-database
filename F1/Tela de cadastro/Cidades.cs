namespace F1 {
    internal class Cidades {

        public int ID { get; set; }
        public string? Name { get; set; } = default;
        public int? ID_Pais { get; set; } = default;

        public Cidades() { }

        public Cidades(string? name, int? iD_Pais) {
            Name = name;
            ID_Pais = iD_Pais;
        }

        public Cidades(int iD, string? name, int? iD_Pais) {
            ID = iD;
            Name = name;
            ID_Pais = iD_Pais;
        }
    }
}
