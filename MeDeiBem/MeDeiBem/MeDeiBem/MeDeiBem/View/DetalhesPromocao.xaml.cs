using MeDeiBem.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhesPromocao : ContentPage
	{
        ZXingBarcodeImageView qrcode;

        public DetalhesPromocao (Promocao itemPromocao)
		{
			InitializeComponent ();
            
            BindingContext = itemPromocao;

            CarregarCarrossel(itemPromocao);

            qrcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
            };

            qrcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qrcode.BarcodeOptions.Width = 300;
            qrcode.BarcodeOptions.Height = 300;
            qrcode.BarcodeOptions.Margin = 3;
            qrcode.BarcodeValue = LblCodigoPromocao.Text;

            CodigoQR.Children.Add(qrcode);
        }

        private void CarregarCarrossel(Promocao linkImagem)
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

            CarrosselDeImagens.ItemsSource = linkImagens;
        }

        private void BtnLerCodigoQR_OnClicked(object sender, EventArgs args)
        {

        }
    }
}