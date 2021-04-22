using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        private string baseURL;
        
        public ManagementMenuHelper(ApplicationManager manager, string baseURL) :base(manager)
        {
            this.baseURL = baseURL;
        }

        //public void OpenHomePage()
        //{
        //    driver.Navigate().GoToUrl(baseURL);
        //}

        public void GoToManagePage()
        {
            //if(driver.Url == baseURL)
            //{
            //    return;
            //}
            driver.FindElement(By.CssSelector("i.fa.fa-gears.menu-icon")).Click();
        }

        public void GoToProjectManagmentPage()
        {
            GoToManagePage();
            driver.FindElement(By.XPath("//a[contains(@href, '/mantisbt-2.25.0/manage_proj_page.php')]")).Click();
        }
    }
}
