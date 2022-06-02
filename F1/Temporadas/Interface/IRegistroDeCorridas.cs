using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1.Temporadas.Interface {
    internal interface IRegistroDeCorridas {
        public DateTime Data { get; set; }
        public string Circuito { get; set; }
        public string Denomincao { get; set; }


        public void Pontuacao();
    }
}
