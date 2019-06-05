using System;
using System.Linq;
using IconPractice.Domain;
using Xunit;
using Shouldly;
using NSubstitute;
using RestSharp;

namespace Icon.UnitTests
{
    public class ApiCallerShould
    {
        [Fact]
        public void ReturnStringWhenGetArticlesAsJsonCalled()
        {
            
            var mockClient = Substitute.For<IRestClient>();
            var mockResponse = Substitute.For<IRestResponse>();
            mockResponse.Content.Returns("spartacus");
            mockClient.Execute(Arg.Any<IRestRequest>()).Returns(mockResponse);
            string apiKey = null;
            
            var caller = new ApiCaller(mockClient, apiKey);

            var response = caller.GetNewsAsJson();
            
            response.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void HaveNullApiKeyIfApiKeyIsNull()
        {
            var mockClient = Substitute.For<IRestClient>();
            string apiKey = null;
            
            var caller = new ApiCaller(mockClient, apiKey);

            var response = caller.GetNewsAsJson();

            var args = (RestRequest)mockClient.ReceivedCalls().First().GetArguments().First();
            Parameter requestApiKey = args.Parameters.FirstOrDefault(param => param.Name == "Authorization");
            
            requestApiKey.Value.ShouldBeNull();
        }
    }
}