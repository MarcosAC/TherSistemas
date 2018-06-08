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
        }

        private void BtnFuncoes_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new FuncoesView());
            IsPresented = false;
        }

        private void BtnBaixaDesconto_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.BaixaDescontoView());
            IsPresented = false;
        }

        private void BtnMeuClassificado_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.CadastroClassificadoView());
            IsPresented = false;
        }

        private void BtnMeuCadastro_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.CadastroUsuarioView());
            IsPresented = false;
        }

        private void BtnRadarOfertas_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.ClassificadosView());
            IsPresented = false;
        }

        private void BtnSobre_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.SobreView());
            IsPresented = false;
        }

        private void BtnSair_OnClicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.LoginView());
            IsPresented = false;
        }
    }
}