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
        public void DisplayExpectedTextInParagraphTag()
        {
            var driver = CreateFireFoxDriver();

            var result = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/");
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

        [Fact]
        public void RenderAButton()
        {
            var driver = CreateFireFoxDriver();

            var buttonText = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/home/index");
                buttonText = driver.FindElementById("storyBtn").Text;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                driver.Quit();
            }

            buttonText.ShouldContain("get story");
        }
        
        [Fact]
        public void IncludeReferenceToApiSite()
        {
            var driver = CreateFireFoxDriver();
            var page = string.Empty;
            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/home/index");
                driver.FindElementById("api-link").Click();

                page = driver.Url;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                driver.Quit();
            }

            page.ShouldContain("currentsapi.services");
        }

        [Fact]
        public void ReturnAStoryView()
        {
            var driver = CreateFireFoxDriver();

            var page = string.Empty;
            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/home/index");
                driver.FindElementById("storyBtn").Click();

                page = driver.Url;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                driver.Quit();
            }

            page.ShouldContain("story");
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


        private FirefoxDriver CreateFireFoxDriver()
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