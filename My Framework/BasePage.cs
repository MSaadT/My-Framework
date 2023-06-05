using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace My_Framework
{
    public class BasePage
    {
        public static IWebDriver driver;
        public static ChromeOptions chromeOptions;
        public static FirefoxOptions firefoxOptions;
        public static EdgeOptions edgeOptions;

        public static ExtentReports extentReports;
        public ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static ExtentHtmlReporter htmlReporter;
        public static string directorypath = @"C:\\ExtentReports\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "\\";


        public void BrowserInitialize(string browser)
        {
            driver = null;
            browser = browser.ToLower();
            if (browser == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (browser == "firefox")
            {
                driver = new FirefoxDriver();
            }
            else if (browser == "msedge")
            {
                driver = new EdgeDriver();
            }
            driver.Manage().Window.Maximize();
        }
        public void ChromeBrowserOptions(string option)
        {
            chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(option);
            driver = new ChromeDriver(chromeOptions);
        }
        public void FireFoxBrowserOptions(string option)
        {
            firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments(option);
            driver = new FirefoxDriver(firefoxOptions);
        }
        public void EdgeBrowserOptions(string option)
        {
            edgeOptions = new EdgeOptions();
            edgeOptions.AddArguments(option);
            driver = new EdgeDriver(edgeOptions);
        }
        public void OpenUrl(string url)
        {
            driver.Url = url;
        }
        public void ExtentOpenUrl(string url)
        {
            try
            {
                driver.Url = url;
                ExtentTakeScreenshot(Status.Pass, "Open url");
            }
            catch (Exception ex)
            {
                ExtentTakeScreenshot(Status.Fail, ex.ToString());
            }
        }
        public void BrowserQuit()
        {
            driver.Quit();
        }
        public void FindnSendKeys(By by, string value)
        {
            driver.FindElement(by).SendKeys(value);
        }
        public void ExtentFindnSendKeys(By by, string value)
        {
            try
            {
                driver.FindElement(by).SendKeys(value);
                ExtentTakeScreenshot(Status.Pass, "Text value:" + value);
            }
            catch (Exception ex)
            {
                ExtentTakeScreenshot(Status.Fail, "Enter text failed: " + ex.ToString());
            }
        }
        public void ClickElement(By by)
        {
            driver.FindElement(by).Click();
        }
        public void ExtentClickElement(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                ExtentTakeScreenshot(Status.Pass, "Locator:" + by);
            }
            catch (Exception ex)
            {
                ExtentTakeScreenshot(Status.Fail, "Text failed: " + ex.ToString());
            }
        }
        public string GetElementText(By by)
        {
            string text = driver.FindElement(by).Text;
            return text;
        }
        public void ClearElement(By by)
        {
            driver.FindElement(by).Clear();
        }
        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }
        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void DropDownValue(By by, string technique, string value)  //Confirm with sir.
        {
            var element = driver.FindElement(by);
            SelectElement selectElement = new SelectElement(element);
            technique = technique.ToLower();
            if (technique == "text")
            {
                selectElement.SelectByText(value);
            }
            else if (technique == "value")
            {
                selectElement.SelectByValue(value);
            }
            else if (technique == "index")
            {
                int index = Convert.ToInt32(value);
                selectElement.SelectByIndex(index);
            }
        }
        public void RadioButton(By by)      //Same as Click
        {
            driver.FindElement(by).Click();
        }
        public void SelectElementByIndex(By by, int index)
        {
            IWebElement element = driver.FindElement(by);
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByIndex(index);
        }
        public void SelectElementByValue(By by, string value)
        {
            IWebElement element = driver.FindElement(by);
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }
        public void SelectElementByText(By by, string text)
        {
            IWebElement element = driver.FindElement(by);
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }
        public void GetElementBy(By by, string technique)
        {
            var element = driver.FindElement(by);
            element.GetAttribute(technique);
        }
        public void ScrollToElementJavaScript(By by)
        {
            var element = driver.FindElement(by);
            ((IJavaScriptExecutor)driver).ExecuteScript("argument[0].scrollIntoView(true);", element);
        }
        public void ScrollToTopJavaScript(By by)
        {
            var element = driver.FindElement(by);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document." + "head" + ".scrollHeight);");
        }
        public void ScrollToBottomJavaScript(By by)
        {
            var element =driver.FindElement(by);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document." + "Body" + ".scrollHeight);");
        }
        public string GetElementState(By by)
        {
            var element = driver.FindElement(by);
            string elementstate = element.GetAttribute("Disabled");
            if (elementstate == null)
            {
                elementstate = "enabled";
            }
            else if (elementstate == "true")
            {
                elementstate = "disabled";
            }
            return elementstate;
        }
        public void SendKeysJavaScript(By by, string text)
        {
            var element = driver.FindElement(by);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value ='" + text + "';", element);
        }
        public void ClickElementJavaScript(By by)
        {
            var element = driver.FindElement(by);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }
        public void SwitchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }
        public void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds * 1000);
        }
        public void ImplicitWait(int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
        public void TakeScreenShot()
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string dateTimeString = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string filepath = @"screenshot_" + dateTimeString + ".png";
            screenshot.SaveAsFile(filepath, ScreenshotImageFormat.Png);
        }
        public static void ExtentTakeScreenshot(Status status, string stepDetail)
        {
            string path = directorypath + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            exChildTest.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path + ".png").Build());
        }
        public string GetPageTitle(string url)
        {
            driver.Url = url;
            string pagetitle = driver.Title;
            return pagetitle;
        }
        public void AssestAreEqual(By by, string expectedText)
        {
            string acutalText = driver.FindElement(by).Text;
            Assert.AreEqual(expectedText, acutalText);
        }
        public void AssestAreNotEqual(By by, string expectedText)
        {
            string acutalText = driver.FindElement(by).Text;
            Assert.AreNotEqual(expectedText, acutalText);
        }
        public void AssertAreSame(string text1, string text2)
        {
            Assert.AreSame(text1, text2);
            //Assert.AreSame(by1, by2);     Verify this with sir.
        }
        public void AssertAreNotSame(string text1, string text2)
        {
            Assert.AreNotSame(text1, text2);
            //Assert.AreNotSame(by1, by2);     Verify this with sir.
        }
        public void AssertStringContains(string subString, string inputString)
        {
            StringAssert.Contains(subString, inputString);     //"Hello", "Hello World"
        }
        //Assert.IsTrue();
        //Assert.IsFalse();
        //Assert.IsNull(null);
        //Assert.IsNotNull(null);
        public void SwitchToFrameByIndex(int index)
        {
            driver.SwitchTo().Frame(index);
        }
        public void SwitchToFrameByName(By by, string name)
        {
            //Ask sir
        }
        public void SwitchToFrameByElement(By by)
        {
            var element = driver.FindElement(by);
            driver.SwitchTo().Frame(element);
        }
        public void SwitchWindow(int index)
        {
            driver.SwitchTo().Window(driver.WindowHandles[index]);
        }

    }
}
