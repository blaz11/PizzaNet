using Pizza.Net.Domain;
using System;
using System.Windows.Data;

namespace Pizza.Net.Screens.Entities
{
    [ValueConversion(typeof(object), typeof(string))]
    public class ClientToEntityFieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            var client = value as Client;
            return client.First_Name + " " + client.Last_Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}