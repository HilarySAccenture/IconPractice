using System;
using Xunit;
using Shouldly;
using OpenQA.Selenium.Firefox;


namespace Icon.IntegrationTests
{
    public class IconShould
    {
        [Fact]
        public void DisplayExpectedText()
        {
            var currentDirectory = Environment.CurrentDirectory;
            var services = FirefoxDriverService.CreateDefaultService(currentDirectory, 
                "geckodrivermac");
            var driver = new FirefoxDriver(services);
            
            driver.Navigate().GoToUrl("http://localhost:5000/");

            var result = driver.FindElementByTagName("pre").Text;
            
            driver.Quit();
            
            result.ShouldContain("car");
            
        }
    }
}