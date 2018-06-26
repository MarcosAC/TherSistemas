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
        public string senha { get; set; }
        public int sinc_stat { get; set; }
        public string sinc_msg { get; set; }
        public string app_key { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string radar_uf { get; set; }
        public string radar_cid { get; set; }
        public string cidade { get; set; }
        public string dth_last_sincr { get; set; }
    }
}