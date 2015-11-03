using Pizza.Net.Screens.Pages;
using System.Collections.Generic;

namespace Pizza.Net.Screens.Windows
{
    class ChangingPagesBaseViewModel : ObservableObject
    {
        public List<IPageViewModel> PageViewModels { get; } = new List<IPageViewModel>();

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