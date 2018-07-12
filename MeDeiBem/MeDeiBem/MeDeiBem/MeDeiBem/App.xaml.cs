using MeDeiBem.DB.ServicesDB;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MeDeiBem
{
    public partial class App : Application
	{        
        public App ()
		{
			InitializeComponent();            
        }

		protected override void OnStart ()
		{
            // Handle when your app starts 
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                if (VerificarUsuarioLogado.Logado())
                {
                    MainPage = new View.MasterPageView();
                }
                else
                {
                    MainPage = new NavigationPage(new View.LoginView());
                }
            }
            else
            {
                MainPage = new View.SemConexao();
            }
            
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
