﻿using System;
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
            );
        
        public string TextSearch
        {
            get { return (string)GetValue(TextSearchProperty); }
            set { SetValue(TextSearchProperty, value); }
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