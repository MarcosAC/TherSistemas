using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class CategoriaService
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

        public async static Task<List<Categoria>> GetCategoria(string keyUsuario)
        {
            var url = BaseUrl + "a=lctg&k=";

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string key = keyUsuario;

            try
            {
                HttpResponseMessage response = await request.GetAsync(url + key);

                if (response.IsSuccessStatusCode)
                {
                    string conteudo = await response.Content.ReadAsStringAsync();

                    if (conteudo.Length > 0)
                    {
                        List<Categoria> listaCategorias = JsonConvert.DeserializeObject<List<Categoria>>(conteudo);
                        return listaCategorias;
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
    }
}