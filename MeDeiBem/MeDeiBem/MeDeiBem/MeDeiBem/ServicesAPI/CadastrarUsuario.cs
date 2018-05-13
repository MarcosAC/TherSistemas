using MeDeiBem.ServicesAPI.ModelAPI;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace MeDeiBem.ServicesAPI
{
    public class CadastrarUsuario
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

        public async static Task GetUsuario(Usuario usuario)
        {
            var url = BaseUrl + "?a=vl&d=";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("senha", usuario.Email),
                new KeyValuePair<string, string>("senha", usuario.Senha)
            });

            HttpClient request = new HttpClient();
            HttpResponseMessage response = await request.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao cadastrar usuario");
            }
        }

        public async static Task<bool> AddUsuario(Usuario usuario)
        {
            var url = BaseUrl + "?a=ru&d=";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", usuario.Nome),
                new KeyValuePair<string, string>("sobrenome", usuario.Sobrenome),
                new KeyValuePair<string, string>("email", usuario.Email),
                new KeyValuePair<string, string>("radar_uf", usuario.RadarUf),
                new KeyValuePair<string, string>("radar_cid", usuario.RadarCidade),
                new KeyValuePair<string, string>("senha", usuario.Senha)
            });

            HttpClient request = new HttpClient();
            HttpResponseMessage response = await request.PostAsync(url, parametros);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;                  
            }
            return false;
        }
    }
}
