using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class PositionsTable
    {
        public PositionsTable()
        {
            Positions = new ObservableCollection<PositionEntity>();
            for (int i = 0; i < 15; i++)
            {
                Positions.Add(new PositionEntity());
            }
        }

        public ObservableCollection<PositionEntity> Positions { get; set; }
    }
}