using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Net.RestAPIAccess
{
    class RegisterAccess : WebAccessService
    {
        private class RegisterRequestData
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
        }

        public async Task<RegisterResponse> Post(string email, string password)
        {
            var data = new RegisterRequestData() { Email = email, Password = password, ConfirmPassword = password };
            var method = "Account/Register";
            return await this.Post<RegisterRequestData, RegisterResponse>(method, data);
        }
    }

    class RegisterResponse
    {
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "ModelState")]
        public ModelState ModelState { get; set; }
    }

    class ModelState
    {
        [JsonProperty(PropertyName = "model.Email")]
        public List<string> ModelEmail { get; set; }

        [JsonProperty(PropertyName = "model.Password")]
        public List<string> ModelPassword { get; set; }

        [JsonProperty(PropertyName = "model.NewPassword")]
        public List<string> ModelNewPassword { get; set; }
    }
}