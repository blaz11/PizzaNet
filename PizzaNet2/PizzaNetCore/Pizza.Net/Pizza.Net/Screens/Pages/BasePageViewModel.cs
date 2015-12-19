using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    class BaseTableInteractionViewModel : ObservableObject
    {
        public string AddButtonContent
        {
            get
            {
                if (!_searchMode)
                    return "Confirm";
                return "Add new";
            }
        }

        public string EditButtonContent
        {
            get
            {
                if (!_searchMode)
                    return "Cancel";
                return "Edit selected";
            }
        }

        private bool _searchMode = true;
        public bool SearchMode
        {
            get
            {
                return _searchMode;
            }
            set
            {
                if(value != _searchMode)
                {
                    _searchMode = value;
                    OnPropertyChanged("AddButtonContent");
                    OnPropertyChanged("EditButtonContent");
                    OnPropertyChanged();
                }
            }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(
                        param => Search());
                }
                return _searchCommand;
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

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        param => AddOrConfimEdit());
                }
                return _addCommand;
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(
                        param => Edit());
                }
                return _editCommand;
            }
        }

        public virtual void Search()
        {
        }

        public virtual void Clear()
        {
        }

        public virtual void AddOrConfimEdit()
        {
        }

        public virtual void Edit()
        {
        }
    }
}