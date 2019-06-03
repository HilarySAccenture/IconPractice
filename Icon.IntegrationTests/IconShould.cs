using System;
using OpenQA.Selenium;
using Xunit;
using Shouldly;
using OpenQA.Selenium.Firefox;


namespace Icon.IntegrationTests
{
    public class IconShould
    {
        private string _fileName = GetGeckoDriverName();

        [Fact]
        public void DisplayExpectedText()
        {
            var driver = CreateWebDriver();

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
        
        private static string GetGeckoDriverName()
        {
            var remoteFileName = Environment.GetEnvironmentVariable("TravisWebDriver");
            var driverName = "geckodrivermac";

            if (remoteFileName == "TravisWebDriver")
            {
                driverName = remoteFileName;
            }

            return driverName; 
        }


        public FirefoxDriver CreateWebDriver()
        {
            var currentDirectory = Environment.CurrentDirectory;
            
            var services = FirefoxDriverService.CreateDefaultService(currentDirectory,
                _fileName);
            var driver = new FirefoxDriver(services);

            return driver;
        }
    }
}