using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuncoesView : ContentPage
    {
		public FuncoesView ()
		{
			InitializeComponent ();            
        }

        private void BtnPromocoes_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PromocoesView());
        }

        private void BtnClassificados_OnClicked(object sender, EventArgs e)
        {

        }

        private void BtnPodcasts_OnClicked(object sender, EventArgs e)
        {

        }

    }
}