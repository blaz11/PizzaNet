using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace Pizza.Net.Screens.Entities
{
    public class PizzasInOrderCollectionToListOfEntitiesCollection : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                            System.Globalization.CultureInfo culture)
        {
            var items = value as ICollection<Pizza.Net.Domain.PizzaOrder>;
            if (items == null)
                return value;
            var converted = new List<string>();
                foreach (var item in items)
            {
                string v = item.Pizza.Name + " " + item.Size.Name + " " + item.Pizza.Price * item.Size.BasePriceMultiplier;
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
