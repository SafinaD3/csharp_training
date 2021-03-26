using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.CreateIfEmpty();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(0);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactRemovalFromMainFormTest()
        {
            app.Contacts.CreateIfEmpty();

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.RemoveOtherMethod(0);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

