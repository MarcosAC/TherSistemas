using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BaixaDescontoView : ContentPage
	{
		public BaixaDescontoView (string codigoQR = null)
		{
			InitializeComponent ();

            BindingContext = this;

            TxtCodigoDesconto.Text = codigoQR;
		}

        private void TxtCodigoDesconto_OnTextChange(object sender, EventArgs e)
        {

        }

        private void TxtSenhaVendedor_OnTextChange(object sender, EventArgs e)
        {

        }

        private void TxtQuantidadeVendida_OnTextChange(object sender, EventArgs e)
        {

        }

        private void BtnLerCodigoQR_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LeitorQRView());
        }

        private void BtnRegistrar_OnClicked(object sender, EventArgs e)
        {

        }
    }
}