using System.Collections.Generic;
using IconPractice.Domain;
using IconPractice.Domain.DataObject;
using Xunit;
using Shouldly;
using NSubstitute;

namespace Icon.UnitTests
{
    public class CurrentServiceShould
    {
        [Fact]
        public void ReturnDomainModelWithCorrectTitle()
        {
            var mockCaller = Substitute.For<IApiCaller>();
            var mockWrapper = Substitute.For<IApiWrapper>();

            var mockApiResponse = new ApiResponse {Title = "story telling"};
            mockWrapper.Convert(Arg.Any<string>()).Returns(new List<ApiResponse> {mockApiResponse});

            var service = new CurrentService(mockCaller, mockWrapper);

            var result = service.GetStory();

            result.Title.ShouldBe("story telling");
        }
    }
}