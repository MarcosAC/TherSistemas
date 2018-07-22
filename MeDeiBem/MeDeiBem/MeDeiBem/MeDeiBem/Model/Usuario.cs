using SQLite;

namespace MeDeiBem.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        public string senha { get; set; }
        public string confirmaSenha { get; set; }
        public int sinc_stat { get; set; }
        public string sinc_msg { get; set; }
        public string app_key { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string radar_uf { get; set; }
        public string estado { get; set; }
        public string radar_cid { get; set; }
        public string cidade { get; set; }
        public string dth_last_sincr { get; set; }
        public string clf_idcateg { get; set; }
        public string clf_idsubcateg { get; set; }
        public string clf_titulo { get; set; }
        public string clf_texto { get; set; }
        public string clf_contato_h1 { get; set; }
        public string clf_contato_h2 { get; set; }
        public string clf_contato_tel { get; set; }
        public string clf_contato_email { get; set; }
        public string clf_data_reg { get; set; }
        public string clf_data_ini { get; set; }
        public string clf_data_fim { get; set; }
        public string clf_situacao { get; set; }
    }
}