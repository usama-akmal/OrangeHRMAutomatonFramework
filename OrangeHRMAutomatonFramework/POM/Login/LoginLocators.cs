using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.Login
{
    public class LoginLocators
    {
        public static string usernameLocator = "#txtUsername";
        public static string passwordLocator = "#txtPassword";
        public static string loginLocator = "#frmLogin > div.button-holder > button";
        public static string usernameErrorLocator = "#txtUsername-error";
        public static string passwordErrorLocator = "#txtPassword-error";
    }
}
