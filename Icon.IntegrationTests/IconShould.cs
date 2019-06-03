using System;
using OpenQA.Selenium;
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
            var result = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:8000/");
                result = driver.FindElementByTagName("pre").Text;
            }
            catch (WebDriverException ex)
            {
            }
            finally
            {
                driver.Quit();
            }

            result.ShouldContain("Hello World");
        }
    }
}