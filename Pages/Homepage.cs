using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitIt.Pages
{
    internal class Homepage : BasePage
    {
        #region Variables
        [FindsBy(How = How.CssSelector, Using = "body > app-root > div > div > app-login > div > div > div > div > div > div.flex.h-4\\/5.sm\\:3\\/5.justify-center > div > app-intro > div > div > button")]
        public IWebElement newTransactionBtn { get; set; }
        #endregion

        #region Page Factory
        public Homepage(IWebDriver _driver) : base(_driver)
        {
            driver = _driver;
            PageFactory.InitElements(_driver, this);
        }
        #endregion

        #region Functions
        // Opens new transaction
        public void newTransaction()
        {
            click(newTransactionBtn);
        }
        #endregion
    }
}
