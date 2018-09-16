using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SobreView : ContentPage
	{
		public SobreView ()
		{
			InitializeComponent ();
		}

        private void BtnPoliticaPrivacidade_OnClicked(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.medeibem.mobi/politica-app.php"));
        }
    }
}