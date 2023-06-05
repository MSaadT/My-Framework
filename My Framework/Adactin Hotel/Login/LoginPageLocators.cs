using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_Framework;

namespace My_Framework
{
    public partial class LoginPage
    {
        public By usernameLocator = By.Id("username");
        public By passwordLocator = By.Id("password");
        public By loginbtnLocator = By.Id("login");
    }
}
