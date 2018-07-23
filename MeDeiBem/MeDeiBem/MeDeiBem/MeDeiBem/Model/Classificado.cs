using SQLite;
using System.Collections.Generic;

namespace MeDeiBem.Model
{
    [Table("Classificado")]
    public class Classificado
    {
        [PrimaryKey, AutoIncrement]
        public int IdClassificado { get; set; }
        public string id { get; set; }
        public int sinc_stat { get; set; }
        public string sinc_msg { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }
        public string contato_email { get; set; }
        public string contato_tel { get; set; }
        public string contato_hora { get; set; }
        public string contato_h1 { get; set; }
        public string contato_h2 { get; set; }
        public string contatoHorario1 { get; set; }
        public string contatoHorario2 { get; set; }
        public string pago { get; set; }
        public string idCategoria { get; set; }
        public string categ { get; set; }
        public string idSubcategoria { get; set; }
        public string subcateg { get; set; }
        public string situacao { get; set; }
        public string observacao { get; set; }
        public string data_ini { get; set; }
        public string data_fim { get; set; }
        public string dth_last_sincr { get; set; }
        private string _img_link1;
        public string img_link1 { get { return "http://" + _img_link1; } set { _img_link1 = value; } }
        private string _img_link2;
        public string img_link2 { get { return "http://" + _img_link2; } set { _img_link2 = value; } }
        private string _img_link3;
        public string img_link3 { get { return "http://" + _img_link3; } set { _img_link3 = value; } }
        private string _img_link4;
        public string img_link4 { get { return "http://" + _img_link4; } set { _img_link4 = value; } }
        private string _img_link5;
        public string img_link5 { get { return "http://" + _img_link5; } set { _img_link5 = value; } }
        private string _img_link6;
        public string img_link6 { get { return "http://" + _img_link6; } set { _img_link6 = value; } }

        public IEnumerable<string> Imagens
        {
            get
            {
                var imagens = new List<string>();

                string flag = "http://";

                if (img_link1 != flag)
                    imagens.Add(img_link1);

                if (img_link2 != flag)
                    imagens.Add(img_link2);

                if (img_link3 != flag)
                    imagens.Add(img_link3);

                if (img_link4 != flag)
                    imagens.Add(img_link4);

                if (img_link5 != flag)
                    imagens.Add(img_link5);

                if (img_link6 != flag)
                    imagens.Add(img_link6);

                return imagens;
            }
        }
    }
}