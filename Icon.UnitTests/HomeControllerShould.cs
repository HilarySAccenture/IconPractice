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


    
    }
}