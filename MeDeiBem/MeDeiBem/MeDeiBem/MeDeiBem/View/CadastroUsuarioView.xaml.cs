using MeDeiBem.DB;
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

            BindingContext = CarregaDadosUsuario();

            CarregarEstados();
        }

        #region Variaveis que recebe os dados dos campos de cadastro.
        private string nome;
        private string sobrenome;
        private string email;
        private string radarUf;
        private string estado;
        private string radarCidade;
        private string cidade;
        private string senha;
        private string confirmaSenha;
        
        #endregion

        /*
         * Métodos que carrega os estados e as cidades para o picker. 
         */
        private async void CarregarEstados()
        {
            ActIndicator.IsVisible = true;
            ActIndicator.IsRunning = true;

            var dadosUsuario = DataBase.GetUsuario();

            if (dadosUsuario != null)
            {
                List<RadarEstado> ListaEstados = await EstadoService.GetEstado();
                PckRadarEstado.ItemsSource = ListaEstados;
                var index = ListaEstados.FindIndex(e => e.estado == dadosUsuario.estado);
                PckRadarEstado.SelectedIndex = index;
            }
            else
            {
                List<RadarEstado> ListaEstados = await EstadoService.GetEstado();
                PckRadarEstado.ItemsSource = ListaEstados;
            }

            ActIndicator.IsVisible = false;
            ActIndicator.IsRunning = false;
        }

        private async void CarregarCidades(string sigla)
        {
            var dadosUsuario = DataBase.GetUsuario();

            if (dadosUsuario != null)
            {
                var objEstado = (RadarEstado)PckRadarEstado.SelectedItem;
                List<RadarCidade> ListaCidades = await CidadeService.GetCidade(objEstado.sigla);
                PckRadarCidade.ItemsSource = ListaCidades;
                var index = ListaCidades.FindIndex(c => c.cidade_nome == dadosUsuario.cidade);
                PckRadarCidade.SelectedIndex = index;
            }
            else
            {
                List<RadarCidade> ListaCidades = await CidadeService.GetCidade(sigla);
                PckRadarCidade.ItemsSource = ListaCidades;
            }
            
        }

        private Usuario CarregaDadosUsuario()
        {
            ActIndicator.IsVisible = true;
            ActIndicator.IsRunning = true;

            var dadosUsuario = DataBase.GetUsuario();

            ActIndicator.IsVisible = false;
            ActIndicator.IsRunning = false;

            return dadosUsuario;
        }

        private void LimparCampos()
        {
            TxtNome.Text = string.Empty;
            TxtSobrenome.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            PckRadarEstado.SelectedIndex = -1;
            PckRadarCidade.ItemsSource = null;
            PckRadarCidade.Items.Clear();
            TxtSenha.Text = string.Empty;
            TxtConfirmaSenha.Text = string.Empty;
        }

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
            confirmaSenha = TxtConfirmaSenha.Text;
        }

        /*
         * Pickers Estado e Cidade.
         */
        private void PckRadarEstado_OnSelectIndexChange(object sender, EventArgs e)
        {
            var estado = (RadarEstado)PckRadarEstado.SelectedItem;

            if (PckRadarEstado.SelectedIndex != -1)
            {
                CarregarCidades(estado.sigla);

                radarUf = estado.sigla;
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
            if (confirmaSenha == senha)
            {
                var usuario = new Usuario
                {
                    nome = nome,
                    sobrenome = sobrenome,
                    email = email,
                    radar_uf = radarUf,
                    estado = estado,
                    radar_cid = radarCidade,
                    cidade = cidade,
                    senha = senha
                };

                await CadastrarUsuario.AddUsuario(usuario);

                LimparCampos();
            }
            else
            {
                await DisplayAlert("Put´s algo deu arrado :(", "As senhas não são iguais. Por favor digite novamente.", "Ok");
                TxtConfirmaSenha.Text = string.Empty;
            }           
        }
        
        private void BtnLimpar_OnClicked(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}