using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable =  app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void ContactInformationFromBadgeTest()
        {
            string fromBadge = app.Contacts.GetContactInformationFromBadge(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            string datafromForm = fromForm.Firstname + " " + fromForm.Middlename + " " + fromForm.Lastname + 
                "\r\n" + fromForm.Address + "\r\n\r\n" +
                fromForm.AllPhonesForBagde + "\r\n\r\n" + fromForm.AllEmails;
            Assert.AreEqual(fromBadge, datafromForm);
        }
    }
}

