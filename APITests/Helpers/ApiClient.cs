using RestSharp;
using System.Threading.Tasks;

namespace APITests.Helpers
{
    public class ApiClient
    {
        private readonly RestClient _client;
        public ApiClient(string baseUrl) => _client = new RestClient(baseUrl);

        public async Task<RestResponse> GetAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            request.AddHeader("x-api-key", "reqres-free-v1");
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> PostAsync(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddHeader("x-api-key", "reqres-free-v1");
            request.AddJsonBody(body);
            return await _client.ExecuteAsync(request);
        }
    }
}