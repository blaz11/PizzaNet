using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    class OrderCreatorViewModel : ChangingPagesBaseViewModel, IPageViewModel
    {
        public OrderCreatorViewModel(IOrderCreatorModel orderCreatorModel, IClientsPageViewModel clientsPageViewModel, IPizzasInOrderCreatorViewModel pizzasPageViewModel)
        {
            _orderCreatorModel = orderCreatorModel;

            PageViewModels.Add(clientsPageViewModel);
            _nextStepButtonContents.Add("Add client");
            PageViewModels.Add(pizzasPageViewModel);
            _nextStepButtonContents.Add("Add pizzas");
            PageViewModels.Add(new OrderSubmitViewModel());
            _nextStepButtonContents.Add("Submit Order");
            AdvanceToNextStep();
        }

        private List<string> _nextStepButtonContents = new List<string>();

        private int _currentStepIndex = 0;
        private IOrderCreatorModel _orderCreatorModel;

        private string _nextStepButtonContent;
        public string NextStepButtonContent
        {
            get
            {
                return _nextStepButtonContent;
            }
            set
            {
                if (value != _nextStepButtonContent)
                {
                    _nextStepButtonContent = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isPreviousStepButtonEnabled;
        public bool IsPreviousStepButtonEnabled
        {
            get
            {
                return _isPreviousStepButtonEnabled;
            }
            set
            {
                if (value != _isPreviousStepButtonEnabled)
                {
                    _isPreviousStepButtonEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand _nextStepCommand;
        public ICommand NextStepCommand
        {
            get
            {
                if (_nextStepCommand == null)
                {
                    _nextStepCommand = new RelayCommand(
                        execute => AdvanceToNextStep());
                }

                return _nextStepCommand;
            }
        }

        private ICommand _previousCommand;
        public ICommand PreviousCommand
        {
            get
            {
                if (_previousCommand == null)
                {
                    _previousCommand = new RelayCommand(
                        execute => GoToPreviousStep());
                }

                return _previousCommand;
            }
        }

        private ICommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                {
                    _resetCommand = new RelayCommand(
                        execute => Reset());
                }

                return _resetCommand;
            }
        }

        public string PageName
        {
            get
            {
                return "Create order";
            }
        }

        private void AdvanceToNextStep()
        {
            var orderSubmitViewModel = (PageViewModels[2] as OrderSubmitViewModel);
            switch (_currentStepIndex)
            {
                case 0:
                    break;
                case 1:
                    var client = (CurrentPageViewModel as ClientsPageViewModel).SelectedClient;
                    if (client == null)
                    {
                        return;
                    }
                    orderSubmitViewModel.Client.Clients.Clear();
                    orderSubmitViewModel.Client.Clients.Add(client);
                    break;

                case 2:
                    var selectedPizzasViewModel = (CurrentPageViewModel as PizzasInOrderCreatorViewModel).SelectedPizzasViewModel;
                    if (selectedPizzasViewModel.Pizzas.Count == 0)
                    {
                        return;
                    }
                    orderSubmitViewModel.Sizes = (CurrentPageViewModel as PizzasInOrderCreatorViewModel).sizes;
                    ObservableCollection<Domain.Pizza> pizzas = new ObservableCollection<Domain.Pizza>();
                    foreach (var v in selectedPizzasViewModel.Pizzas)
                    {
                        orderSubmitViewModel.Pizzas.Pizzas.Add(v);
                    }
                    break;
                case 3:
                    orderSubmitViewModel.Submit();
                    Reset();
                    return;
            }
            GoToNextStep();
        }

        private void GoToNextStep()
        {
            _currentStepIndex++;
            CurrentPageViewModel = PageViewModels[_currentStepIndex - 1];
            NextStepButtonContent = _nextStepButtonContents[_currentStepIndex - 1];
            ManagePreviousButtonStatus();
        }

        private void GoToPreviousStep()
        {
            if (_currentStepIndex == 1)
                return;
            _currentStepIndex--;
            CurrentPageViewModel = PageViewModels[_currentStepIndex - 1];
            NextStepButtonContent = _nextStepButtonContents[_currentStepIndex - 1];
            if (_currentStepIndex == 1)
            {
                var clientsPageViewModel = (CurrentPageViewModel as ClientsPageViewModel);
                clientsPageViewModel.SetActiveClient(clientsPageViewModel.SelectedClient);
            }
            ManagePreviousButtonStatus();
        }

        private void ManagePreviousButtonStatus()
        {
            if (_currentStepIndex == 1)
                IsPreviousStepButtonEnabled = false;
            else
                IsPreviousStepButtonEnabled = true;
        }

        private void Reset()
        {
            _currentStepIndex = 0;
            AdvanceToNextStep();
        }
    }
}