using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MeDeiBem.ServicesAPI
{
    public class MostraPaginaBaixaDesconto
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

        public static bool MostraPagina(string keyUsuario)
        {
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string key = keyUsuario;

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "cbprm"),
                new KeyValuePair<string, string>("k", key)
            });

            try
            {
                HttpResponseMessage response = request.PostAsync(url, parametros).GetAwaiter().GetResult();

                var conteudoResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var dadosResponse = JsonConvert.DeserializeObject<BaixaDesconto>(conteudoResponse);

                if (response.IsSuccessStatusCode)
                {
                    switch (dadosResponse.mostra_baixa_promo)
                    {
                        case 0:
                            return false;
                        case 1:
                            return true;                            
                    }
                }                
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Put's sem acesso a Internet! X(", "Voce não esta conectado a internet!", "Ok");
            }
           return false;
        }
    }
}
