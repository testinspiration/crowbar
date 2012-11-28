﻿using Crowbar.Mvc.Common;
using NUnit.Framework;

namespace Crowbar.Tests.Web.Core
{
    public class AntiForgeryRequestTokenTests : TestBase
    {
        [TestCase("DELETE")]
        [TestCase("POST")]
        [TestCase("PUT")]
        public void Should_be_able_to_perform_a_request_with_an_anti_forgery_token(string method)
        {
            Application.Execute(browser =>
            {
                var response = browser.PerformRequest(method, CrowbarRoute.AntiForgeryRequestToken, ctx => ctx.AntiForgeryRequestToken());
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }

        [TestCase("DELETE")]
        [TestCase("POST")]
        [TestCase("PUT")]
        public void Should_be_able_to_perform_a_request_with_an_anti_forgery_token_with_username(string method)
        {
            Application.Execute(browser =>
            {
                var response = browser.PerformRequest(method, CrowbarRoute.AntiForgeryRequestToken, ctx =>
                {
                    const string username = "crowbar";

                    ctx.FormsAuth(username);
                    ctx.AntiForgeryRequestToken(username);
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }
    }
}