using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using IconPractice.Controllers;
using IconPractice.Domain;
using IconPractice.Domain.DataObject;
using IconPractice.Domain.Models;
using IconPractice.Models;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Firefox;
using Xunit;
using Shouldly;
using OpenQA.Selenium;
using NSubstitute;
using RestSharp;

namespace Icon.UnitTests
{
    public class StoryShould
    {
        [Fact]
        public void ReturnsAStoryViewModelWithCorrectTitle()
        {
            var mockService = Substitute.For<ICurrentService>();
            var controller = new StoryController(mockService);
            var storyModel = mockService.GetStory().Returns(new StoryDomainModel {Title = "test"});

            var result = controller.GetStory();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<StoryViewModel>(viewResult.ViewData.Model);
            Assert.Equal("test", model.Title);
        }


        [Fact(Skip = "skip")]
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

        [Fact(Skip = "skip")]
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
    }
}