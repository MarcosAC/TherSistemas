using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class SituacaoClassificadoService
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

        public async static Task<SituacaoClassificado> VerificaSituacaoClassificado(string keyUsuario)
        {
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string key = keyUsuario;

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "cs"),
                new KeyValuePair<string, string>("k", key)                
            });

            try
            {
                HttpResponseMessage response = await request.PostAsync(url, parametros);

                var conteudoResponse = await response.Content.ReadAsStringAsync();

                var dadosResponse = JsonConvert.DeserializeObject<SituacaoClassificado>(conteudoResponse);

                if (response.IsSuccessStatusCode)
                {
                    switch (dadosResponse.sinc_stat)
                    {
                        case 0:
                            return dadosResponse;                            
                        case 1:
                            return dadosResponse;                            
                    }
                }
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Put's sem acesso a Internet! X(", "Voce não esta conectado a internet!", "Ok");
            }
            return null;
        }
    }
}