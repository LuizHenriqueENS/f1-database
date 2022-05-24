
namespace F1 {
    internal class Paises {

        public int Id { get; set; }
        public string? Name { get; set; } = default;
        public string? Iso2 { get; set; } = default;

        public Paises() {
        }

        public Paises(string? name) {
            Name = name;
        }

        public Paises(int id, string pais, string iso2) {
            Id = id;
            Name = pais;
            Iso2 = iso2;
        }


        public override string ToString() {
            return Name;
        }

    }


}
