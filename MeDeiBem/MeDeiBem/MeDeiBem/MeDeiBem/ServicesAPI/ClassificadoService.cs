﻿using MeDeiBem.DB;
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

        public async static Task<List<Classificado>> GetListaClassificados()
        {
            var url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            string parametrosBuscaPromocoes = "{" + '"' + "range_ini" + '"' + ":" + '"' + "0" + '"' + "," +
                                                    '"' + "range_fim" + '"' + ":" + '"' + "100" + '"' + "," +
                                                    '"' + "busca" + '"' + ":" + '"' + "" + '"' + "}";

            string appKey = DataBase.GetAppKey();

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("a", "lclf"),
                new KeyValuePair<string, string>("k", appKey),
                new KeyValuePair<string, string>("d", parametrosBuscaPromocoes),
            });

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
    }
}