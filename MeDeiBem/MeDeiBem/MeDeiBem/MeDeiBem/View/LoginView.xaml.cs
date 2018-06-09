using MeDeiBem.DB;
using MeDeiBem.Model;
using MeDeiBem.ServicesAPI;
using System;
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

        private string _email;
        private void TxtEmail_OnTextChange(object sender, EventArgs e)
        {
            _email = TxtEmail.Text;
        }

        private string _senha;
        private void TxtSenha_OnTextChanged(object sender, EventArgs e)
        {
            _senha = TxtSenha.Text;
        }

        private async void BtnEntrar_OnClicked(object sender, EventArgs e)
        {
            var parametros = new Login
            {
                email = _email,
                senha = _senha
            };

            if (await AutenticacaoUsuario.AutenticarUsuario(parametros))
            {
                await Navigation.PushAsync(new MasterPageView());
            }
            
        }

        private void BtnEsqueciSenha_OnClicked(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            dataBase.UsuarioLogado();
        }

        private void BtnQueroParticipar_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroUsuarioView());
        }
    }
}