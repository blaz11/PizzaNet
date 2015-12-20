using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace PizzaNetWebAPI.Email
{
    public class EmailSender
    {
        private const string EMAIL_ADDRESS = "pizzadotnet2015@gmail.com";
        private const string EMAIL_PASSWORD = "Test1234!";

        private MailAddress _fromAddress;

        public EmailSender()
        {
            _fromAddress = new MailAddress(EMAIL_ADDRESS);
            _smpt = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromAddress.Address, EMAIL_PASSWORD)
            };
        }

        private SmtpClient _smpt;

        public async Task SendEmail(string to, EmailCreator creator)
        {
            var toAdress = new MailAddress(to);
            using (var message = new MailMessage(_fromAddress, toAdress)
            {
                Subject = creator.GetSubject(),
                Body = creator.GetBody()
            })
            {
                _smpt.Send(message);
            }
        }
    }
}