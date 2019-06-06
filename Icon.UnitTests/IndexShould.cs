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
        public void DisplayExpectedTextInParagraphTag()
        {
            var driver = CreateFireFoxDriver();

            var result = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/home/index");
                result = driver.FindElementById("indexGreeting").Text;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                driver.Quit();
            }

            result.ShouldContain("welcome");
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

        private static FirefoxDriver CreateFireFoxDriver()
        {
            var currentDirectory = Environment.CurrentDirectory;
            const string FILE_NAME = "geckodrivermac";
            var services = FirefoxDriverService.CreateDefaultService(currentDirectory, FILE_NAME);
            var driver = new FirefoxDriver(services);
            return driver;
        }
    }
}