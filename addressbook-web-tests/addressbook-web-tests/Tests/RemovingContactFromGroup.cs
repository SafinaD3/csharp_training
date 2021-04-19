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
            GroupData group = GroupData.GetAllWithContacts()[0];
            if (group == null)
            {
                System.Console.Out.Write("Ни в одной группе нет контактов");
            }
            //находим первый контакт в этой группе
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.First();

            app.Contacts.RemoveContactfromGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
