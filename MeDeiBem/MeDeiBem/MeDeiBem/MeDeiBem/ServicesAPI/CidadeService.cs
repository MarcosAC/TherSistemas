using MeDeiBem.ServicesAPI.ModelAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class CidadeService
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

       public async static Task<List<RadarCidade>> GetCidade()
       {
            var url = BaseUrl + "a=lc&uf=mg";

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
                    List<RadarCidade> listaCidades = JsonConvert.DeserializeObject<List<RadarCidade>>(conteudo);
                    return listaCidades;
                }
            }
            return null;
       }
    }
}
