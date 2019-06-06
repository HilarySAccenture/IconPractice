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
            var currentDirectory = Environment.CurrentDirectory;
            var fileName = "geckodrivermac";
            var services = FirefoxDriverService.CreateDefaultService(currentDirectory, fileName);
            var driver = new FirefoxDriver(services);

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
            var currentDirectory = Environment.CurrentDirectory;
            var fileName = "geckodrivermac";
            var services = FirefoxDriverService.CreateDefaultService(currentDirectory, fileName);
            var driver = new FirefoxDriver(services);

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
        
    }
}