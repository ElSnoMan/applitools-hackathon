using System.Linq;
using NUnit.Framework;
using Acme.Pages;
using Acme.Selenium;

namespace Tests
{
    public class TraditionalTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            Pages.Init();
            Driver.Goto("https://demo.applitools.com/hackathonV2.html");
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Quit();
        }

        [Test, Ignore("Best done by Visual")]
        [Category("login-page")]
        public void LoginPage_UI_Elements_Test()
        {
            // Functional test isn't the best here. Visual option is much better
        }

        [Test]
        [Category("data-driven")]
        public void No_username_or_password_shows_alert()
        {
            // Component test would be best here
            Pages.Login.Map.LoginButton.Click();
            Assert.That(Pages.Login.Map.Alert("Please enter both username and password").Displayed);
        }

        [Test]
        [Category("data-driven")]
        public void Only_username_shows_alert()
        {
            // Component test would be best here
            // V2: You could do some nasty workarounds, but this is an example where a Component/Visual tests are better
            Pages.Login.Map.LoginButton.Click();
            Assert.That(Pages.Login.Map.Alert("Password must be present").Displayed);
        }

        [Test]
        [Category("data-driven")]
        public void Only_password_shows_alert()
        {
            // Component test would be best here
            // V2: You could do some nasty workarounds, but this is an example where a Component/Visual tests are better
            Pages.Login.Map.LoginButton.Click();
            Assert.That(Pages.Login.Map.Alert("Username must be present").Displayed);
        }

        [Test]
        [Category("data-driven")]
        public void User_can_login()
        {
            Pages.Login.To("username", "password");
            Assert.That(Driver.Wait.Until(drvr => Pages.Home.Map.UsernameLabel.Displayed));
        }

        [Test]
        [Category("table-sort")]
        public void User_can_sort_table_by_amount()
        {
            Pages.LoginTo("username", "password");
            var transactions = Pages.Home.Map.RecentTransactions;

            Pages.Home.SortByAmount();
            var sortedTransactions = Pages.Home.Map.RecentTransactions;

            var orderedTransactions = transactions.OrderBy(transaction => transaction.Amount).ToList();

            // assert table was sorted by ascending order
            // assert rows' values persisted
            Assert.AreEqual(expected: orderedTransactions, actual: sortedTransactions);
        }

        [Test, Ignore("Best done by Visual or Human")]
        [Category("canvas")]
        public void Canvas_Chart_Test()
        {
            // This would be done via Visual Test or, in my opinion, in the hands of users
        }

        [Test, Ignore("Better control of data and programming design to make things deterministic")]
        [Category("dynamic")]
        public void Dynamic_Content_Test()
        {
            // This would be done via Visual Test
            // However, as a programmer or marketer, I would want better control of our data and campaigns
        }
    }
}
