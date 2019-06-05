using System.Collections.Generic;
using System.Linq;
using IconPractice.DataObject;
using IconPractice.Domain;
using IconPractice.Domain.DataObject;
using Xunit;
using Shouldly;

namespace Icon.UnitTests
{
    public class ApiWrapperShould
    {
        [Fact]
        public void ReturnStatusOkJsonStringAsCSharpString()
        {
            var wrapper = new ApiWrapper();
            var jsonString = @"{""status"":""ok"",""news"":[{""id"":""f95ea2a0-3d17-45c0-9c89-b0c98d36998f"",""title"":""Sophie Turner Has a Surprising Way to Cope With This Totally Rational Greatest Fear"",""description"":""Sophie Turner has come up against some of the most horrid villains in cinematic history \u2014 cough cough, Joffrey and Ramsay \u2014 but her greatest fear apparently has nothing to do with humanity's poten..."",""url"":""https:\/\/time.com\/5601221\/sophie-turner-jimmy-kimmel-greatest-fear\/"",""author"":""Megan McCluskey"",""image"":""None"",""language"":""en"",""category"":[""general""],""published"":""2019-06-05 15:54:56 +0000""}]}";
            
            wrapper.Convert(jsonString).ShouldBeOfType<List<ApiResponse>>();
        }

        [Fact]
        public void ReturnTitleOfJsonResponse()
        {
            var wrapper = new ApiWrapper();
            
            var jsonString = @"{""status"":""ok"",""news"":[{""id"":""f95ea2a0-3d17-45c0-9c89-b0c98d36998f"",""title"":""Sophie Turner Has a Surprising Way to Cope With This Totally Rational Greatest Fear"",""description"":""Sophie Turner has come up against some of the most horrid villains in cinematic history \u2014 cough cough, Joffrey and Ramsay \u2014 but her greatest fear apparently has nothing to do with humanity's poten..."",""url"":""https:\/\/time.com\/5601221\/sophie-turner-jimmy-kimmel-greatest-fear\/"",""author"":""Megan McCluskey"",""image"":""None"",""language"":""en"",""category"":[""general""],""published"":""2019-06-05 15:54:56 +0000""}]}";

            var list = wrapper.Convert(jsonString);
            
           list.First().Title.ShouldContain("Sophie Turner Has a Surprising Way");
        }
        
        
    }
}