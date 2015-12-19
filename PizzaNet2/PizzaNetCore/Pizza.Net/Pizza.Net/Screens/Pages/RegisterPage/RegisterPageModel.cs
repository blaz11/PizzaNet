using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Pizza.Net.Screens.Pages
{
    class RegisterPageModel: IDataErrorInfo
    {
        public string Email { get; set; }


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
                    case "Email":
                        validationResult = validateEmail();
                        break;
                    default:
                        throw new ApplicationException("Unknown Property being validated on Product.");
                }
                return validationResult;
            }
        }

        private string validateEmail()
        {
            try
            {
                if (this.Email == null)
                    return "please provide an email";
                MailAddress m = new MailAddress(this.Email);

                return String.Empty; ;
            }
            catch (FormatException)
            {
                return "Not a proper email."; ;
            }
        }
    }
}
