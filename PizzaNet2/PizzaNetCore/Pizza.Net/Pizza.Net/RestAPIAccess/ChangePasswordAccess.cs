using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pizza.Net.RestAPIAccess
{
    class ChangePasswordAccess : TokenAuthenticatedWebServiceAccess
    {
        private class ChangePasswordRequestData
        {
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
            public string ConfirmPassword { get; set; }
        }

        public ChangePasswordAccess(LoggedUser user): base(user)
        {
        }

        public async Task<ChangePasswordResponse> Post(string oldPassword, string newPassword)
        {
            var data = new ChangePasswordRequestData()
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = newPassword
            };
            var method = "Account/ChangePassword";
            return await this.Post<ChangePasswordRequestData, ChangePasswordResponse>(method, data);
        }
    }

    class ChangePasswordResponse
    {
        public string Message { get; set; }
        public ModelStatePassword ModelState { get; set; }
    }

    class ModelStatePassword
    {
        [JsonProperty(PropertyName = "model.Password")]
        public List<string> ModelPassword { get; set; }

        [JsonProperty(PropertyName = "model.NewPassword")]
        public List<string> ModelNewPassword { get; set; }
    }
}
