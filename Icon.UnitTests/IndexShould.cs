using System;
using OpenQA.Selenium.Firefox;
using Xunit;
using Shouldly;
using OpenQA.Selenium;

namespace Icon.UnitTests
{
    public class IndexShould
    {
        [Fact]
        public void DisplayExpectedText()
        {
            var currentDirectory = Environment.CurrentDirectory;
            var fileName = "geckodrivermac";
            var services = FirefoxDriverService.CreateDefaultService(currentDirectory, fileName);
            var driver = new FirefoxDriver(services);

            var result = string.Empty;
            
            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/");
                result = driver.FindElementByTagName("p").Text;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                driver.Quit();
            }
            result.ShouldContain("gattaca");
        }
    }
}