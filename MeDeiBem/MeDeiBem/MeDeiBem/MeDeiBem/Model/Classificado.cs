using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MeDeiBem.Model
{
    [Table("Classificado")]
    public class Classificado
    {
        [PrimaryKey, AutoIncrement]
        public int IdClassificado { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string ContatoHora1 { get; set; }
        public string ContatoHora2 { get; set; }
        public string ContatoTelefone { get; set; }
        public string ContatoEmail { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataExpira { get; set; }
        public string Situacao { get; set; }
        public DateTime LastUpdate { get; set; }
        public int IndSinc { get; set; }
    }
}
