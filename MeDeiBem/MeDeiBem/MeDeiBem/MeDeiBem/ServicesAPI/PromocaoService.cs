using MeDeiBem.DB;
using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class PromocaoService
    {
        private static readonly string BaseUrl = Constantes.URL;        

        public async static Task<List<Promocao>> GetListaPromocoes(string busca = null)
        {
            var url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string parametrosBuscaPromocoes = "{" + '"' + "range_ini" + '"' + ":" + '"' + "0" + '"' + "," +
                                                    '"' + "range_fim" + '"' + ":" + '"' + "100" + '"' + "," +
                                                    '"' + "busca" + '"' + ":" + '"' + busca + '"' + "}";

            string appKey = DataBase.GetAppKey();

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "lprm"),
                new KeyValuePair<string, string>("k", appKey),
                new KeyValuePair<string, string>("d", parametrosBuscaPromocoes),
            });

            try
            {
                HttpResponseMessage response = await request.PostAsync(url, parametros);

                if (response.IsSuccessStatusCode)
                {
                    string conteudo = await response.Content.ReadAsStringAsync();

                    if (conteudo.Length > 0)
                    {
                        List<Promocao> listaPromocoes = JsonConvert.DeserializeObject<List<Promocao>>(conteudo);
                        return listaPromocoes;
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

        public static Promocao GetPromocao(string busca)
        {
            var url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string parametrosBuscaPromocoes = "{" + '"' + "range_ini" + '"' + ":" + '"' + "0" + '"' + "," +
                                                    '"' + "range_fim" + '"' + ":" + '"' + "100" + '"' + "," +
                                                    '"' + "busca" + '"' + ":" + '"' + busca + '"' + "}";

            string appKey = DataBase.GetAppKey();

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "lprm"),
                new KeyValuePair<string, string>("k", appKey),
                new KeyValuePair<string, string>("d", parametrosBuscaPromocoes),
            });

            try
            {
                HttpResponseMessage response = request.PostAsync(url, parametros).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var conteudo = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return JsonConvert.DeserializeObject<Promocao>(conteudo);
                }
                return null;
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Put's sem acesso a Internet! X(", "Voce não esta conectado a internet!", "Ok");
                return null;
            }
        }
    }
}
