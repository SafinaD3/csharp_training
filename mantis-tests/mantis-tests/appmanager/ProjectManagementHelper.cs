using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Navigator.GoToProjectManagmentPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            manager.Navigator.GoToManagePage();
            return this; 
        }

        public ProjectManagementHelper Remove(string p)
        {
            manager.Navigator.GoToProjectManagmentPage();
            SelectProjectForRemoving(p);
            InitProjectRemoving();
            ConfirmProjectRemoving();
            manager.Navigator.GoToManagePage();
            return this;
        }

        public ProjectManagementHelper ConfirmProjectRemoving()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            return this;
        }

        public ProjectManagementHelper InitProjectRemoving()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm.btn-white.btn-round")).Click();
            return this;
        }

        public ProjectManagementHelper SelectProjectForRemoving(string p)
        {
            driver.FindElement(By.XPath("//a[contains(@href, 'manage_proj_edit_page.php?project_id=" + p + "')]")).Click();
            return this;
        }

        public ProjectManagementHelper InitProjectCreation()
        {
            driver.FindElement(By.CssSelector("button.btn.btn-primary.btn-white.btn-round")).Click();
            return this;
        }

        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            Type(By.Id("project-description"), project.Description);
            return this;
        }

        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            //projectCache = null;
            return this;
        }
        


    }
}
