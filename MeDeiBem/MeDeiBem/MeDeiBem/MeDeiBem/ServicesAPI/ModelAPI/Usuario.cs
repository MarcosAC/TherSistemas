using System;
using System.Collections.Generic;
using System.Text;

namespace MeDeiBem.ServicesAPI.ModelAPI
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string RadarUf { get; set; }
        public string RadarCidade { get; set; }
        public string Senha { get; set; }
    }
}
