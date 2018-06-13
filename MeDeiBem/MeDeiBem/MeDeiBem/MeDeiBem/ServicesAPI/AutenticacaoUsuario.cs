using MeDeiBem.DB;
using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class AutenticacaoUsuario
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

        public async static Task<bool> AutenticarUsuario(Login login)
        {            
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string parametrosLogin = "{" + '"' + "email" + '"' + ":" + '"' + login.email + '"' + "," + '"' + "senha" + '"' + ":" + '"' + login.senha + '"' + "}";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "vl"),
                new KeyValuePair<string, string>("d", parametrosLogin)
            });

            try
            {
                HttpResponseMessage response = await request.PostAsync(url, parametros);

                var conteudoResponse = await response.Content.ReadAsStringAsync();

                var dadosUsuario = JsonConvert.DeserializeObject<Usuario>(conteudoResponse);

                if (response.IsSuccessStatusCode)
                {
                    switch (dadosUsuario.sinc_stat)
                    {
                        case 0:
                            await App.Current.MainPage.DisplayAlert("Put's, algo deu errado! :(", dadosUsuario.sinc_msg, "Ok");
                            break;
                        case 1:
                            try
                            {
                                DataBase dataBase = new DataBase();
                                dataBase.AddUsuario(dadosUsuario);
                                return true;
                            }
                            catch (Exception ex)
                            {
                                await App.Current.MainPage.DisplayAlert("Put's, algo deu errado! :(", ex.Message, "Merda X(");
                            }
                            break;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Put's sem acesso a Internet! X(", "Voce não esta conectado a internet!", "Ok");
                return false;
            }
        }
    }
}