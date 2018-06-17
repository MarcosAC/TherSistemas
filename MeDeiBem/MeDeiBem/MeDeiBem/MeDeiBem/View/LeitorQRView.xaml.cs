using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LeitorQRView : ContentPage
	{
        ZXingScannerView leitorQr;

        public LeitorQRView ()
		{
			InitializeComponent ();

            leitorQr = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            leitorQr.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    leitorQr.IsScanning = false;
                    LblCodigoQR.Text = result.Text;
                });
            };

            EscanerQR.Children.Add(leitorQr);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            leitorQr.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            leitorQr.IsScanning = false;

            base.OnDisappearing();
        }

        private void BtnBaixarDesconto_OnCliked(object sender, EventTrigger e)
        {
            Navigation.PushAsync(new BaixaDescontoView(LblCodigoQR.Text));
        }
    }
}