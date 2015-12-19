using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Pizza.Net.RestAPIAccess
{
    class TokenProvider
    {
        public static TokenRequestResult GetToken(string username, string password)
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(5);
            client.BaseAddress = new Uri("http://localhost:54432/token");
            HttpResponseMessage response =
                client.PostAsync("Token",
                    new StringContent(string.Format("grant_type=password&username={0}&password={1}",
                    HttpUtility.UrlEncode(username),
                    HttpUtility.UrlEncode(password)), Encoding.UTF8,
                    "application/x-www-form-urlencoded")).Result;
            string resultJSON = response.Content.ReadAsStringAsync().Result;
            TokenRequestResult result = JsonConvert.DeserializeObject<TokenRequestResult>(resultJSON);
            return result;
        }

        public class TokenRequestResult
        {
            public override string ToString()
            {
                return AccessToken;
            }

            [JsonProperty(PropertyName = "access_token")]
            public string AccessToken { get; set; }

            [JsonProperty(PropertyName = "error")]
            public string Error { get; set; }

            [JsonProperty(PropertyName = "error_description")]
            public string ErrorDescription { get; set; }
        }
    }
}