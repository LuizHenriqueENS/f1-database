
namespace F1 {
    internal class Paises {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso2 { get; set; }

        public Paises() {
        }

        public Paises(int id, string pais, string iso2) {
            Id = id;
            Name = pais;
            Iso2 = iso2;
        }

        public override string? ToString() {
            return $"ID: {Id}, PAIS: {Name}, ISO2: {Iso2}";
        }
    }


}
