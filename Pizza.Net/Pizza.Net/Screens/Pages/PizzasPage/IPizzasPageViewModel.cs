using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    interface IPizzasPageViewModel: IPageViewModel
    {
        ICommand AddToSelectedCommand { get; }
        string Name { get; set; }
        ICommand RemoveFromSelectedCommand { get; }

        void Add();
        void Clear();
        void Edit();
        void Search();
    }
}