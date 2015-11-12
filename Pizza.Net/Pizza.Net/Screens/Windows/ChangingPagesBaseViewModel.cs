using Pizza.Net.Screens.Pages;
using System.Collections.Generic;

namespace Pizza.Net.Screens
{
    class ChangingPagesBaseViewModel : ObservableObject
    {
        public ChangingPagesBaseViewModel()
        {
            PageViewModels = new List<IPageViewModel>();
        }

        public List<IPageViewModel> PageViewModels { get; private set; }

        private IPageViewModel _currentPageViewModel;
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}