using PizzaNetCore;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface ISizesTableViewModel
    {
        SizeModel SelectedSize { get; set; }
        ObservableCollection<SizeModel> Sizes { get; set; }
    }

    class SizesTableViewModel : ObservableObject, ISizesTableViewModel
    {
        private ObservableCollection<SizeModel> _sizes = new ObservableCollection<SizeModel>();
        public ObservableCollection<SizeModel> Sizes
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

        private SizeModel _selectedSize;
        public SizeModel SelectedSize
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