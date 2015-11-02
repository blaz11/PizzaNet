using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class SizesTable
    {
        public SizesTable()
        {
            Sizes = new ObservableCollection<SizeEntity>();
            for (int i = 0; i < 15; i++)
            {
                Sizes.Add(new SizeEntity());
            }
        }

        public ObservableCollection<SizeEntity> Sizes { get; set; }
    }
}