using MeDeiBem.Model;
using MeDeiBem.ServicesAPI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClassificadosView : ContentPage
	{       
		public ClassificadosView ()
		{
			InitializeComponent ();

            BindingContext = ListaClassificados();
        }

        private async Task<List<Classificado>> ListaClassificados()
        {
            List<Classificado> Classificados = await ClassificadoService.GetListaClassificados();
            LstClassificados.ItemsSource = Classificados;
            return Classificados;
        }

        private void LstClassificados_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (Classificado)e.Item;
            Navigation.PushAsync(new ListaImagensClassificado(item));
        }

        private async void SbcPesquisar_OnClicked(object sender, EventArgs e)
        {
            string busca = SbcPesquisar.TextSearch;
            List<Classificado> Classificados = await ClassificadoService.GetListaClassificados(busca);
            LstClassificados.ItemsSource = Classificados;
        }
    }
}