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
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            AccountData account = new AccountData("administrator", "root");
            ProjectData project = new ProjectData("Test", "Description");
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            int oldProjectCount = projects.Length;
            app.Projects.Create(project);
            projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            int newProjectCount = projects.Length;
            Assert.AreEqual(oldProjectCount, newProjectCount - 1);
        }

        //[TestFixtureTearDown]
        //public void restoreConfig()
        //{
        //    app.Ftp.RestoreBUFile("/Config/config_inc.php");
        //}
    }
}
