using Pizza.Net.RestAPIAccess;
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

    class PizzasInOrderCreatorViewModel : ObservableObject, IPizzasInOrderCreatorViewModel
    {
        private readonly PizzasInOrderCreatorModel _currentPizzasInOrderCreatorModel;
        private LoggedUser _user;

        public PizzasInOrderCreatorViewModel(PizzasInOrderCreatorModel newPizzasInOrderCreatorModel, LoggedUser user)
        {
            _user = user;
            _currentPizzasInOrderCreatorModel = newPizzasInOrderCreatorModel;
            SearchPizzasViewModel = new PizzasTableViewModel();
            SelectedPizzasViewModel = new PizzasTableViewModel();
            SizesTableViewModel = new SizesTableViewModel();
            Clear();
            var pa = new PizzaAccess();
            _getTaskCompletion = new NotifyTaskCompletion<MenuModel>(pa.Get());
            _getTaskCompletion.PropertyChanged += GetMenuTaskCompleted;
            ProgressBarText = "Getting menu...";
            ProgressBarVisibility = true;
        }

        private async void GetMenuTaskCompleted(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _getTaskCompletion.PropertyChanged -= GetMenuTaskCompleted;
            var menu = await _getTaskCompletion.Task;
            var pizzaCollection = new ObservableCollection<PizzaModel>(menu.Pizzas);
            SearchPizzasViewModel.Pizzas = pizzaCollection;
            SizesTableViewModel.Sizes = new ObservableCollection<SizeModel>(menu.Sizes);
            ProgressBarVisibility = false;
        }

        private NotifyTaskCompletion<MenuModel> _getTaskCompletion;

        private bool _progressBarVisibility = true;
        public bool ProgressBarVisibility
        {
            get
            {
                return _progressBarVisibility;
            }
            set
            {
                if (value != _progressBarVisibility)
                {
                    _progressBarVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _progressBarText;
        public string ProgressBarText
        {
            get
            {
                return _progressBarText;
            }
            set
            {
                if (value == _progressBarText)
                    return;
                _progressBarText = value;
                OnPropertyChanged();
            }
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

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new RelayCommand(
                        param => Clear());
                }
                return _clearCommand;
            }
        }

        private void Clear()
        {
            SelectedPizzasViewModel.Pizzas.Clear();
        }

        private void AddPizza()
        {
            var item = SearchPizzasViewModel.SelectedPizza;
            if (item == null)
                return;
            var item2 = SizesTableViewModel.SelectedSize;
            if (item2 == null)
                return;
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
        }
    }
}