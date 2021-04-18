using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";

        private AutoItX3 aux;
        protected GroupHelper groupHelper;

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"C:\Tools\AddressBook.exe","",aux.SW_SHOW);
            WaitAndActivate(WINTITLE);
            groupHelper = new GroupHelper(this);
        }

        public void WaitAndActivate(string title)
        {
            aux.WinWait(title, title, 5);
            aux.WinActivate(title, title);
            aux.WinWaitActive(title, title, 5);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper; 
            }

        } 
    }
}
