using Pizza.Net.Domain;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface IIngredientsTableViewModel
    {
        ObservableCollection<Ingredient> Ingredients { get; set; }
        Ingredient SelectedIngredient { get; set; }
    }

    class IngredientsTableViewModel : ObservableObject, IIngredientsTableViewModel
    {

        private ObservableCollection<Ingredient> _ingredients = new ObservableCollection<Ingredient>();
        public ObservableCollection<Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                if (value != _ingredients)
                {
                    _ingredients = value;
                    OnPropertyChanged();
                }
            }
        }

        private Ingredient _selectedIngredient;
        public Ingredient SelectedIngredient
        {
            get
            {
                return _selectedIngredient;
            }
            set
            {
                if (value != _selectedIngredient)
                {
                    _selectedIngredient = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}