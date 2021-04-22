using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

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
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            AccountData account = new AccountData("administrator", "root");
            //List<ProjectData> projects = client.mc_projects_get_user_accessible(account.Username, account.Password)[] ;
            if(!ProjectData.GetAll().Any())
            {
                Mantis.ProjectData project = new Mantis.ProjectData();
                project.name = "Test";
                project.description = "Description";
                client.mc_project_add(account.Username, account.Password, project);
            }
            ProjectData toBeRemoved = ProjectData.GetAll()[0];

            app.Projects.Remove(toBeRemoved.Id);
        }
    }
}
