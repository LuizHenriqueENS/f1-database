using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1.Temporadas.Interface {
    internal interface ICorridas {
        public int? PosicaoDeLargada { get; set; }
        public int? PosicaoDeChegada { get; set; }
        public int? Voltas { get; set; }
        public int? MelhorVolta { get; set; }
        public TimeSpan? TempoMelhorVolta { get; set; }
    }
}
