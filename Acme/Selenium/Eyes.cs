using System;
using System.Drawing;
using OpenQA.Selenium;

namespace Acme.Selenium
{
    public class Eyes
    {
        readonly IWebDriver _driver;

        readonly Applitools.Selenium.Eyes _eyes;

        public Eyes(IWebDriver driver, string appName)
        {
            AppName = appName;
            _driver = driver;
            _eyes = new Applitools.Selenium.Eyes
            {
                ApiKey = Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY"),
                AppName = appName
            };
        }

        public string AppName { get; set; }

        public Applitools.Selenium.Eyes Current => _eyes;

        public IWebDriver Open(string testName, Size viewportSize)
        {
            return Current.Open(_driver, AppName, testName, viewportSize);
        }
    }
}
