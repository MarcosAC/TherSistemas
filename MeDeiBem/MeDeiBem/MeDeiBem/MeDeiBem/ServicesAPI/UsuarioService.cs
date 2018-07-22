using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class UsuarioService
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

            try
            {
                HttpResponseMessage response = await request.PostAsync(url, parametros);

                var conteudoResponse = await response.Content.ReadAsStringAsync();

                var dadosResponse = JsonConvert.DeserializeObject<Usuario>(conteudoResponse);

                if (response.IsSuccessStatusCode)
                {
                    switch (dadosResponse.sinc_stat)
                    {
                        case 0:
                            await App.Current.MainPage.DisplayAlert("Put's, faltou algo! :O", dadosResponse.sinc_msg, "Ok");
                            break;
                        case 1:
                            await App.Current.MainPage.DisplayAlert("Seja Bemvindo! :D", dadosResponse.sinc_msg, "Ok");
                            break;
                    }
                }
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Put's sem acesso a Internet! X(", "Voce não esta conectado a internet!", "Ok");                
            }       
        }

        public async static Task EditUsuario(string keyUsuario, Usuario usuario)
        {
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string key = keyUsuario;

            string dadosUsuario = "{" + '"' + "nome" + '"' + ":" + '"' + usuario.nome + '"' + "," +
                                        '"' + "sobrenome" + '"' + ":" + '"' + usuario.sobrenome + '"' + "," +
                                        '"' + "email" + '"' + ":" + '"' + usuario.email + '"' + "," +
                                        '"' + "radar_uf" + '"' + ":" + '"' + usuario.radar_uf + '"' + "," +
                                        '"' + "radar_cid" + '"' + ":" + '"' + usuario.radar_cid + '"' + "," +
                                        '"' + "senha" + '"' + ":" + '"' + usuario.senha + '"' + "}";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "au"),
                new KeyValuePair<string, string>("k", key),
                new KeyValuePair<string, string>("d", dadosUsuario)
            });

            try
            {
                HttpResponseMessage response = await request.PostAsync(url, parametros);

                var conteudoResponse = await response.Content.ReadAsStringAsync();

                var dadosResponse = JsonConvert.DeserializeObject<Usuario>(conteudoResponse);

                if (response.IsSuccessStatusCode)
                {
                    switch (dadosResponse.sinc_stat)
                    {
                        case 0:
                            await App.Current.MainPage.DisplayAlert("Put's, faltou algo! :O", dadosResponse.sinc_msg, "Ok");
                            break;
                        case 1:
                            await App.Current.MainPage.DisplayAlert("Editar Dados :D", dadosResponse.sinc_msg, "Ok");
                            break;
                    }
                }
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Put's sem acesso a Internet! X(", "Voce não esta conectado a internet!", "Ok");
            }
        }
    }
}