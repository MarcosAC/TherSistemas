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

        public static readonly BindableProperty TextSearchProperty = 
            BindableProperty.Create(
                propertyName: "TextSearch",
                returnType: typeof(string),
                declaringType: typeof(SearchBarCustom),
                defaultValue: "",
                defaultBindingMode: BindingMode.TwoWay
                //propertyChanged: TextSearchPropertyChanged
            );
        
        public string TextSearch
        {
            get { return (string)GetValue(TextSearchProperty); }
            set { SetValue(TextSearchProperty, value); }
        }

        //private static void TextSearchPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    var searchBarCustom = (SearchBarCustom)bindable;

        //    searchBarCustom.textSearch.Text = (string)newValue;
        //}

        private void On_clickScope(object sender, EventArgs e)
        {
            if (ClickScope != null)
            {
                ClickScope(sender, e);
            }
        }
    }
}