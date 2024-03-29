﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager):base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper Modify(GroupData group, GroupData newData)
        {
            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this; 
        }

        public GroupHelper Remove(int p)
        {
            SelectGroup(p);
            RemoveGroup();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            SelectGroup(group.Id);
            RemoveGroup();
            manager.Navigator.GoToGroupsPage();
            return this;
        }
        
        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public bool IsNotEmptyGrouptList()
        {
            return IsElementPresent(By.XPath("//input[@name='selected[]']"));
        }
        
        public void CreateIfEmpty()
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsNotEmptyGrouptList())
            {
                GroupData group = new GroupData("q");
                group.Header = "q";
                group.Footer = "q";
                Create(group);
            }
        }

        public void Create()
        {
            manager.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("q");
            group.Header = "q";
            group.Footer = "q";
            Create(group);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text){
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                //foreach (IWebElement element in elements)
                //{
                //    groupCache.Add(new GroupData(null)
                //    {
                //        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                //    });
                //}
                //string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                //string[] parts = allGroupNames.Split('\n');
                //int shift = groupCache.Count - parts.Length;
                //for (int i = 0; i < groupCache.Count; i++)
                //{
                //    if (i < shift)
                //    {
                //        groupCache[i].Name = "";
                //    }
                //    else
                //    {
                //        groupCache[i].Name = parts[i- shift].Trim();
                //    }
                //}
            }
            return new List<GroupData>(groupCache);
        }
    }
}
