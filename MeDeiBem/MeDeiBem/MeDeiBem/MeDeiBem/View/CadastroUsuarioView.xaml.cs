using MeDeiBem.ServicesAPI;
using MeDeiBem.ServicesAPI.ModelAPI;
using MeDeiBem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroUsuarioView : ContentPage
	{
        private string nome;
        private string sobrenome;
        private string email;
        private string radarUf;
        private string radarCidade;
        private string senha;

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

        private async void CadastrarUsuario(object sender, EventArgs e)
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

        private void TxtNome_onTextChange(object sender, EventArgs e)
        {
            nome = TxtNome.Text;
        }

        private void TxtSobrenome_onTextChange(object sender, EventArgs e)
        {
            sobrenome = TxtSobrenome.Text;
        }

        private void TxtEmail_onTextChange(object sender, EventArgs e)
        {
            email = TxtEmail.Text;
        }

        private void TxtSenha_onTextChange(object sender, EventArgs e)
        {
            senha = TxtSenha.Text;
        }

        private void TxtConfirmaSenha_onTextChange(object sender, EventArgs e)
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
    }
}