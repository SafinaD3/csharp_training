using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemovingContactFromGroupTest()
        {
            //проверка, что есть хотя бы один контакт добавленный в группу
            GroupData group = new GroupData();
            ContactData contact = new ContactData();
            if (!GroupData.GetAllWithContacts().Any()) //если нет ни одного контакта в группе
            {
                app.Groups.CreateIfEmpty(); //создаем группу если нет
                app.Contacts.CreateIfEmpty(); //создаем контакт если нет
                group = GroupData.GetAll()[0]; 
                contact = ContactData.GetAll()[0];
                app.Contacts.AddContactToGroup(contact, group); // контакт в группу
            }
            {
                group = GroupData.GetAllWithContacts()[0];
            }           
            List<ContactData> oldList = group.GetContacts();
            contact = oldList.First();
            app.Contacts.RemoveContactfromGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
