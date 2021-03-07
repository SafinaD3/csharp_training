﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("w", "q", "e");
            contact.Middlename = "r";
            FillContactForm(contact);
            SubmitContactCreation();
            navigator.GoToHomePage();
            Logout();
        }
    }
}

