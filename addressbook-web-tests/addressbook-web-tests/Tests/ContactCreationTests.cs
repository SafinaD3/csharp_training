using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30), GenerateRandomString(50))
                {
                    Middlename = GenerateRandomString(30)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        } 

        [Test]
        public void MainFieldsContactCreationTest()
        {
            ContactData contact = new ContactData("Surname", "Name", "Address 9");
            contact.Middlename = "r";

            contact.HomePhone = "123-45-67";
            contact.MobilePhone = "+8(912)3456789";
            contact.WorkPhone = "555-5-555";

            contact.Email = "test@test.ru";
            contact.Email2 = "test2@test.ru";
            contact.Email3 = "test3@test.ru";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.MainFieldsCreate(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

