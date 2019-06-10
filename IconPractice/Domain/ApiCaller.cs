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
            _restClient = new RestClient("https://newsapi.org");
            _apiKey = Environment.GetEnvironmentVariable("CURRENT_API_KEY");
        }
        
        public string GetNewsAsJson()
        {
            var request = CreateRestRequest();

            var response = _restClient.Execute(request);
        
            return response.Content;
        }

        public RestRequest CreateRestRequest()
        {
            var request = new RestRequest("v2/top-headlines", Method.GET);
            request.AddParameter("country", "us");
            request.AddParameter("apiKey", _apiKey);

            return request;
        }
    }
}