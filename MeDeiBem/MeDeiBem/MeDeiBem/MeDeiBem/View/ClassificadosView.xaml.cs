using MeDeiBem.Model;
using MeDeiBem.ServicesAPI;
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
    }
}