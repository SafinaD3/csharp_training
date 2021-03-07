using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       [Test]
        public void GroupCreationTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin","secret"));
            navigator.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("q");
            group.Header = "q";
            group.Footer = "q";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            navigator.GoToGroupsPage();
            Logout();
        }
    }
}
