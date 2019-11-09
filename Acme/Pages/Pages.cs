using System;
using Acme.Selenium;

namespace Acme.Pages
{
    public class Pages
    {
        [ThreadStatic]
        public static LoginPage Login;

        [ThreadStatic]
        public static HomePage Home;

        public static void Init()
        {
            Login = new LoginPage();
            Home = new HomePage();
        }

        public static HomePage LoginTo(string username, string password)
        {
            Login.To(username, password);
            Driver.Wait.Until(drvr => Home.Map.UsernameLabel.Displayed);
            return Home;
        }
    }
}
