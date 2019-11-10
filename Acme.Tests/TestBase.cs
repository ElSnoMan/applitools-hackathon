using Acme;
using Acme.Pages;
using Acme.Selenium;
using NUnit.Framework;

namespace Tests
{
    public abstract class TestBase
    {
        protected Applitools.BatchInfo batch;

        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.SetConfig();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            Driver.Init();
            Pages.Init();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            Driver.Quit();
            Driver.Eyes.Close();
            Driver.Eyes.Current.AbortIfNotClosed();
        }
    }
}
