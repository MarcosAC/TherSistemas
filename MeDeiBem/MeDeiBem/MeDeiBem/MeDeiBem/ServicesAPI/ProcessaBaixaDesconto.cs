using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MeDeiBem.ServicesAPI
{
    public class ProcessaBaixaDesconto
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

        public static void BaixaDescontoPromocao(string keyUsuario, BaixaDesconto baixaDesconto)
        {
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string parametrosBaixaDesconto = "{" + '"' + "cod_desc" + '"' + ":" + '"' +  baixaDesconto.cod_desc  + '"' + "," +
                                                    '"' + "senha_vend" + '"' + ":" + '"' + baixaDesconto.senha_vend + '"' + "," +
                                                    '"' + "qtde" + '"' + ":" + '"' + baixaDesconto.qtde + '"' + "}";

            string key = keyUsuario;

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "pbprm"),
                new KeyValuePair<string, string>("k", key),
                new KeyValuePair<string, string>("d", parametrosBaixaDesconto)
            });

            try
            {
                HttpResponseMessage response = request.PostAsync(url, parametros).GetAwaiter().GetResult();

                var conteudoResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var dadosResponse = JsonConvert.DeserializeObject<BaixaDesconto>(conteudoResponse);

                if (response.IsSuccessStatusCode)
                {
                    switch (dadosResponse.sinc_stat)
                    {
                        case 0:
                            App.Current.MainPage.DisplayAlert("Put's, faltou algo! :O", dadosResponse.sinc_msg, "Ok");
                            break;
                        case 1:
                            App.Current.MainPage.DisplayAlert("Sucesso :D", dadosResponse.sinc_msg, "Ok");
                            break;
                    }
                }
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Put's sem acesso a Internet! X(", "Voce não esta conectado a internet!", "Ok");
            }
        }
    }
}
