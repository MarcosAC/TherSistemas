﻿using MeDeiBem.Model;
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
            
            BindingContext = this;
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
            ActIndicator.IsVisible = true;

            #region Validação de Campos
            if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                await DisplayAlert("Put's, faltou algo! :O", "O campo EMAIL é obrigatório!", "Ok");
                ActIndicator.IsVisible = false;
                return;
            }

            if (string.IsNullOrEmpty(TxtSenha.Text))
            {
                await DisplayAlert("Put's, faltou algo! :O", "O campo SENHA é obrigatório!", "Ok");
                ActIndicator.IsVisible = false;
                return;
            }
            #endregion

            var parametros = new Login
            {
                email = _email,
                senha = _senha
            };

            if (await AutenticacaoUsuario.AutenticarUsuario(parametros))
            {   
                await Navigation.PushAsync(new MasterPageView());
            }

            ActIndicator.IsVisible = false;
        }

        private void BtnEsqueciSenha_OnClicked(object sender, EventArgs e)
        {
            ActIndicator.IsVisible = true;

            AutenticacaoUsuario.GerarNovaSenha(TxtEmail.Text);

            ActIndicator.IsVisible = false;
        }

        private void BtnQueroParticipar_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroUsuarioView());
        }
    }
}