using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AudioPlayer : ContentView
	{
        
        public AudioPlayer ()
		{
			InitializeComponent ();            
        }

        private void BtnPlay_OnClicked(object sender, EventArgs e)
        {
            
        }

        private void BtnPause_OnClicked(object sender, EventArgs e)
        {

        }
    }
}