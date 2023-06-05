using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_Framework;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;

namespace My_Framework
{
    [TestClass]
    public class LoginPageTC : Execution
    {
        LoginPage loginpage = new LoginPage();

        [TestMethod]
        public void ValidLogin()
        {
            loginpage.username = "Dheerajkh";
            loginpage.password = "dheeraj@12";
            loginpage.Login();
        }
        [TestMethod]
        public void InvalidLogin()
        {
            loginpage.username = "invalid";
            loginpage.password = "invalid@12";
            loginpage.Login();
        }
        [TestMethod]
        public void ValidUserInvalidPassword()
        {
            loginpage.username = "Dheerajkh";
            loginpage.password = "invalid@12";
            loginpage.Login();
        }
        [TestMethod]
        public void InvalidUserValidPassword()
        {
            loginpage.username = "invalid";
            loginpage.password = "dheeraj@12";
            loginpage.Login();
        }
    }
}
