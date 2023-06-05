using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace My_Framework
{
    [TestClass]
    public class Execution : ExtentReport
    {
        private TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testcontext)
        {
            ReportLog("Test Report");
        }
        [AssemblyCleanup] 
        public static void AssemblyCleanup()
        {
            ReportLogEnd();
        }
        [ClassInitialize]
        public static void ClassInitialize(TestContext testcontext)
        {
           
        }
        [ClassCleanup]
        public static void ClassCleanUp()
        {

        }
        [TestInitialize]
        public void TestInitialize()
        {
            ParentNodeCreation(TestContext.TestName);
            ChildNodeCreation(TestContext.TestName);
            BrowserInitialize("firefox");
            ExtentOpenUrl("https://adactinhotelapp.com/index.php");
            
        }
        [TestCleanup]
        public void TestCleanup()
        {
            BrowserQuit();
        }
    }
}
