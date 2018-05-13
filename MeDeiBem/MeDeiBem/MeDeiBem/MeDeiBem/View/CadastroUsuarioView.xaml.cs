using MeDeiBem.ServicesAPI;
using MeDeiBem.ServicesAPI.ModelAPI;
using MeDeiBem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroUsuarioView : ContentPage
	{        
        public CadastroUsuarioView ()
		{
			InitializeComponent ();

            BindingContext = new CadastroUsuarioViewModel();
           //Isso é só um teste.
        }        
    }
}