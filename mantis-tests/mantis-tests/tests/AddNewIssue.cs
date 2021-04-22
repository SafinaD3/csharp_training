using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AdditionNewIssue()
        {
            AccData account = new AccData()
            {
                Name = "administrator",
                Pass = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "4"
            };
            IssueData issueData = new IssueData()
            {
                Summary = "some text",
                Description = "some loooooong text",
                Category = "General"
            };
            app.Api.CreateNewIssue(account, project, issueData);
        }
    }
}
