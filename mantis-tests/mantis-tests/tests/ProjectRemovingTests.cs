using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests 
{
    [TestFixture]
    public class ProjectRemovingTests : TestBase
    {
        [TestFixtureSetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("administrator", "root"));
        }

        [Test]
        public void ProjectRemovingTest()
        {
            ProjectData toBeRemoved = ProjectData.GetAll()[0];
            app.Projects.Remove(toBeRemoved.Id);
        }

        //[TestFixtureTearDown]
        //public void restoreConfig()
        //{
        //    app.Ftp.RestoreBUFile("/Config/config_inc.php");
        //}
    }
}
