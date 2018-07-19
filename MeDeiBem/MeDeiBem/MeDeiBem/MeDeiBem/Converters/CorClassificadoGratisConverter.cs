using System;
using System.Globalization;
using Xamarin.Forms;

namespace MeDeiBem.Converters
{
    public class CorClassificadoGratisConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {   
            if ((string)value == "0")
            {
                return "#494949";
            }
            
            return "#498fff";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
