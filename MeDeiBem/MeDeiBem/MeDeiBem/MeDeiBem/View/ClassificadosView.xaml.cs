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
            ActIndicator.IsVisible = true;

            List<Classificado> Classificados = await ClassificadoService.GetListaClassificados();
            LstClassificados.ItemsSource = Classificados;

            ActIndicator.IsVisible = false;

            return Classificados;
        }

        private void LstClassificados_OnItemTapped(object sender, ItemTappedEventArgs e)
        {            
            var item = (Classificado)e.Item;

            if (item.img_link1 != "http://")
            {
                Navigation.PushAsync(new ListaImagensClassificado(item));
            }          
        }

        private async void SbcClassificados_OnClicked(object sender, EventArgs e)
        {
            ActIndicator.IsVisible = true;

            string busca = SbcClassificados.TextSearch;
            List<Classificado> Classificados = await ClassificadoService.GetListaClassificados(busca);
            LstClassificados.ItemsSource = Classificados;

            ActIndicator.IsVisible = false;
        }
    }
}