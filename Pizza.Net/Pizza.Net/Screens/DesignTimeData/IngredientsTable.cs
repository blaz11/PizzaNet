﻿using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class IngredientsTable
    {
        public IngredientsTable()
        {
            Ingredients = new ObservableCollection<IngredientItem>();
            for (int i = 0; i < 15; i++)
            {
                Ingredients.Add(new IngredientItem());
            }
        }

        public ObservableCollection<IngredientItem> Ingredients { get; set; }
    }
}
