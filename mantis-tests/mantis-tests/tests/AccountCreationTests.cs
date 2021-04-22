using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests 
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void setUpConfig()
        {
            app.Ftp.BUFile("/Config/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/Config/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegisctration()
        {
            AccData account = new AccData() {
                Name = "test",
                Pass = "password",
                Email = "testuser@localhost.testdomain"
            };

            app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBUFile("/Config/config_inc.php");
        }
    }
}
