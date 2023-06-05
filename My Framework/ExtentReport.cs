using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium.Support.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace My_Framework
{
    [TestClass]
    public class ExtentReport : BasePage
    {
        public static void ReportLog(string testcase)
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(directorypath);
            htmlReporter.Config.DocumentTitle = "Automation Testing Report";
            htmlReporter.Config.ReportName = "Adactin Hotel";
            htmlReporter.Config.Theme = Theme.Standard;

            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);

            extentReports.AddSystemInfo("AUT", "Hotel Adactin");
            extentReports.AddSystemInfo("Environment", "QA");
            extentReports.AddSystemInfo("Machine", Environment.MachineName);
            extentReports.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }
        public void ParentNodeCreation(string methodName)
        {
            exParentTest = extentReports.CreateTest(methodName);
        }
        public void ChildNodeCreation(string methodName)
        {
            exChildTest = exParentTest.CreateNode(methodName);
        }
        
        public static void ReportLogEnd()
        {
            extentReports.Flush();
        }
    }
}
