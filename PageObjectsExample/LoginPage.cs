
using OpenQA.Selenium;

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
            var queryBoxComment = _browser.FindElement(By.Id("user_login"));
            queryBoxComment.SendKeys("automatyzacja");

            var queryBoxAuthor = _browser.FindElement(By.Id("user_pass"));
            queryBoxAuthor.SendKeys("auto@Zima2019");

            var queryBoxEmail = _browser.FindElement(By.Id("wp-submit"));
            queryBoxEmail.Click();

            return new AdminPage();
        }

        internal static LoginPage Open(IWebDriver webDriver)
        {
            return new LoginPage(webDriver);
        }
    }
}
