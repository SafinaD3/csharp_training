﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(1);
            app.Auth.Logout();
        }

        [Test]
        public void ContactRemovalFromMainFormTest()
        {
            app.Contacts.RemoveOtherMethod(1);
            app.Auth.Logout();
        }
    }
}

