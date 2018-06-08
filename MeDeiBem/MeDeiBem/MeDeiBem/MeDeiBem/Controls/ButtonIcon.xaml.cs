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
	public partial class ButtonIcon : ContentView
	{
        public event EventHandler ClickButton;

		public ButtonIcon ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty IconProperty = 
            BindableProperty.Create(
                propertyName: "Icon",
                returnType: typeof(string),
                declaringType: typeof(ButtonIcon),
                defaultValue: "",
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: IconPropertyChanged
            );        

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value);  }
        }

        private static void IconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var buttonIcon = (ButtonIcon)bindable;

            buttonIcon.icon.Text = (string)newValue;
        }

        public static readonly BindableProperty TextButtonProperty =
            BindableProperty.Create(
                propertyName: "TextButton",
                returnType: typeof(string),
                declaringType: typeof(ButtonIcon),
                defaultValue: "",
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: TextButtonPropertyChanged
            );

        public string TextButton
        {
            get { return (string)GetValue(TextButtonProperty); }
            set { SetValue(TextButtonProperty, value); }
        }

        private static void TextButtonPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var buttonIcon = (ButtonIcon)bindable;

            buttonIcon.textButton.Text = (string)newValue;
        }

        public static readonly BindableProperty TextButtonColorProperty =
            BindableProperty.Create(
                propertyName: "TextButtonColor",
                returnType: typeof(Color),
                declaringType: typeof(ButtonIcon),
                defaultValue: Color.Black,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: TextButtonColorPropertyChanged
            );
        public Color TextButtonColor
        {
            get { return (Color)GetValue(TextButtonColorProperty); }
            set { SetValue(TextButtonColorProperty, value); }
        }

        private static void TextButtonColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var buttonIcon = (ButtonIcon)bindable;

            buttonIcon.textButton.TextColor = (Color)newValue;
            buttonIcon.icon.TextColor = (Color)newValue;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (ClickButton != null)
            {   
                ClickButton(sender, e);
            }
        }
    }
}