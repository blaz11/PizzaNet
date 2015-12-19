using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pizza.Net.RestAPIAccess
{
    class ChangePasswordAccess : WebAccessService
    {
        private class ChangePasswordRequestData
        {
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
            public string ConfirmPassword { get; set; }
        }

        public ChangePasswordAccess()
        {
            this._httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", UserSingleton.Token);
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
        public ModelState ModelState { get; set; }
    }
}
