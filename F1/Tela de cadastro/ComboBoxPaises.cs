using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;

namespace F1 {
    internal class ComboBoxPaises {

        public static List<Paises> MostrarPaises() {
            List<Paises> paises = new();
            DataTable dt = BancoPaises.ObterTodosOsPaisesPT();
            foreach (DataRow dr in dt.Rows) {
                paises.Add(new Paises(dr["NAME"].ToString()));
            }
            return paises;
        }

        public static async void AdicionarAoComboBox() {

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-CSCAPI-KEY", "MHBlNDdEMUM3aGJ6UWZIdTdoQU0xaGQweGM4WW13R1NsVzB5WW9uRQ==");
            string? result = await client.GetStringAsync("https://api.countrystatecity.in/v1/states");
            var lista = JsonConvert.DeserializeObject<List<Paises>>(result);

        }

    }
}
