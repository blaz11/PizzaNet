﻿using Pizza.Net.Domain;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface IClientsTableViewModel
    {
        ObservableCollection<Client> Clients { get; set; }
        Client SelectedClient { get; set; }
        void ClientEditingFinished(Client client);
    }

    class ClientsTableViewModel : ObservableObject, IClientsTableViewModel
    {
        public ClientsTableViewModel()
        {
            //remove
            
            Clients.Add(new Client()
            {
       //         FirstName = "Dariusz",
       //         LastName = "Maciejewski"
            });
        }

        private ObservableCollection<Client> _clients = new ObservableCollection<Client>();
        public ObservableCollection<Client> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                if (value != _clients)
                {
                    _clients = value;
                    OnPropertyChanged();
                }
            }
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get
            {
                return _selectedClient;
            }
            set
            {
                if (value != _selectedClient)
                {
                    _selectedClient = value;
                    OnPropertyChanged();
                }
            }
        }

        public void ClientEditingFinished(Client client)
        {

        }
    }
}