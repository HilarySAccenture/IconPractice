using System;
using RestSharp;

namespace IconPractice.Domain
{
    public class ApiCaller : IApiCaller
    {
        private IRestClient _restClient;
        private string _apiKey;

        public ApiCaller(IRestClient restClient, string apiKey)
        {
            _restClient = restClient;
            _apiKey = apiKey;
        }

        public ApiCaller()
        {
            _restClient = new RestClient("https://api.currentsapi.services/v1/");
            _apiKey = Environment.GetEnvironmentVariable("CURRENT_API_KEY");
        }
        
        public string GetArticlesAsJson()
        {
            var request = CreateRestRequest();

            var response = _restClient.Execute(request);

            return response.Content;
        }

        private RestRequest CreateRestRequest()
        {
            var request = new RestRequest("latest-news", Method.GET);
            request.AddHeader("Authorization", _apiKey);

            return request;
        }
    }
}