using System;
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
            
            var _client = Substitute.For<IRestClient>();
            var _response = Substitute.For<IRestResponse>();
            _response.Content.Returns("spartacus");
            _client.Execute(Arg.Any<IRestRequest>()).Returns(_response);
            string apiKey = null;
            
            var caller = new ApiCaller(_client, apiKey);

            var response = caller.GetArticlesAsJson();
            
            response.ShouldNotBeNullOrEmpty();

        }
    }
}