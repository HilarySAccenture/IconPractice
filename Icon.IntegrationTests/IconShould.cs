using System;
using OpenQA.Selenium;
using Xunit;
using Shouldly;
using OpenQA.Selenium.Firefox;


namespace Icon.IntegrationTests
{
    public class IconShould
    {
        private readonly string _fileName = GetGeckoDriverName();

        [Fact]
        public void DisplayExpectedText()
        {
            var driver = CreateWebDriver();

            var result = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:8000/");
                result = driver.FindElementByTagName("p").Text;
            }
            catch (WebDriverException ex)
            {
            }
            finally
            {
                driver.Quit();
            }

            result.ShouldContain("Welcome");
        }

        private static string GetGeckoDriverName()
        {
            var remoteFileName = Environment.GetEnvironmentVariable("TravisWebDriver");
            var driverName = "geckodrivermac";

            if (remoteFileName != null)
            {
                driverName = remoteFileName;
            }

            return driverName; 
        }


        private FirefoxDriver CreateWebDriver()
        {
            var currentDirectory = Environment.CurrentDirectory;
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            var services = FirefoxDriverService.CreateDefaultService(currentDirectory,
                _fileName);
            var driver = new FirefoxDriver(services, options);

            return driver;
        }
    }
}