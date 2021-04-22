using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests 
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("administrator", "root"));
        }

        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData("Test", "Description");
            app.Projects.Create(project);
        }

        //[TestFixtureTearDown]
        //public void restoreConfig()
        //{
        //    app.Ftp.RestoreBUFile("/Config/config_inc.php");
        //}
    }
}
