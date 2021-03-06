﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        //private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }        
    }
}
