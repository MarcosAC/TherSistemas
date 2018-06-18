using MeDeiBem.DB;
using MeDeiBem.DB.ServicesDB;
using MeDeiBem.ServicesAPI;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPageView : MasterDetailPage
    {
		public MasterPageView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            DesabilitaBotãoBaixaDesconto();
        }

        private void DesabilitaBotãoBaixaDesconto()
        {
            if (MostraPaginaBaixaDesconto.MostraPagina(DataBase.GetAppKey()))
            {
                BtnBaixaDesconto.IsEnabled = false;
                MenuBotoes.Children.Remove(BtnBaixaDesconto);                
            }
        }

        private void BtnFuncoes_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new FuncoesView());
            IsPresented = false;
        }

        private void BtnBaixaDesconto_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new BaixaDescontoView());
            IsPresented = false;            
        }

        private void BtnMeuClassificado_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new CadastroClassificadoView());
            IsPresented = false;
        }

        private void BtnMeuCadastro_OnClicked(object sender, EventArgs args)
        {            
            Detail = new NavigationPage(new CadastroUsuarioView());
            IsPresented = false;
        }

        private void BtnRadarOfertas_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ClassificadosView());
            IsPresented = false;
        }

        private void BtnSobre_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SobreView());
            IsPresented = false;
        }

        private void BtnSair_OnClicked(object sender, EventArgs args)
        {            
            VerificarUsuarioLogado.Deslogar();
            Detail = new NavigationPage(new LoginView());
            IsPresented = false;
        }
    }
}