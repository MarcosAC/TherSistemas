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
        public string email { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string senha { get; set; }
        public string radarUf { get; set; }
        public string radarCidade { get; set; }
        public string token { get; set; }
        public int IndLogado { get; set; }
        public DateTime DthUltSincr { get; set; }
    }
}
