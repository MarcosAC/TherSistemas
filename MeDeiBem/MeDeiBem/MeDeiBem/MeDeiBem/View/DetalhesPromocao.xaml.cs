using MeDeiBem.Model;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhesPromocao : ContentPage
	{
        public DetalhesPromocao (Promocao itemPromocao)
		{
			InitializeComponent ();
            
            BindingContext = itemPromocao;

            CarregarCarrousel(itemPromocao);
        }

        private void CarregarCarrousel(Promocao linkImagem)
        {
            var linkImagens = new List<string>
            {
                linkImagem.img_link1,
                linkImagem.img_link2,
                linkImagem.img_link3,
                linkImagem.img_link4,
                linkImagem.img_link5,
                linkImagem.img_link6
            };

            CarrouselDeImagens.ItemsSource = linkImagens;
        }
    }
}