using MeDeiBem.ServicesAPI;
using MeDeiBem.ServicesAPI.ModelAPI;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroUsuarioView : ContentPage
	{        
        public CadastroUsuarioView ()
		{
			InitializeComponent ();

            CarreagarEstados();
            CarregarCidades();
        }

        private async void CarreagarEstados()
        {
            List<RadarEstado> ListaEstados = await EstadoService.GetEstado();
            PckRadarEstado.ItemsSource = ListaEstados;
        }

        private async void CarregarCidades()
        {
            List<RadarCidade> ListaCidades = await CidadeService.GetCidade();
            PckRadarCidade.ItemsSource = ListaCidades;
        }

        #region Variaveis que recebe os dados dos campos de cadastro.
        private string nome;
        private string sobrenome;
        private string email;
        private string radarUf;
        private string radarCidade;
        private string senha;
        #endregion

        private void TxtNome_OnTextChange(object sender, EventArgs e)
        {
            nome = TxtNome.Text;
        }

        private void TxtSobrenome_OnTextChange(object sender, EventArgs e)
        {
            sobrenome = TxtSobrenome.Text;
        }

        private void TxtEmail_OnTextChange(object sender, EventArgs e)
        {
            email = TxtEmail.Text;
        }

        private void TxtSenha_OnTextChange(object sender, EventArgs e)
        {
            senha = TxtSenha.Text;
        }

        private void TxtConfirmaSenha_OnTextChange(object sender, EventArgs e)
        {
            TxtConfirmaSenha.Text = senha;
        }

        private void PckRadarEstado_OnSelectIndexChange(object sender, EventArgs e)
        {
            var estado = (RadarEstado)PckRadarEstado.SelectedItem;
            radarUf = estado.Estado;
        }

        private void PckRadarCidade_OnSelectIndexChange(object sender, EventArgs e)
        {
            var cidade = (RadarCidade)PckRadarCidade.SelectedItem;
            radarCidade = cidade.Cidade_Nome;
        }

        private async void BntCadastrarUsuario_OnClicked(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {
                nome = nome,
                sobrenome = sobrenome,
                email = email,
                radarUf = radarUf,
                radarCidade = radarCidade,
                senha = senha
            };

            try
            {
                if (await ServicesAPI.CadastrarUsuario.AddUsuario(usuario) == true)
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Usuario cadastrado com sucesso", "OK");
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }        
    }
}