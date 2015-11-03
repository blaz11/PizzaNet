using System.Windows.Input;
using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;

namespace Pizza.Net.Screens.Pages
{
    interface IClientsPageViewModel : IPageViewModel
    {
        ICommand AddCommand { get; }
        string City { get; set; }
        ICommand ClearCommand { get; }
        ICommand EditCommand { get; }
        string FirstName { get; set; }
        string FlatNumber { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string PremiseNumber { get; set; }
        IClientsTableViewModel ClientsTableViewModel { get; }
        ICommand SearchCommand { get; }
        Client SelectedClient { get; }
        string Street { get; set; }
        string ZipCode { get; set; }
    }
}