using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; private set; }
        public FtpHelper Ftp { get; private set; }
        protected LoginHelper loginHelper;
        protected ManagementMenuHelper navigator;
        protected ProjectManagementHelper projectHelper;
        protected AdminHelper admin;
        protected APIHelper api;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.0";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            loginHelper = new LoginHelper(this);
            navigator = new ManagementMenuHelper(this, baseURL);
            projectHelper = new ProjectManagementHelper(this);
            admin = new AdminHelper(this, baseURL);
            api = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public ManagementMenuHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public ProjectManagementHelper Projects
        {
            get
            {
                return projectHelper;
            }
        }

        public AdminHelper Admin
        {
            get
            {
                return admin;
            }
        }

        public APIHelper Api
        {
            get
            {
                return api;
            }
        }
    }
}
 
