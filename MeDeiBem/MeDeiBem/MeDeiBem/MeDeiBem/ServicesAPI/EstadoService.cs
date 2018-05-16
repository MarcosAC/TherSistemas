using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class EstadoService
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

        public async static Task<List<RadarEstado>> GetEstado()
        {
            var url = BaseUrl + "a=le";

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            HttpResponseMessage response = await request.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();

                if (conteudo.Length > 0)
                {
                    List<RadarEstado> listaEstados = JsonConvert.DeserializeObject<List<RadarEstado>>(conteudo);
                    return listaEstados;
                }
            }
            return null;
        }
    }
}
