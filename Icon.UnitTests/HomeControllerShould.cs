using System;
using IconPractice.Controllers;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Firefox;
using Xunit;
using Shouldly;
using OpenQA.Selenium;

namespace Icon.UnitTests
{
    public class HomeControllerShould
    {
        [Fact]
        public void ReturnAnIndexView()
        {
            var controller = new HomeController();

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            //check name of view? 
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

    
    }
}