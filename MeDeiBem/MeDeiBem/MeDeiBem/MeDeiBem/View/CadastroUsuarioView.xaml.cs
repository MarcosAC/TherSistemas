using MeDeiBem.Model;
using MeDeiBem.ServicesAPI;
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

            CarregarEstados();           
        }

        /*
         * Métodos que carrega os estados e as cidades para o picker. 
         */
        private async void CarregarEstados()
        {
            List<RadarEstado> ListaEstados = await EstadoService.GetEstado();
            PckRadarEstado.ItemsSource = ListaEstados;
        }

        private async void CarregarCidades(string sigla)
        {
            List<RadarCidade> ListaCidades = await CidadeService.GetCidade(sigla);
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

        /*
         * Campos do formulario.
         */
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
            senha = TxtConfirmaSenha.Text;
        }

        /*
         * Pickers Estado e Cidade.
         */
        private void PckRadarEstado_OnSelectIndexChange(object sender, EventArgs e)
        {
            var estado = (RadarEstado)PckRadarEstado.SelectedItem;

            if (PckRadarEstado.SelectedIndex != -1)
            {
                radarUf = estado.sigla;

                CarregarCidades(radarUf);
            }
        }

        private void PckRadarCidade_OnSelectIndexChange(object sender, EventArgs e)
        {
            var cidade = (RadarCidade)PckRadarCidade.SelectedItem;

            if (PckRadarCidade.SelectedIndex != -1)
            {
                radarCidade = cidade.idcidade;
            }
        }

        /*
         * Botões: Cadastrar e Limpar
         */
        private async void BtnCadastrarUsuario_OnClicked(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {
                nome = nome,
                sobrenome = sobrenome,
                email = email,
                radar_uf = radarUf,
                radar_cid = radarCidade,
                senha = senha
            };

            await CadastrarUsuario.AddUsuario(usuario);            
        }
        
        private void BtnLimpar_OnClicked(object sender, EventArgs e)
        {
            TxtNome.Text = string.Empty;
            TxtSobrenome.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            PckRadarEstado.SelectedIndex = -1;
            PckRadarCidade.SelectedIndex = -1;
            TxtSenha.Text = string.Empty;
            TxtConfirmaSenha.Text = string.Empty;
        }
    }
}