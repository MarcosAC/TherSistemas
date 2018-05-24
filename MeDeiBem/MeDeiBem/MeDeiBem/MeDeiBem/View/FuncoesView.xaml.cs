using MeDeiBem.DB;
using MeDeiBem.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuncoesView : ContentPage
    {
		public FuncoesView ()
		{
			InitializeComponent ();

            LblRadarEstado.Text =  DadosUsuario().radar_uf;
            LblRadarCidade.Text =  DadosUsuario().cidade;
            LblEmail.Text =  DadosUsuario().email;
        }

        private Usuario DadosUsuario()
        {
            DataBase DataBase = new DataBase();
            return DataBase.GetUsuario();
        }        

        private void BtnPromocoes_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PromocoesView());
        }

        private void BtnClassificados_OnClicked(object sender, EventArgs e)
        {

        }

        private void BtnPodcasts_OnClicked(object sender, EventArgs e)
        {

        }
    }
}