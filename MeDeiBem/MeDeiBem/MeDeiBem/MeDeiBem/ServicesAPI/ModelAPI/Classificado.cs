using System;
using System.Collections.Generic;
using System.Text;

namespace MeDeiBem.ServicesAPI.ModelAPI
{
    public class Classificado
    {
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string ContatoHora1 { get; set; }
        public string ContatoHora2 { get; set; }
        public string ContatoTelefone { get; set; }
        public string ContatoEmail { get; set; }
    }
}
