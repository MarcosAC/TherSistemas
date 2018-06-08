using MeDeiBem.Model;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaImagensClassificado : ContentPage
	{
		public ListaImagensClassificado (Classificado itemClassificado)
		{
			InitializeComponent ();

            BindingContext = itemClassificado;

            ListarImagens(itemClassificado);
		}

        private void ListarImagens(Classificado linkImagem)
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

            List<string> imagens = new List<string>();

            foreach (var link in linkImagens)
            {
                string flag = "http://";

                if (link != flag)
                    imagens.Add(link);
            }

            LstImagensClassificado.ItemsSource = imagens;
        }
	}
}