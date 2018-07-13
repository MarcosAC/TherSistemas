using MeDeiBem.DB;
using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class ClassificadoService
    {
        private static readonly string BaseUrl = Constantes.URL;

        public async static Task<List<Classificado>> GetListaClassificados(string busca = null)
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
                new KeyValuePair<string, string>("a", "lclf"),
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
                        List<Classificado> listaClassificados = JsonConvert.DeserializeObject<List<Classificado>>(conteudo);
                        return listaClassificados;
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

        public async static Task AddClassificado(string keyUsuario, Classificado classificado)
        {
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string key = keyUsuario;

            string dadosClassificado = "{" + '"' + "categ" + '"' + ":" + '"' + classificado.idCategoria + '"' + "," +
                                        '"' + "subcateg" + '"' + ":" + '"' + classificado.idSubcategoria + '"' + "," +
                                        '"' + "titulo" + '"' + ":" + '"' + classificado.titulo + '"' + "," +
                                        '"' + "texto" + '"' + ":" + '"' + classificado.texto + '"' + "," +
                                        '"' + "contato_h1" + '"' + ":" + '"' + classificado.contato_h1 + '"' + "," +
                                        '"' + "contato_h2" + '"' + ":" + '"' + classificado.contato_h2 + '"' + "," +
                                        '"' + "contato_tel" + '"' + ":" + '"' + classificado.contato_tel + '"' + "," +
                                        '"' + "contato_email" + '"' + ":" + '"' + classificado.contato_email + '"' + "}";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "rc"),
                new KeyValuePair<string, string>("k", key),
                new KeyValuePair<string, string>("d", dadosClassificado),
            });

            try
            {
                HttpResponseMessage response = await request.PostAsync(url, parametros);

                var conteudoResponse = await response.Content.ReadAsStringAsync();

                var dadosResponse = JsonConvert.DeserializeObject<Classificado>(conteudoResponse);

                if (response.IsSuccessStatusCode)
                {
                    switch (dadosResponse.sinc_stat)
                    {
                        case 0:
                            await App.Current.MainPage.DisplayAlert("Put's, faltou algo! :O", dadosResponse.sinc_msg, "Ok");
                            break;
                        case 1:
                            await App.Current.MainPage.DisplayAlert("Sucesso! :D", dadosResponse.sinc_msg, "Ok");
                            try
                            {
                                DataBase.AddClassificado(classificado);
                            }
                            catch (Exception erro)
                            {
                                await App.Current.MainPage.DisplayAlert("Erro base local", "Erro ao cadastrar dados classificado na base local. " + erro, "Ok");
                            }
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
