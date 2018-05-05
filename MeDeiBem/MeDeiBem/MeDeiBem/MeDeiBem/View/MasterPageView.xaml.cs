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
	public partial class MasterPageView : MasterDetailPage
    {
		public MasterPageView ()
		{
			InitializeComponent ();            
        }

        private void BtnBaixaDesconto_Clicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.BaixaDescontoView());
            IsPresented = false;
        }

        private void BtnFuncoes_Clicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new FuncoesView());             
            IsPresented = false;
        }

        private void BtnMeuClassificado_Clicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.CadastroClassificadoView());
            IsPresented = false;
        }

        private void BtnMeuCadastro_Clicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.CadastroUsuarioView());
            IsPresented = false;
        }

        private void BtnRadarOfertas_Clicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.CadastroUsuarioView());
            IsPresented = false;
        }

        private void BtnSobre_Clicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.SobreView());
            IsPresented = false;
        }

        private void BtnSair_Clicked(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.LoginView());
            IsPresented = false;
        }

    }
}