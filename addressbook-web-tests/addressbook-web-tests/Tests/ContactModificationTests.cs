using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData changeContact = new ContactData("aaa", "aaaa", "aaa");
            changeContact.Middlename = "aaa";
            app.Contacts.Modify(1, changeContact);
            app.Auth.Logout();
        }
    }
}

