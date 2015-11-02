using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Pizza.Net.Screens.Entities
{
    [ValueConversion(typeof(object), typeof(string))]
    public class PizzasInOrderCollectionToLookupEntityCollection : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                            System.Globalization.CultureInfo culture)
        {
            var items = value as ICollection<Pizza.Net.Domain.Pizza_Order>;
            var converted = new List<string>();
            foreach (var item in items)
            {
                string v = item.Pizza.Name + " " + item.Size.Name + " " + item.Pizza.Price;
                converted.Add(v);
            }
            return converted;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
