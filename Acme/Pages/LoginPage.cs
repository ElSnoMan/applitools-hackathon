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
        public IWebElement BigLogo => Driver.FindElement(By.CssSelector("a img[src*='logo-big']"));

        public IWebElement LoginFormLabel => Driver.FindElement(By.XPath("//h4[contains(text(), 'Login Form')]"));

        public IWebElement Alert(string text) => Driver.FindElement(By.XPath($"//*[@role='alert' and text()='{text}']"));

        public IWebElement UsernameField => Driver.FindElement(By.Id("username"));

        public IWebElement PasswordField => Driver.FindElement(By.Id("password"));

        public IWebElement LoginButton => Driver.FindElement(By.Id("log-in"));

        public IWebElement RememberMeCheckbox => Driver.FindElement(By.CssSelector("input.form-check-input"));

        public IWebElement TwitterIcon => Driver.FindElement(By.CssSelector("a img[src*='twitter']"));

        public IWebElement FacebookIcon => Driver.FindElement(By.CssSelector("a img[src*='facebook']"));

        public IWebElement LinkedInIcon => Driver.FindElement(By.CssSelector("a img[src*='linkedin']"));
    }
}
