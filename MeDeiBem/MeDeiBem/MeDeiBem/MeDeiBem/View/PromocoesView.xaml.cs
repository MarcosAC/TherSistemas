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
            List<Promocao> Promocoes = await PromocaoService.GetListaPromocoes();            
            LstPromocoes.ItemsSource = Promocoes;
        }

        private void LstPromocoes_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (Promocao)e.Item;
            Navigation.PushAsync(new DetalhesPromocao(item));
        }
    }
}