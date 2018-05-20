namespace MeDeiBem.Model
{
    public class Promocao
    {
        public string id { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }
        public string categ { get; set; }
        public string subcateg { get; set; }
        public string preco_original { get; set; }
        public string preco_promocao { get; set; }
        public string desconto { get; set; }
        public string validade { get; set; }
        public string qtde_ofertada { get; set; }
        public string qtde_vendida { get; set; }
        public string qtde_disponivel { get; set; }
        public string codigo { get; set; }
        private string _img_link1;
        public string img_link1
        {
            get { return "http://" + _img_link1; }
            set { _img_link1 = value; }
        }
        public string img_link2 { get; set; }
        public string img_link3 { get; set; }
        public string img_link4 { get; set; }
        public string img_link5 { get; set; }
        public string img_link6 { get; set; }
        public string vnd_empresa { get; set; }
        public string vnd_email { get; set; }
        public string vnd_fone1 { get; set; }
        public string vnd_fone2 { get; set; }
        public string vnd_end1 { get; set; }
        public string vnd_end2 { get; set; }
        public string AppKey { get; set; }
    }
}  


    

    
    


