using System;
using OpenQA.Selenium.Firefox;

namespace Icon.UnitTests
{
    public static class IconFireFoxDriver
    {
        public static FirefoxDriver CreateFireFoxDriver()
        {
            var currentDirectory = Environment.CurrentDirectory;
            const string FILE_NAME = "geckodrivermac";
            var services = FirefoxDriverService.CreateDefaultService(currentDirectory, FILE_NAME);
            var driver = new FirefoxDriver(services);
            return driver;
        }

    }
}