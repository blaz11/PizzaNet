using Pizza.Net.Screens.Tables;
using PizzaNetCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    interface IPizzasInOrderCreatorViewModel : IPageViewModel
    {
        ICommand AddPizzaCommands { get; }
        ICommand RemovePizzaCommand { get; }
        IPizzasTableViewModel SearchPizzasViewModel { get; }
        IPizzasTableViewModel SelectedPizzasViewModel { get; }
        ISizesTableViewModel SizesTableViewModel { get; }
    }

    class PizzasInOrderCreatorViewModel : IPizzasInOrderCreatorViewModel
    {
        private readonly PizzasInOrderCreatorModel _currentPizzasInOrderCreatorModel;
        public PizzasInOrderCreatorViewModel(PizzasInOrderCreatorModel newPizzasInOrderCreatorModel)
        {
            _currentPizzasInOrderCreatorModel = newPizzasInOrderCreatorModel;
            SearchPizzasViewModel = new PizzasTableViewModel();
            SelectedPizzasViewModel = new PizzasTableViewModel();
            SizesTableViewModel = new SizesTableViewModel();
            Refresh();
        }


        public ObservableCollection<SizeModel> Sizes { get; set; } = new ObservableCollection<SizeModel>();

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
                        param => RemovePizza());
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
                        param => AddPizza());
                }
                return _addPizzaCommands;
            }
        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new RelayCommand(
                        param => Refresh());
                }
                return _refreshCommand;
            }
        }

        private void Refresh()
        {
            SearchPizzasViewModel.Pizzas.Clear();
            foreach (var v in _currentPizzasInOrderCreatorModel.GetPizza())
                SearchPizzasViewModel.Pizzas.Add(v);
            foreach (var v in SelectedPizzasViewModel.Pizzas)
                SearchPizzasViewModel.Pizzas.Remove(v);
            SizesTableViewModel.Sizes.Clear();
            foreach (var v in _currentPizzasInOrderCreatorModel.GetSizes())
                SizesTableViewModel.Sizes.Add(v);
        }

        private void AddPizza()
        {
            var item = SearchPizzasViewModel.SelectedPizza;
            if (item == null)
                return;
            var item2 = SizesTableViewModel.SelectedSize;
            if (item2 == null)
                return;
            SearchPizzasViewModel.Pizzas.Remove(item);
            SelectedPizzasViewModel.Pizzas.Add(item);
            Sizes.Add(item2);
        }

        private void RemovePizza()
        {
            var item = SelectedPizzasViewModel.SelectedPizza;
            if (item == null)
                return;
            Sizes.RemoveAt(SelectedPizzasViewModel.Pizzas.IndexOf(item));
            SelectedPizzasViewModel.Pizzas.Remove(item);
            SearchPizzasViewModel.Pizzas.Add(item);
        }
    }
}