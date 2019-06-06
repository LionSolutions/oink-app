using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace oinkapp.Converters
{
    public class NumberIsZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value?.ToString())
                || !int.TryParse(value.ToString(), out var number)
                || number == 0
                || !Regex.IsMatch(value.ToString(), @"^[1-9]+[0-9]+([.][0-9]+)?$"))
                return true;            // some data has been entered
            else
                return false;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}