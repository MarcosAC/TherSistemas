using MeDeiBem.Model;
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

            try
            {
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
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Put's sem acesso a Internet! X(", "Voce não esta conectado a internet!", "Ok");
                return null;
            }
        }
    }
}
