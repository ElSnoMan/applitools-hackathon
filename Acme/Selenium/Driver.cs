using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Acme.Selenium
{
    public class Driver
    {
        [ThreadStatic]
        public static IWebDriver _driver;

        [ThreadStatic]
        public static Eyes _eyes;

        [ThreadStatic]
        public static WebDriverWait _wait;

        public static void Init()
        {
            _driver = new ChromeDriver(FW.WORKSPACE_DIRECTORY + "_drivers");
            _eyes = new Eyes(_driver, FW.Config.Applitools.AppName);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(FW.Config.Driver.WaitSeconds));
        }

        public static IWebDriver Current => _driver ?? throw new Exception("_driver is null.");

        public static Eyes Eyes => _eyes;

        public static WebDriverWait Wait => _wait;

        public static void Goto(string url)
        {
            Current.Url = url;
        }

        public static IWebElement FindElement(By by)
        {
            return Wait.Until(drvr => drvr.FindElement(by));
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public static void Quit()
        {
            Current.Quit();
        }
    }
}
