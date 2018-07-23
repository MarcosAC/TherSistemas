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
                                var usuario = new Usuario
                                {
                                    senha = login.senha,
                                    sinc_stat = dadosUsuario.sinc_stat,
                                    sinc_msg = dadosUsuario.sinc_msg,
                                    app_key = dadosUsuario.app_key,
                                    email = dadosUsuario.email,
                                    nome = dadosUsuario.nome,
                                    sobrenome = dadosUsuario.sobrenome,
                                    radar_uf = dadosUsuario.radar_uf,
                                    estado = dadosUsuario.estado,
                                    radar_cid = dadosUsuario.radar_cid,
                                    cidade = dadosUsuario.cidade,
                                    dth_last_sincr = dadosUsuario.dth_last_sincr
                                };

                                DataBase.AddUsuario(usuario);

                                if (dadosUsuario.clf_titulo != string.Empty)
                                {
                                    var classificado = new Classificado
                                    {
                                        titulo = dadosUsuario.clf_titulo,
                                        texto = dadosUsuario.clf_texto,
                                        contatoHorario1 = dadosUsuario.clf_contato_h1.Substring(0, 5).Replace("-", ":") + dadosUsuario.clf_contato_h1.Substring(6, 5).Replace("-", ":"),
                                        contatoHorario2 = dadosUsuario.clf_contato_h2.Substring(0, 5).Replace("-", ":") + dadosUsuario.clf_contato_h2.Substring(6, 5).Replace("-", ":"),
                                        contato_tel = dadosUsuario.clf_contato_tel,
                                        contato_email = dadosUsuario.clf_contato_email,
                                        data_ini = dadosUsuario.clf_data_ini,
                                        data_fim = dadosUsuario.clf_data_fim,
                                        dth_last_sincr = dadosUsuario.dth_last_sincr,
                                        sinc_stat = dadosUsuario.sinc_stat,
                                        sinc_msg = dadosUsuario.sinc_msg,
                                        idCategoria = dadosUsuario.clf_idcateg,
                                        idSubcategoria = dadosUsuario.clf_idsubcateg
                                    };

                                    if (classificado != null)
                                    {
                                        DataBase.AddClassificado(classificado);
                                    }
                                }

                                return true;
                            }
                            catch (Exception ex)
                            {
                                await App.Current.MainPage.DisplayAlert("Put's, algo deu errado! :(", ex.Message, "Ok");
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

        public static void GerarNovaSenha(string email)
        {
            var url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string parametrosLogin = "{" + '"' + "email" + '"' + ":" + '"' + email + '"' + "}";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "gns"),
                new KeyValuePair<string, string>("d", parametrosLogin)
            });

            try
            {
                HttpResponseMessage response = request.PostAsync(url, parametros).GetAwaiter().GetResult(); ;

                var conteudoResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult(); ;

                var resultado = JsonConvert.DeserializeObject<Login>(conteudoResponse);

                if (response.IsSuccessStatusCode)
                {
                    switch (resultado.sinc_stat)
                    {
                        case 0:
                            App.Current.MainPage.DisplayAlert("Put's, algo deu errado! :(", resultado.sinc_msg, "Ok");
                            break;
                        case 1:
                            App.Current.MainPage.DisplayAlert("Gerar Nova Senha! :)", resultado.sinc_msg, "Ok");
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