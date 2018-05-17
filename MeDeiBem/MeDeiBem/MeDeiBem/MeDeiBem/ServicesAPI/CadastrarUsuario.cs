using MeDeiBem.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class CadastrarUsuario
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;        

        public async static Task<bool> AddUsuario(Usuario usuario)
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

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
