using Acme.Selenium;
using OpenQA.Selenium;

namespace Acme.Pages
{
    public class LoginPage
    {
        public readonly LoginPageMap Map;

        public LoginPage()
        {
            Map = new LoginPageMap();
        }

        public void To(string username, string password)
        {
            Map.UsernameField.SendKeys(username);
            Map.PasswordField.SendKeys(password);
            Map.LoginButton.Click();
        }
    }

    public class LoginPageMap
    {
        public IWebElement Alert(string text) => Driver.FindElement(By.XPath($"//*[@role='alert' and text()='{text}']"));

        public IWebElement UsernameField => Driver.FindElement(By.Id("username"));

        public IWebElement PasswordField => Driver.FindElement(By.Id("password"));

        public IWebElement LoginButton => Driver.FindElement(By.Id("log-in"));
    }
}
