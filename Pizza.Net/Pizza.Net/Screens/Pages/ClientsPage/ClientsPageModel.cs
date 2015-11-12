using Pizza.Net.Domain;
using System.ComponentModel;
using System;
using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pizza.Net.Screens.Pages
{
    interface IClientsPageModel
    {
        ClientsTableViewModel SearchClients();
        ObservableCollection<Order> ShowHistory(Client client);
        void Add();
    }

    class ClientsPageModel : IClientsPageModel, IDataErrorInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string PremiseNumber { get; set; }
        public string FlatNumber { get; set; }
        public ClientsTableViewModel SearchClients()
        {
            ClientsTableViewModel pom = new ClientsTableViewModel();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                Console.WriteLine(FirstName);
                var a = pne.Clients.Where(p =>
                (p.City == City || City == "" || City == null) &&
                (p.FirstName == FirstName || FirstName == "" || FirstName == null) &&
                (p.FlatNumber == FlatNumber || FlatNumber == "" || FlatNumber == null) &&
                (p.LastName == LastName || LastName == "" || LastName == null) &&
                (p.PhoneNumber == PhoneNumber || PhoneNumber == "" || PhoneNumber == null) &&
                (p.PremiseNumber == PremiseNumber || PremiseNumber == "" || PremiseNumber == null) &&
                (p.Street == Street || Street == "" || Street == null) &&
                (p.ZipCode == ZipCode || ZipCode == "" || ZipCode == null)
                );
                pom.Clients.Clear();
                foreach (var v in a)
                    pom.Clients.Add(v);
                return pom;
            }

        }
        public void Add()
        {
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                Client cl = new Client();
                cl.City = City;
                cl.FirstName = FirstName;
                cl.FlatNumber = FlatNumber;
                cl.LastName = LastName;
                cl.PhoneNumber = PhoneNumber;
                cl.PremiseNumber = PremiseNumber;
                cl.Street = Street;
                cl.ZipCode = ZipCode;
                pne.Clients.Add(cl);
                pne.SaveChanges();

            }
        }
        public void Edit(int id)
        {
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                
                var original = pne.Clients.Find(id);

                if (original != null)
                {
                    original.City = City;
                    original.FirstName = FirstName;
                    original.FlatNumber = FlatNumber;
                    original.LastName = LastName;
                    original.PhoneNumber = PhoneNumber;
                    original.PremiseNumber = PremiseNumber;
                    original.Street = Street;
                    original.ZipCode = ZipCode;
                    pne.SaveChanges();
                }
                
            }
        }
        public ObservableCollection<Order> ShowHistory(Client client)
        {
            
            var orders = new ObservableCollection<Order>();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                var a = pne.Orders.Where(p => p.Client.IDClient == client.IDClient);
                foreach (var v in a)
                    orders.Add(v);
            }
            return orders;
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string propertyName]
        {
            get
            {
                string validationResult = null;
                switch (propertyName)
                {
                    case ("FirstName"):
                        validationResult = ValidateFirstName();
                        break;
                    case "LastName":
                        validationResult = ValidatelastName();
                        break;
                    case "City":
                        validationResult = ValidateCity();
                        break;
                    case "ZipCode":
                        validationResult = ValidateZipCode();
                        break;
                    case "Street":
                        validationResult = ValidateStreet();
                        break;
                    case "PhoneNumber":
                        validationResult = ValidatePhone();
                        break;
                    case "PremiseNumber":
                        validationResult = ValidatePremise();
                        break;
                    default:
                        throw new ApplicationException("Unknown Property being validated on Product.");
                }
                return validationResult;
            }
        }

        private string ValidateFirstName()
        {
            if (String.IsNullOrEmpty(this.FirstName))
                return "Name needs to be entered.";
            else if (this.FirstName.Length < 2)
                return "Name should have more than 2 letters.";
            else
                return String.Empty;
        }

        private string ValidatelastName()
        {
            if (String.IsNullOrEmpty(this.LastName))
                return "Surname needs to be entered.";
            else if (this.LastName.Length < 2)
                return "Surname should have more than 2 letters.";
            else
                return String.Empty;
        }
        private string ValidateCity()
        {
            if (String.IsNullOrEmpty(this.City))
                return "City needs to be entered.";
            else if (this.City.Length < 2)
                return "City should have more than 2 letters.";
            else
                return String.Empty;
        }
        private string ValidateZipCode()
        {
            Regex regex = new Regex(@"^\d{2}-\d{3}$");
            if (String.IsNullOrEmpty(this.ZipCode))
                return "ZipCode needs to be entered.";
            else if (!regex.IsMatch(this.ZipCode))
                return "Bad format.";
            else
                return String.Empty;
        }
        private string ValidateStreet()
        {
            if (String.IsNullOrEmpty(this.Street))
                return "Street needs to be entered.";
            else if (this.Street.Length < 2)
                return "Street should have more than 2 letters.";
            else
                return String.Empty;
        }
        private string ValidatePhone()
        {
            Regex regex = new Regex(@"^\d{9}$");
            if (String.IsNullOrEmpty(this.PhoneNumber))
                return "Phone number needs to be entered.";
            else if (!regex.IsMatch(this.PhoneNumber))
                return "Phone number should have 9 digits.";
            else
                return String.Empty;
        }
        private string ValidatePremise()
        {
            if (String.IsNullOrEmpty(this.PremiseNumber))
                return "Premise needs to be entered.";
            else
                return String.Empty;
        }
    }
}