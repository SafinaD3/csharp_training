using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };
            app.Groups.Remove(1);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(1);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
