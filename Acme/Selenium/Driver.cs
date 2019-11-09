using System;
using System.Collections.Generic;
using System.IO;
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
        public static WebDriverWait _wait;

        public static void Init()
        {
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public static IWebDriver Current => _driver ?? throw new Exception("_driver is null.");

        public static WebDriverWait Wait => _wait;

        public static void Goto(string url)
        {
            Current.Url = url;
        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
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
