using MeDeiBem.DB;
using MeDeiBem.DB.SerivcesDB;
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

        public static async Task<Usuario> AutenticarUsuario(Login login)
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

            HttpResponseMessage response = await request.PostAsync(url, parametros);

            var conteudoResponse = await response.Content.ReadAsStringAsync();

            var dadosUsuario = JsonConvert.DeserializeObject<Usuario>(conteudoResponse);

            if (response.IsSuccessStatusCode)
            {
                switch (dadosUsuario.sinc_stat)
                {
                    case 0:
                        await App.Current.MainPage.DisplayAlert("Put's, algo de errado não deu certo! :(", dadosUsuario.sinc_msg, "Ok");
                        break;
                    case 1:
                        try
                        {
                            DataBase dataBase = new DataBase();
                            dataBase.AddUsuario(dadosUsuario);
                            await App.Current.MainPage.DisplayAlert("Sucessoooo!!! :D", "Put's, nem acredito deu certo!!!", "Ok");                            
                        }
                        catch (Exception ex)
                        {
                            await App.Current.MainPage.DisplayAlert("Put's, algo de errado não deu certo! :(", ex.Message, "Merda X(");
                        }
                        break;
                }                             
            }
            return null;
        }
    }
}

/*var json = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                var dadosUsuario = new Usuario
                {
                    nome = json.nome,
                    sobrenome = json.sobrenome,
                    email = json.email,
                    radarUf = json.radarUf,
                    radarCidade = json.radarCidade,
                    senha = json.senha
                };
                return dadosUsuario;
            }
            return null;*/
