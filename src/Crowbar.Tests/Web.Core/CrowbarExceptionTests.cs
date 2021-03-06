﻿using System;
using Crowbar.Mvc.Common;
using NUnit.Framework;

namespace Crowbar.Tests.Web.Core
{
    public class CrowbarExceptionTests : TestBase
    {
        [Test]
        public void Should_be_able_to_handle_non_serializable_exceptions()
        {
            Application.Execute(browser =>
            {
                Assert.Throws<Exception>(() => browser.Post(CrowbarRoute.ExceptionNonSerializable));
            });
        }

        [Test]
        public void Should_be_able_to_handle_serializable_exceptions()
        {
            Application.Execute(browser =>
            {
                Assert.Throws<CrowbarException>(() => browser.Post(CrowbarRoute.ExceptionSerializable));
            });
        }
    }
}