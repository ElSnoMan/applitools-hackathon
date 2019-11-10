using System;
using OpenQA.Selenium;

namespace Acme.Selenium
{
    public class Eyes
    {
        readonly IWebDriver _driver;

        readonly Applitools.Selenium.Eyes _eyes;

        public Eyes(IWebDriver driver, string appName)
        {
            ApiKey = Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY");
            AppName = appName;
            _driver = driver;
            _eyes = new Applitools.Selenium.Eyes
            {
                ApiKey = this.ApiKey,
                AppName = this.AppName
            };
        }

        public string ApiKey { get; set; }

        public string AppName { get; set; }

        public Applitools.Selenium.Eyes Current => _eyes;

        public IWebDriver Open(string testName)
        {
            return Current.Open(_driver, AppName, testName);
        }

        public void CheckWindow(string tag = null, bool? fully = null)
        {
            Current.CheckWindow(tag, fully);
        }

        public Applitools.TestResults Close()
        {
            return Current.Close();
        }
    }
}
