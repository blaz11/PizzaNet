using Pizza.Net.Domain;
using System;
using System.Windows.Data;

namespace Pizza.Net.Screens.Entities
{
    [ValueConversion(typeof(object), typeof(string))]
    public class EmployeeToEntityFieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            var employee = value as Employee;
            if (employee == null)
                return value;
            return employee.FirstName + " " + employee.LastName;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}