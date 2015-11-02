using Pizza.Net.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace Pizza.Net.Screens.Entities
{
    [ValueConversion(typeof(object), typeof(string))]
    public class IngredientsCollectionToListOfEntitiesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            var ingredients = value as ICollection<Ingredient>;
            if (ingredients == null)
                return value;
            var converted = new List<string>();
            foreach(var ing in ingredients)
            {
                converted.Add(ing.Name);
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