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
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.Remove(toBeRemoved);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactRemovalFromMainFormTest()
        {
            app.Contacts.CreateIfEmpty();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.RemoveOtherMethod(toBeRemoved);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

