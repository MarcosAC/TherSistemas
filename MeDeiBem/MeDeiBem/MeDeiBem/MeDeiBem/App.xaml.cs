using MeDeiBem.DB.ServicesDB;
using Xamarin.Forms;

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
            if (VerificarUsuarioLogado.Logado())
            {
                MainPage = new View.MasterPageView();
            }
            else
            {
                MainPage = new NavigationPage(new View.LoginView());
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
