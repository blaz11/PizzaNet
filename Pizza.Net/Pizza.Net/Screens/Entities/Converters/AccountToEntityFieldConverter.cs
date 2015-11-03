using Pizza.Net.Domain;
using System;
using System.Windows.Data;

namespace Pizza.Net.Screens.Entities
{
    [ValueConversion(typeof(object), typeof(string))]
    public class AccountToEntityFieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            var account = value as Account;
            if (account == null)
                return value;
            return account.Username;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}