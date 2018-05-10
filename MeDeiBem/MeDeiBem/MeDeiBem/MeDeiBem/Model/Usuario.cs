using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MeDeiBem.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
        public string RadarUf { get; set; }
        public string RadarCidade { get; set; }
        public string Token { get; set; }
        public int IndLogado { get; set; }
        public DateTime DthUltSincr { get; set; }
    }
}
