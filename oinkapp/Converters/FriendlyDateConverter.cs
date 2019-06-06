using System;
using System.Globalization;
using Xamarin.Forms;

namespace oinkapp.Converters
{
    public class FriendlyDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateIn = (DateTime)value;
            string dateStringOut = dateIn.ToString("dddd, dd MMMM yyyy");
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dateStringOut);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}