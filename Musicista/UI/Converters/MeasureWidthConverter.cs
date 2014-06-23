using System;
using System.Globalization;
using System.Windows.Data;

namespace Musicista.UI.Converters
{
    [ValueConversion(typeof(double), typeof(double))]
    public class MeasureWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value - ((UISystem)parameter).Indent) / ((UISystem)parameter).MeasuresInSystem;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value * ((UISystem)parameter).MeasuresInSystem + ((UISystem)parameter).Indent;
        }
    }
}