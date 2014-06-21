using System;
using System.Globalization;
using System.Windows.Data;

namespace Musicista.UI
{
    [ValueConversion(typeof(double), typeof(double))]
    public class Adder : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is double)
                return (double)value + (double)parameter;
            if (parameter is int)
                return (double)value + (int)parameter;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value - (double)parameter;
        }
    }
}