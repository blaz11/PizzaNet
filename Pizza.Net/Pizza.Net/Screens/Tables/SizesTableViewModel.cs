using Pizza.Net.Domain;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface ISizesTableViewModel
    {
        Size SelectedSize { get; set; }
        ObservableCollection<Size> Sizes { get; set; }
    }

    class SizesTableViewModel : ObservableObject, ISizesTableViewModel
    {
        private ObservableCollection<Size> _sizes = new ObservableCollection<Size>();
        public ObservableCollection<Size> Sizes
        {
            get
            {
                return _sizes;
            }
            set
            {
                if (value != _sizes)
                {
                    _sizes = value;
                    OnPropertyChanged();
                }
            }
        }

        private Size _selectedSize;
        public Size SelectedSize
        {
            get
            {
                return _selectedSize;
            }
            set
            {
                if (value != _selectedSize)
                {
                    _selectedSize = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}