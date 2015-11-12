using Pizza.Net.Domain;
using System.ComponentModel;
using System;
using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;

namespace Pizza.Net.Screens.Pages
{
    interface IClientsPageModel
    {
        ClientsTableViewModel SearchClients();
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
                    case "FirstName":
                        validationResult = ValidateFirstName();
                        break;
                    case "LastName":
                        validationResult = ValidatelastName();
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
    }
}