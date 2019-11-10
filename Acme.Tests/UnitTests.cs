using System;
using Acme;
using NUnit.Framework;

namespace Tests
{
    public class UnitTests
    {
        [Test]
        [Category("unit")]
        public void Applitools_api_key_is_not_null()
        {
            var key = Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY");
            Assert.IsNotNull(key);
        }

        [Test]
        [Category("unit")]
        public void Configuration_is_not_null()
        {
            FW.SetConfig();
            Assert.IsNotNull(FW.Config.Applitools);
            Assert.IsNotNull(FW.Config.Driver);
            Assert.IsNotNull(FW.Config.Environment);
        }
    }
}
