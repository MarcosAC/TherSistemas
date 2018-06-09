using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchBarCustom : ContentView
	{
        public event EventHandler ClickScope;

		public SearchBarCustom ()
		{
			InitializeComponent ();
		}

        private void On_clickScope(object sender, EventArgs e)
        {
            if (ClickScope != null)
            {
                ClickScope(sender, e);
            }
        }
    }
}