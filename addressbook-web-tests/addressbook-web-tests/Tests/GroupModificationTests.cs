using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModofocationTest()
        {
            GroupData newData = new GroupData("z");
            newData.Header = "z";
            newData.Footer = "z";
            app.Groups.Modify(1, newData);
        }
    }
}
