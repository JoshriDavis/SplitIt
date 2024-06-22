using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitIt.Pages
{
    internal class LoginPage : BasePage
    {
        #region Variables
        [FindsBy(How = How.Name, Using = "Username")]
        public IWebElement username { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.main-row.d-flex > div.content-container.d-flex.flex-column.justify-content-between > div.main-content-wrapper > form > div.d-flex.align-items-center > button")]
        public IWebElement loginBtn { get; set; }

        [FindsBy(How = How.Id, Using = "onetrust-accept-btn-handler")]
        public IWebElement acceptAllCookies { get; set; }
        #endregion

        #region Page Factory
        public LoginPage(IWebDriver _driver) : base(_driver)
        {
            driver = _driver;
            PageFactory.InitElements(_driver, this);
        }
        #endregion

        #region Functions
        // Log in
        public void login(string _email, string _password)
        {
            click(acceptAllCookies);
            fillText(username, _email);
            fillText(password, _password);
            click(loginBtn);
        }
        #endregion
    }
}
