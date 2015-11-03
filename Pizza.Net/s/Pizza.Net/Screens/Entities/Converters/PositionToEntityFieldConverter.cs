using Pizza.Net.Domain;
using System;
using System.Windows.Data;

namespace Pizza.Net.Screens.Entities
{
    [ValueConversion(typeof(object), typeof(string))]
    public class PositionToEntityFieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            var position = value as Position;
            if (position == null)
                return value;
            return position.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}