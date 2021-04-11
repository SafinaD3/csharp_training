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
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];
            app.Contacts.Modify(oldData, changeContact);            
            List<ContactData> newContacts = ContactData.GetAll();
            oldData.Firstname = changeContact.Firstname;
            oldData.Lastname = changeContact.Lastname;
            oldData.Address = changeContact.Address;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

