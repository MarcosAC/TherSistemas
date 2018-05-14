using MeDeiBem.ServicesAPI.ModelAPI;
using Newtonsoft.Json;
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
            #region Códigos comentados
            /*string parametros = string.Format("nome:{0},sobrenome:{1},email:{2},radar_uf{3},radar_cid:{4},senha:{5}",
                                              usuario.Nome, usuario.Sobrenome, usuario.Email, usuario.RadarUf, usuario.RadarCidade, usuario.Senha);*/

            //StringContent parametros = new StringContent(string.Format("?a=ru&d=nome:{0},sobrenome:{1},email:{2},radar_uf{3},radar_cid:{4},senha:{5}", 
            //                                             usuario.Nome, usuario.Sobrenome, usuario.Email, usuario.RadarUf, usuario.RadarCidade, usuario.Senha), 
            //                                             Encoding.UTF8, "application/json");

            //FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
            //    new KeyValuePair<string, string>("{nome", usuario.Nome),
            //    new KeyValuePair<string, string>("sobrenome", usuario.Sobrenome),
            //    new KeyValuePair<string, string>("email", usuario.Email),
            //    new KeyValuePair<string, string>("radar_uf", usuario.RadarUf),
            //    new KeyValuePair<string, string>("radar_cid", usuario.RadarCidade),
            //    new KeyValuePair<string, string>("senha{0}}", usuario.Senha)
            //});

            //, usuario.nome, usuario.sobrenome, usuario.email, usuario.radarUf, usuario.radarCidade, usuario.senha)
            #endregion

            string url = BaseUrl + "?a=ru&d=nome:{0},sobrenome:{1},email:{2},radar_uf{3},radar_cid:{4},senha:{5}";
                        
            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(string.Format(url, usuario.nome, usuario.sobrenome, usuario.email, usuario.radarUf, usuario.radarCidade, usuario.senha))
            };

            var data = JsonConvert.SerializeObject(usuario);
            var parametros = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await request.PostAsync(url, parametros);

            if (response.IsSuccessStatusCode)
            {
                return true;                  
            }
            return false;
        }
    }
}
