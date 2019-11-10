using NUnit.Framework;
using Acme.Pages;
using Acme.Selenium;
using Acme;

namespace Tests
{
    [TestFixture, Parallelizable(ParallelScope.Children)]
    public class VisualAiTests : TestBase
    {
        [OneTimeSetUp]
        public override void BeforeAll()
        {
            base.BeforeAll();
            batch = new Applitools.BatchInfo("Hackathon");
        }

        [SetUp]
        public override void BeforeEach()
        {
            base.BeforeEach();
            var testName = TestContext.CurrentContext.Test.Name;

            Driver.Eyes.Current.Batch = batch;
            Driver.Eyes.Open(testName);
        }

        [Test]
        [Category("login-page"), Category("login"), Category("visual")]
        public void LoginPage_UI_Elements_Test()
        {
            Driver.Goto(FW.Config.Environment.V2);
            Driver.Eyes.CheckWindow();
        }

        [Test]
        [Category("data-driven"), Category("login"), Category("visual")]
        public void No_username_or_password_shows_alert()
        {
            Driver.Goto(FW.Config.Environment.V2);
            Pages.Login.Map.LoginButton.Click();
            Driver.Eyes.CheckWindow();
        }

        [Test]
        [Category("data-driven"), Category("login"), Category("visual")]
        public void Only_username_shows_alert()
        {
            Driver.Goto(FW.Config.Environment.V2);
            Pages.Login.Map.UsernameField.SendKeys("username");
            Pages.Login.Map.LoginButton.Click();
            Driver.Eyes.CheckWindow();
        }

        [Test]
        [Category("data-driven"), Category("login"), Category("visual")]
        public void Only_password_shows_alert()
        {
            Driver.Goto(FW.Config.Environment.V2);
            Pages.Login.Map.PasswordField.SendKeys("password");
            Pages.Login.Map.LoginButton.Click();
            Driver.Eyes.CheckWindow();
        }

        [Test]
        [Category("data-driven"), Category("login"), Category("visual")]
        public void User_can_login()
        {
            Driver.Goto(FW.Config.Environment.V2);
            Pages.Login.To("username", "password");
            Driver.Wait.Until(_ => Pages.Home.Map.UsernameLabel.Displayed);
            Driver.Eyes.CheckWindow();
        }

        [Test]
        [Category("table-sort"), Category("visual")]
        public void User_can_sort_table_by_amount()
        {
            Driver.Goto(FW.Config.Environment.V2Home);
            Pages.Home.SortByAmount();
            Driver.Eyes.CheckWindow();
        }

        [Test]
        [Category("canvas"), Category("visual")]
        public void Canvas_Chart_Test()
        {
            Driver.Goto(FW.Config.Environment.V2Home);
            Pages.Home.Map.CompareExpensesLink.Click();
            Driver.Eyes.CheckWindow("default_chart");

            Pages.Home.Map.ShowDataForNextYearButton.Click();
            Driver.Eyes.CheckWindow("2019_chart_added");
        }

        [Test]
        [Category("dynamic"), Category("visual")]
        public void Dynamic_Content_Test()
        {
            Driver.Goto(FW.Config.Environment.V2Home + "?showAd=true");
            Driver.Eyes.CheckWindow();
        }
    }
}
