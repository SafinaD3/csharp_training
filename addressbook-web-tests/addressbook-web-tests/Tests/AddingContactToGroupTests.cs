using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            //находим группу без контактов, если нет - создаем новую

            List<GroupData> allGroupsWithContacts = GroupData.GetAllWithContacts();
            GroupData group = new GroupData();
            if (GroupData.GetAll().Except(allGroupsWithContacts).Any())
            {
                group = GroupData.GetAll().Except(allGroupsWithContacts).First();
            }
            {
                app.Groups.Create();
                app.Navigator.GoToHomePage();
                group = GroupData.GetAll().Except(allGroupsWithContacts).First();
            }

            //находим контакт без группы
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
