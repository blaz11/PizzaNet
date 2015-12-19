using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class SizesTable
    {
        public SizesTable()
        {
            Sizes = new ObservableCollection<SizeItem>();
            for (int i = 0; i < 15; i++)
            {
                Sizes.Add(new SizeItem());
            }
        }

        public ObservableCollection<SizeItem> Sizes { get; set; }
    }
}