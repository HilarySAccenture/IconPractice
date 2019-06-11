using System;
using OpenQA.Selenium.Firefox;
using Xunit;
using Shouldly;
using OpenQA.Selenium;

namespace Icon.UnitTests
{
    public class IndexShould
    {
        
        
        
        [Fact(Skip = "skip")]
        public void DisplayExpectedTextInParagraphTag()
        {
            var driver = IconFireFoxDriver.CreateFireFoxDriver();

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

        [Fact(Skip = "skip")]
        public void RenderAButton()
        {
            var driver = IconFireFoxDriver.CreateFireFoxDriver();

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

        [Fact(Skip = "skip")]
        public void ReturnAStoryView()
        {
            var driver = IconFireFoxDriver.CreateFireFoxDriver();

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

        [Fact(Skip = "skip")]
        public void IncludeReferenceToApiSite()
        {
            var driver = IconFireFoxDriver.CreateFireFoxDriver();
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
        
    }
}