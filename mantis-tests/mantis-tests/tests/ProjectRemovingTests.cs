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
            if(!ProjectData.GetAll().Any())
            {
                Mantis.ProjectData project = new Mantis.ProjectData();
                project.name = "Test";
                project.description = "Description";
                client.mc_project_add(account.Username, account.Password, project);
            }
            ProjectData toBeRemoved = ProjectData.GetAll()[0];
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            int oldProjectCount = projects.Length;
            app.Projects.Remove(toBeRemoved.Id);
            projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            int newProjectCount = projects.Length;
            Assert.AreEqual(oldProjectCount, newProjectCount + 1);
        }

        [Test]
        public void ProjectRemovingTestListFromDB()
        {
            AccountData account = new AccountData("administrator", "root");
            if (!ProjectData.GetAll().Any())
            {
                ProjectData project = new ProjectData("Test", "Description");
                app.Projects.Create(project);
            }
            ProjectData toBeRemoved = ProjectData.GetAll()[0];
            List<ProjectData> oldProjects = ProjectData.GetAll();
            app.Projects.Remove(toBeRemoved.Id);
            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void ProjectRemovingTestArrayToList()
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            AccountData account = new AccountData("administrator", "root");
            if (!ProjectData.GetAll().Any())
            {
                Mantis.ProjectData project = new Mantis.ProjectData();
                project.name = "Test";
                project.description = "Description";
                client.mc_project_add(account.Username, account.Password, project);
            }
            ProjectData toBeRemoved = ProjectData.GetAll()[0];
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            List<ProjectData> oldProjects = projects.OfType<ProjectData>().ToList();
            app.Projects.Remove(toBeRemoved.Id);
            projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            List<ProjectData> newProjects = projects.OfType<ProjectData>().ToList();
            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);
        }


    }
}
