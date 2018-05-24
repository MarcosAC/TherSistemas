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

            CarregarPromocoes();            
        }

        private async void CarregarPromocoes()
        {
            List<Promocao> Promocoes = await PromocaoService.GetListaPromocoes();            
            LstPromocoes.ItemsSource = Promocoes;
        }

        private void LstPromocoes_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {           
            var item = (Promocao)e.SelectedItem;
            Navigation.PushAsync(new DetalhesPromocao(item));            
        }
    }
}