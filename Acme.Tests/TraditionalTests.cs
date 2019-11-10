using System.Linq;
using NUnit.Framework;
using Acme.Pages;
using Acme.Selenium;
using Acme;

namespace Tests
{
    public class TraditionalTests : TestBase
    {
        [SetUp]
        public override void BeforeEach()
        {
            base.BeforeEach();
            Driver.Goto(FW.Config.Environment.V2);
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
            // Component or Visual test would be best here
            Pages.Login.Map.LoginButton.Click();
            Assert.That(Pages.Login.Map.Alert("Please enter both username and password").Displayed);
        }

        [Test]
        [Category("data-driven")]
        public void Only_username_shows_alert()
        {
            // V2: You could do some nasty workarounds, but this is an example where a Component/Visual tests are better
            Pages.Login.Map.UsernameField.SendKeys("username");
            Pages.Login.Map.LoginButton.Click();
            Assert.That(Pages.Login.Map.Alert("Password must be present").Displayed);
        }

        [Test]
        [Category("data-driven")]
        public void Only_password_shows_alert()
        {
            // V2: You could do some nasty workarounds, but this is an example where a Component/Visual tests are better
            Pages.Login.Map.PasswordField.SendKeys("password");
            Pages.Login.Map.LoginButton.Click();
            Assert.That(Pages.Login.Map.Alert("Username must be present").Displayed);
        }

        [Test]
        [Category("data-driven")]
        public void User_can_login()
        {
            // This is a narrow way to determine whether the user is logged in and viewing the right things
            Pages.Login.To("username", "password");
            Assert.That(Driver.Wait.Until(_ => Pages.Home.Map.UsernameLabel.Displayed));
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
            // This would be done via Visual Test and then in the hands of users (kinda implied for everything)
        }

        [Test, Ignore("Better control of data and programming design to make things deterministic")]
        [Category("dynamic")]
        public void Dynamic_Content_Test()
        {
            // This would be done via Visual Test
            // However, as a programmer or marketer, I would want better control of our data and campaigns
            // Layout Regions really helped with this
        }
    }
}
