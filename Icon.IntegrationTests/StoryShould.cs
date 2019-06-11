using System;
using OpenQA.Selenium.Firefox;
using Shouldly;
using Xunit;

namespace Icon.IntegrationTests
{
    public class StoryShould
    {
        private readonly string _fileName = GetGeckoDriverName();
        
        [Fact(Skip = "skip")]
        public void DisplayReferenceToApi()
        {
            var driver = CreateWebDriver();

            var result = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/story/getstory");
                driver.FindElementById("api-link").Click();

                result = driver.Url;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                driver.Quit();
            }

            result.ShouldContain("currentsapi.services");
        }

        [Fact(Skip = "skip")]
        public void DisplayAnArticleTitle()
        {
            var driver = CreateWebDriver();

            var result = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/story/getstory");
                result = driver.FindElementById("title").Text;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                {
                    driver.Quit();
                }
            }

            result.ShouldNotBeNullOrEmpty();
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