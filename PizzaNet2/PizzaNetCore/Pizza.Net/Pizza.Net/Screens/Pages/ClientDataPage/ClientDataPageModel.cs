using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace Pizza.Net.Screens.Pages
{
    public interface IClientsPageModel
    {
    }
    class ClientDataPageModel : IDataErrorInfo, IClientsPageModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string PremiseNumber { get; set; }
        public string FlatNumber { get; set; }


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
                    case "FlatNumber":
                        validationResult = ValidateFlat();
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
        private string ValidateFlat()
        {
            if (String.IsNullOrEmpty(this.FlatNumber))
                return "Flat needs to be entered.";
            else
                return String.Empty;
        }
    }
}
