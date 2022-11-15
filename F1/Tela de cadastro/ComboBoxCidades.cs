using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Windows.Controls;
namespace F1 {
    internal class ComboBoxCidades {

        public static List<Cidades> MonstrarCidades(int idPais) {
            List<Cidades> cidades = new();
            DataTable dt = BancoPaises.ObterTodosAsCidades();

            foreach (DataRow dr in dt.Rows) {
                cidades.Add(new Cidades((string?)dr["NAME"], int.Parse(dr["ID_PAIS"].ToString())));
            }
            List<Cidades> filtrado = cidades.FindAll(a => a.ID_Pais == idPais);

            return cidades;


        }


        public static int Filtrar(ComboBox cb) {
            int sel = cb.SelectedIndex;
            return sel + 1;
        }

        //public static async void AdicionarAoComboBox() {

        //    using var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("X-CSCAPI-KEY", "MHBlNDdEMUM3aGJ6UWZIdTdoQU0xaGQweGM4WW13R1NsVzB5WW9uRQ==");
        //    string? result = await client.GetStringAsync("https://api.countrystatecity.in/v1/states");
        //    var lista = JsonConvert.DeserializeObject<List<Paises>>(result);

        //}
    }
}
