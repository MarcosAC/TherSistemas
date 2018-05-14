using System;
using System.Collections.Generic;
using System.Text;

namespace MeDeiBem.ServicesAPI.ModelAPI
{
    public class Usuario
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string radarUf { get; set; }
        public string radarCidade { get; set; }
        public string senha { get; set; }
    }
}
