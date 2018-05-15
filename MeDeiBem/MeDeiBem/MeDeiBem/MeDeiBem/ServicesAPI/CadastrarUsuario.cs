using MeDeiBem.ServicesAPI.ModelAPI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace MeDeiBem.ServicesAPI
{
    public class CadastrarUsuario
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

        public async static Task GetUsuario(Usuario usuario)
        {
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("senha", usuario.email),
                new KeyValuePair<string, string>("senha", usuario.senha)
            });
            
            HttpResponseMessage response = await request.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao cadastrar usuario");
            }
        }

        public async static Task<bool> AddUsuario(Usuario usuario)
        {            
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string data = "{" + '"' + "nome" + '"' + ":" + '"' + usuario.nome + '"' + "," +
                              '"' + "sobrenome" + '"' + ":" + '"' + usuario.sobrenome + '"' + "," +
                              '"' + "email" + '"' + ":" + '"' + usuario.email + '"' + "," +
                              '"' + "radar_uf" + '"' + ":" + '"' + usuario.radarUf + '"' + "," +
                              '"' + "radar_cid" + '"' + ":" + '"' + usuario.radarCidade + '"' + "," +
                              '"' + "senha" + '"' + ":" + '"' + usuario.senha + '"' + "}";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "ru"),
                new KeyValuePair<string, string>("d", data)
            });
                        
            HttpResponseMessage response = await request.PostAsync(url, parametros);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
