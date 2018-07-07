using MeDeiBem.DB;
using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class PodcastService
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

        public async static Task<List<Podcast>> GetListaPodcasts(string busca = null)
        {
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string key = DataBase.GetAppKey();

            string parametrosBuscaPodcast = "{" + '"' + "range_ini" + '"' + ":" + '"' + "0" + '"' + "," +
                                                    '"' + "range_fim" + '"' + ":" + '"' + "100" + '"' + "," +
                                                    '"' + "busca" + '"' + ":" + '"' + busca + '"' + "}";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "lpc"),
                new KeyValuePair<string, string>("k", key),
                new KeyValuePair<string, string>("d", parametrosBuscaPodcast),
            });

            try
            {
                HttpResponseMessage response = await request.PostAsync(url, parametros);

                if (response.IsSuccessStatusCode)
                {
                    string conteudo = await response.Content.ReadAsStringAsync();

                    if (conteudo.Length > 0)
                    {
                        List<Podcast> listaPodCast = JsonConvert.DeserializeObject<List<Podcast>>(conteudo);
                        return listaPodCast;
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