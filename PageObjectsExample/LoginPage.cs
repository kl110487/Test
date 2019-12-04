
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectsExample
{
    internal partial class LoginPage
    {
        private const string MAIN_PAGE_BASE_URL = "http://automatyzacja.benedykt.net/wp-admin";
        private readonly IWebDriver _browser;
      

            public LoginPage(IWebDriver webDriver)
        {
            _browser = webDriver;
            _browser.Navigate().GoToUrl(MAIN_PAGE_BASE_URL);
        }

        internal AdminPage Login()
        {

            WaitForClickable(By.Id("user_login"), 5);
            var queryBoxComment = _browser.FindElement(By.Id("user_login"));
            queryBoxComment.SendKeys("automatyzacja");

            WaitForClickable(By.Id("user_pass"), 5);
            var queryBoxAuthor = _browser.FindElement(By.Id("user_pass"));
            queryBoxAuthor.SendKeys("auto@Zima2019");

            var queryBoxEmail = _browser.FindElement(By.Id("wp-submit"));
            queryBoxEmail.Click();

            return new AdminPage(_browser);
        }

        internal static LoginPage Open(IWebDriver webDriver)
        {
            return new LoginPage(webDriver);
        }

        internal void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
        internal void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
