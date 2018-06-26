using MeDeiBem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MeDeiBem.ServicesAPI
{
    public class SubCategoriaService
    {
        private static readonly string BaseUrl = Constantes.BASE_PROTOCOL + Constantes.BASE_URL + Constantes.BASE_API;

        public async static Task<List<SubCategoria>> GetSubCategoria(string keyUsuario, string idCategoria)
        {
            var url = BaseUrl + "a=lsctg&k=" + keyUsuario + "&ctg=" + idCategoria;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            try
            {
                HttpResponseMessage response = await request.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string conteudo = await response.Content.ReadAsStringAsync();

                    if (conteudo.Length > 0)
                    {
                        List<SubCategoria> listaSubCategorias = JsonConvert.DeserializeObject<List<SubCategoria>>(conteudo);
                        return listaSubCategorias;
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
