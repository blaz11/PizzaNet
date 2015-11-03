using System.Windows.Input;
using Pizza.Net.Domain;

namespace Pizza.Net.Screens.Pages
{
    interface IClientsPageViewModel : IPageViewModel
    {
        ICommand AddNewClientCommand { get; }
        string City { get; set; }
        ICommand ClearCommand { get; }
        ICommand EditClientCommand { get; }
        string FirstName { get; set; }
        uint? FlatNumber { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        uint? PremiseNumber { get; set; }
        ICommand SearchClientsCommand { get; }
        Client SelectedClient { get; }
        string Street { get; set; }
        string ZipCode { get; set; }
    }
}