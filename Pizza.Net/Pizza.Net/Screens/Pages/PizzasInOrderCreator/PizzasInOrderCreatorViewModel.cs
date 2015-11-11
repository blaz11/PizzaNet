using Pizza.Net.Screens.Tables;
using System.Windows.Input;
using System;

namespace Pizza.Net.Screens.Pages
{
    interface IPizzasInOrderCreatorViewModel: IPageViewModel
    {
        ICommand AddPizzaCommands { get; }
        ICommand RemovePizzaCommand { get; }
        IPizzasTableViewModel SearchPizzasViewModel { get; }
        IPizzasTableViewModel SelectedPizzasViewModel { get; }
        ISizesTableViewModel SizesTableViewModel { get; }
    }

    class PizzasInOrderCreatorViewModel : IPizzasInOrderCreatorViewModel
    {
        public string PageName
        {
            get
            {
                return "Select Pizzas";
            }
        }

        public ISizesTableViewModel SizesTableViewModel { get; private set; }
        public IPizzasTableViewModel SearchPizzasViewModel { get; private set; }
        public IPizzasTableViewModel SelectedPizzasViewModel { get; private set; }

        private ICommand _removePizzaCommand;
        public ICommand RemovePizzaCommand
        {
            get
            {
                if (_removePizzaCommand == null)
                {
                    _removePizzaCommand = new RelayCommand(
                        param => AddPizza());
                }
                return _removePizzaCommand;
            }
        }

        private ICommand _addPizzaCommands;
        public ICommand AddPizzaCommands
        {
            get
            {
                if (_addPizzaCommands == null)
                {
                    _addPizzaCommands = new RelayCommand(
                        param => RemovePizza());
                }
                return _addPizzaCommands;
            }
        }

        private void AddPizza()
        {
            //To jest rmove
        }

        private void RemovePizza()
        {

        }
    }
}
