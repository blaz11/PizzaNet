using Pizza.Net.Domain;
using System;
using System.Windows.Data;

namespace Pizza.Net.Screens.Entities
{
    public class ClientToEntityFieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            var client = value as Client;
            if (client == null)
                return value;
            return client.FirstName + " " + client.LastName;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}