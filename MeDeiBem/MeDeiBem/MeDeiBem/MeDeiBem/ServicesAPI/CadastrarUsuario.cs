using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class CadastrarUsuario
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;        

        public async static Task AddUsuario(Usuario usuario)
        {            
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string dadosUsuario = "{" + '"' + "nome" + '"' + ":" + '"' + usuario.nome + '"' + "," +
                                        '"' + "sobrenome" + '"' + ":" + '"' + usuario.sobrenome + '"' + "," +
                                        '"' + "email" + '"' + ":" + '"' + usuario.email + '"' + "," +
                                        '"' + "radar_uf" + '"' + ":" + '"' + usuario.radar_uf + '"' + "," +
                                        '"' + "radar_cid" + '"' + ":" + '"' + usuario.radar_cid + '"' + "," +
                                        '"' + "senha" + '"' + ":" + '"' + usuario.senha + '"' + "}";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "ru"),
                new KeyValuePair<string, string>("d", dadosUsuario)
            });
                        
            HttpResponseMessage response = await request.PostAsync(url, parametros);

            var conteudoResponse = await response.Content.ReadAsStringAsync();

            var dadosResponse = JsonConvert.DeserializeObject<Usuario>(conteudoResponse);

            if (response.IsSuccessStatusCode)
            {
                switch (dadosResponse.sinc_stat)
                {
                    case 0:
                        await App.Current.MainPage.DisplayAlert("Ohh, esquecido! :P", dadosResponse.sinc_msg, "Ok");
                        break;
                    case 1:
                        await App.Current.MainPage.DisplayAlert("Aeee, mano. Chega aí! :D", dadosResponse.sinc_msg, "Ok");                        
                        break;
                }             
            }         
        }
    }
}
