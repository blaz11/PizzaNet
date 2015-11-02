using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pizza.Net.Screens.Entities
{
    public partial class LookupEntity : UserControl
    {
        public LookupEntity()
        {
            InitializeComponent();
            var resource = FindResource("EntityFieldHeight");
            _entityHeight = System.Convert.ToDouble(resource);
        }

        private double _entityHeight;

        private void MouseEnteredLookupHitbox(object sender, MouseEventArgs e)
        {
            var itemHeight = FindResource("EntityFieldHeight");
            var numberOfItems = (DataContext as List<string>).Count;
            Lookup.Height = (numberOfItems + 1) * _entityHeight;
        }

        private void MouseLeftLookupHitbox(object sender, MouseEventArgs e)
        {
            Lookup.Height = _entityHeight;
        }
    }
}