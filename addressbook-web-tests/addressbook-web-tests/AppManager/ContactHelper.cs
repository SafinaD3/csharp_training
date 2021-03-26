using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert = true;

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

        public ContactHelper Modify(int v, ContactData changeContact)
        {
            InitContactModification(v);
            FillContactForm(changeContact);
            ConfirmModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            InitContactModification(v);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }
        
        public ContactHelper RemoveOtherMethod(int v)
        {
            SelectContact(v);
            RemoveContact();
            ConfirmRemoving();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper ConfirmRemoving()
        {
            acceptNextAlert = true;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("address"), contact.Address);
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

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public bool IsNotEmptyContactList()
        {
            return IsElementPresent(By.XPath("//img[@alt='Details']"));
        }

        public void CreateIfEmpty()
        {
            if (!IsNotEmptyContactList())
            {
                ContactData contact = new ContactData("w", "q", "e");
                contact.Middlename = "r";
                Create(contact);
            }
        }
        
        public ContactHelper ConfirmModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        internal List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            
            foreach (IWebElement element in elements)
            {
                string nameandcontact = element.Text;
                string[] contactdata = nameandcontact.Split(' ');
                contacts.Add(new ContactData(contactdata[0], contactdata[1], contactdata[2]));
            }
            return contacts;
        }
    }
}
