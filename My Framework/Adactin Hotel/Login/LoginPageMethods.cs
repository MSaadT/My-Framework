using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Framework
{
    public partial class LoginPage : BasePage
    {
        #region Properties
        public string username { get; set; }
        public string password { get; set; }
        #endregion
        public void Login()
        {
            ExtentFindnSendKeys(usernameLocator, username);
            ExtentFindnSendKeys(passwordLocator, password);
            ExtentClickElement(loginbtnLocator);
        }
    }
}
