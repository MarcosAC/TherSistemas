using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
		}

        private void BtnEntrar_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new View.MasterPageView();
        }

        private void BtnQueroParticipar_Clicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastroUsuarioView());
        }

        private void BtnEsqueciSenha_Clicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastroUsuarioView());
        }

    }
}