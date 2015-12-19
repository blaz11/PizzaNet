using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace Pizza.Net.RestAPIAccess
{
    public abstract class WebAccessService
    {
        private const string ADDRESS = "http://localhost:54432/api/";

        public readonly HttpClient _httpClient;
        private readonly MediaTypeFormatter _formatter;

        protected WebAccessService()
        {
            _httpClient = HttpClientFactory.Create();
            _formatter = new JsonMediaTypeFormatter();
            _httpClient.BaseAddress =
                new Uri(ADDRESS);
            _httpClient.Timeout = TimeSpan.FromSeconds(5);
        }

        protected async Task<TResponse> Delete<TRequest, TResponse>(string uri)
        {
            return await ExtractResponse<TResponse>(await _httpClient.DeleteAsync(uri));
        }

        protected async Task<TResponse> Put<TRequest, TResponse>(string method, TRequest request)
        {
            return await ExtractResponse<TResponse>(await _httpClient.PutAsync(method, request, _formatter));
        }

        protected async Task<TResponse> Post<TRequest, TResponse>(string method, TRequest request)
        {
            return await ExtractResponse<TResponse>(await _httpClient.PostAsync(method, request, _formatter));
        }

        protected async Task<TResponse> Get<TResponse>(string uri)
        {
            return await ExtractResponse<TResponse>(await _httpClient.GetAsync(uri));
        }

        private async Task<TResponse> ExtractResponse<TResponse>(HttpResponseMessage response)
        {
            return await response.Content.ReadAsAsync<TResponse>(new[] { _formatter });
        }
    }
}