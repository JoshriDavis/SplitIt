using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitIt.Tests
{
    public class BaseTest
    {
        #region Variables
        public IWebDriver driver;
        public string pageUrl;
        public const int TIMEOUT_PERIOD = 1800000;
        #endregion

        #region Setup
        [SetUp]
        public void setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-blink-features=AutomationControlled", "--disable-extensions", 
                "--incognito", "--window-size=1920,1080");
            options.AddAdditionalOption("useAutomationExtension", false);
            options.AddExcludedArguments("excludeSwitches", "enable-automation");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(45);
            pageUrl = "https://pos.sandbox.splitit.com/";
        }
        #endregion

        #region TearDown
        [TearDown]
        public void tearDown()
        {
            Thread.Sleep(500);
            driver.Quit();
        }
        #endregion
    }
}
