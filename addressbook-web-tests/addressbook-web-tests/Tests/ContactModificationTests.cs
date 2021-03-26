using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData changeContact = new ContactData("aaa", "aaaa", "aaa");
            changeContact.Middlename = "aaa";
            app.Contacts.CreateIfEmpty();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(1, changeContact);            
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = changeContact.Firstname;
            oldContacts[0].Lastname = changeContact.Lastname;
            oldContacts[0].Address = changeContact.Address;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

