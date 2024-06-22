using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Configuration;
using System.Data;

namespace SplitIt.Pages
{
    internal class BasePage
    {
        #region Variables
        public IWebDriver driver;
        private Actions a;                                                // this is the actions variables that is used to perform selenium actions
        private WebDriverWait wait;
        #endregion

        #region Page Factory
        public BasePage(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(_driver, this);
            a = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        #endregion

        #region Functions
        // Sleep
        public void sleep(int mills)
        {
            try
            {
                System.Threading.Thread.Sleep(mills);
            }
            catch (Exception e)
            {
                Console.WriteLine(System.Environment.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        // Fill text in input field
        public void fillText(IWebElement el, string text)
        {                                                  // A smarter version of the "SendKeys" funtion
            try
            {
                // Try filling the text regularly
                sleep(500);
                el.Clear();
                el.SendKeys(text);
            }
            catch (Exception)                              // if fails it will try again after a second
            {
                try
                {
                    sleep(1000);
                    el.Clear();
                    el.SendKeys(text);
                }
                catch (Exception)                          // If fails, try fillin the text using JS
                {
                    sleep(1000);
                    el.Clear();
                    string javasciptArgument = "arguments[0].textContent='" + text + "';";
                    IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                    jse.ExecuteScript(javasciptArgument, el);
                }
            }
        }

        // Click on element
        public void click(IWebElement el)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(el));
                el.Click();
            }
            catch (NoSuchElementException)
            {                                              // if the click was failed, it will try again after 1 second
                try
                {
                    sleep(1000);
                    el.Click();
                }
                catch (NoSuchElementException)
                {                                          // if the click was failed, it will try again USING JAVASCRIPT after 1 second
                    try
                    {
                        sleep(1000);
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                        executor.ExecuteScript("arguments[0].click();", el);
                    }
                    catch (NoSuchElementException)
                    {
                        Console.WriteLine("Cloud not click on the element");
                    }
                }
            }
            catch (WebDriverTimeoutException)
            {
                try
                {
                    sleep(1000);
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                    executor.ExecuteScript("arguments[0].click();", el);
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine("Cloud not click on the element");
                }
            }
            sleep(1000);
        }

        #endregion
    }
}
