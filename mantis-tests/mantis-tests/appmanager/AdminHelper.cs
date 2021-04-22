using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseUrl;

        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        //public List<AccData> GetAllAccounts()
        //{
        //    List<AccData> users = AccData.GetAll();
        //    //IWebDriver driver = OpenAppAndLogin();
        //    //driver.Url = baseUrl + "/manage_user_page.php";
        //    //return null;
        //    return users;
        //}

        public void DeleteAccount(AccData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.XPath("//input[@value='Delete User']")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Account']")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "/login_page.php";
            manager.Auth.Login(new AccountData("administrator", "root"));
            return driver;
        }
    }
}
