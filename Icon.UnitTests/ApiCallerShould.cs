using IconPractice.Domain;
using Xunit;
using Shouldly;
using NSubstitute;

namespace Icon.UnitTests
{
    public class ApiCallerShould
    {
        [Fact]
        public void Exist()
        {
            var caller = new ApiCaller();

            caller.ShouldNotBeNull();
        }
    }
}