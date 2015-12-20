using System.Net.Http.Headers;

namespace Pizza.Net.RestAPIAccess
{
    class TokenAuthenticatedWebServiceAccess : WebAccessService
    {
        public TokenAuthenticatedWebServiceAccess(LoggedUser user)
        {
            this._httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", user.Token);
        }
    }
}