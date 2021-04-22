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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            //if (IsLoggedIn())
            //{
            //    if (IsLoggedIn(account))
            //    {
            //        return;
            //    }
            //    Logout();
            //}
            Type(By.Name("username"), account.Username);
            driver.FindElement(By.CssSelector("input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.CssSelector("input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click();
        }

        public void Logout()
        {
            //if (IsLoggedIn())
            //{
                driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/i[2]")).Click();
                driver.FindElement(By.XPath("//a[contains(@href, '/mantisbt-2.25.0/logout_page.php')]")).Click();
            //}
            //else
            //{
            //    manager.Navigator.OpenHomePage(); //после ввода неправильного пароля страница не грузится
            //}
        }

        //public bool IsLoggedIn()
        //{
        //    return IsElementPresent(By.CssSelector("input.user-info"));
        //}

        //public bool IsLoggedIn(AccountData account)
        //{
        //    return IsLoggedIn()
        //        && GetLoggedUserName() == account.Username;
        //}

        //public string GetLoggedUserName()
        //{
        //    string  text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
        //    return text.Substring(1, text.Length - 2);
        //    // == String.Format("(${0})", account.Username); //"(" + account.Username + ")"; 
        //}
    }
}
