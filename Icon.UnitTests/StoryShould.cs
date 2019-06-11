using System;
using OpenQA.Selenium.Firefox;
using Xunit;
using Shouldly;
using OpenQA.Selenium;

namespace Icon.UnitTests
{
    public class StoryShould
    {
        [Fact]
        public void DisplayReferenceToApi()
        {
            var driver = IconFireFoxDriver.CreateFireFoxDriver();

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

        [Fact]
        public void DisplayAnArticleTitle()
        {
            var driver = IconFireFoxDriver.CreateFireFoxDriver();

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

        [Fact(Skip = "skipped")]
        public void DisplayMultipleArticleTitlesIfMoreThanOneArticleReturned()
        {
            var driver = IconFireFoxDriver.CreateFireFoxDriver();
            
        }
    }
}