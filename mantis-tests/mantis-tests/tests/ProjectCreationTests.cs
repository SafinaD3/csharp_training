using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

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

        [Test]
        public void ProjectCreationTestListFromDB()
        {
            ProjectData project = new ProjectData("Test", "Description");
            List<ProjectData> oldProjects = ProjectData.GetAll();
            ProjectData existingProject = oldProjects.Find(x => x.Name == project.Name);
            if (existingProject != null)
            {
                app.Projects.Remove(existingProject.Id);
            }
            oldProjects = ProjectData.GetAll();
            app.Projects.Create(project);
            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.Add(project);
            Assert.AreEqual(oldProjects.Capacity, newProjects.Capacity);
        }

        [Test]
        public void ProjectCreationTestArrayToList()
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            ProjectData project = new ProjectData("Test", "Description");
            AccountData account = new AccountData("administrator", "root");
            List<ProjectData> oldProjects = ProjectData.GetAll();
            ProjectData existingProject = oldProjects.Find(x => x.Name == project.Name);
            if (existingProject != null)
            {
                app.Projects.Remove(existingProject.Id);
            }
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            oldProjects = projects.OfType<ProjectData>().ToList();
            app.Projects.Create(project);

            oldProjects.Add(project);
            oldProjects.Sort();
            projects = client.mc_projects_get_user_accessible(account.Username, account.Password); //{mantis_tests.Mantis.ProjectData[1]}
            List<ProjectData> newProjects = projects.OfType<ProjectData>().ToList();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

        //[TestFixtureTearDown]
        //public void restoreConfig()
        //{
        //    app.Ftp.RestoreBUFile("/Config/config_inc.php");
        //}
    }
}
