using Crowbar.Mvc.Common;
using NUnit.Framework;

namespace Crowbar.Tests.Web.Core
{
    public class CustomConfigTests : TestBase
    {
        [Test]
        public void Should_be_able_to_set_custom_configuration_file()
        {
            Application.Execute(browser =>
            {
                var response = browser.Get(CrowbarRoute.CustomConfig);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }
    }
}