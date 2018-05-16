using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MeDeiBem.Model;

namespace MeDeiBem.ServicesAPI
{
    public class AutenticacaoUsuario
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;        

        public async static Task<Usuario> AutenticarUsuario(Login login)
        {
            string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string parametrosLogin = "{" + '"' + "email" + '"' + ":" + '"' + login.email + "," + '"' + "senha" + ":" + '"' + login.senha + '"' + "}";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "vl"),
                new KeyValuePair<string, string>("d", parametrosLogin)
            });

            HttpResponseMessage response = await request.PostAsync(url, parametros);

            if (response.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

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
            return null;            
        }
    }
}
