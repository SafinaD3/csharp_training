using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }
        
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("15");
            //driver.FindElement(By.XPath("//option[@value='15']")).Click();
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("November");
            //driver.FindElement(By.XPath("//option[@value='November']")).Click();
            //driver.FindElement(By.Name("byear")).Clear();
            //driver.FindElement(By.Name("byear")).SendKeys("1");
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("15");
            //driver.FindElement(By.XPath("(//option[@value='15'])[2]")).Click();
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("November");
            //driver.FindElement(By.XPath("(//option[@value='November'])[2]")).Click();
            //driver.FindElement(By.Name("ayear")).Clear();
            //driver.FindElement(By.Name("ayear")).SendKeys("2");
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
