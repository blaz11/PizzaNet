using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class IngredientsTable
    {
        public IngredientsTable()
        {
            Ingredients = new ObservableCollection<IngredientEntity>();
            for (int i = 0; i < 15; i++)
            {
                Ingredients.Add(new IngredientEntity());
            }
        }

        public ObservableCollection<IngredientEntity> Ingredients { get; set; }
    }
}
