using MeDeiBem.Model;
using MeDeiBem.ServicesAPI;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PromocoesView : ContentPage
	{
		public PromocoesView ()
		{
			InitializeComponent ();

            ListaPromocoes();
        }        

        private async void ListaPromocoes()
        {
            ActIndicator.IsVisible = true;

            List<Promocao> Promocoes = await PromocaoService.GetListaPromocoes();            
            LstPromocoes.ItemsSource = Promocoes;

            ActIndicator.IsVisible = false;
        }

        private void LstPromocoes_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemPromocao = (Promocao)e.Item;
            Navigation.PushAsync(new DetalhesPromocao(itemPromocao));
        }
        
        private async void SbcPromocoes_OnClicked(object sender, EventArgs e)
        {
            ActIndicator.IsVisible = true;

            string busca = SbcPromocoes.TextSearch;
            List<Promocao> Promocoes = await PromocaoService.GetListaPromocoes(busca);
            LstPromocoes.ItemsSource = Promocoes;

            ActIndicator.IsVisible = false;
        }
    }
}