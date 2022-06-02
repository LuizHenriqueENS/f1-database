using F1.Equipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1.Temporadas.Interface {
    internal interface ITemporada {
        public DateTime Ano { get; set; }
        public int NumeroDeCorridas { get; set; }
        public List<Equipe> Equipes { get; set; }
        public List<Piloto> Pilotos { get; set; }

    }
}
