using System;
using System.Globalization;
using System.Windows.Data;

namespace Musicista.UI
{
    [ValueConversion(typeof(double), typeof(double))]
    public class MeasureWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value - ((UISystem)parameter).Indent) / 4;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value * 4 + ((UISystem)parameter).Indent;
        }
    }
}