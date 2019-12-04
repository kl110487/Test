using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace PageObjectsExample
{
    internal class AdminPage
    {
        private IWebDriver _browser;

        public AdminPage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal string AddNot(ExampleNote exampleNote)
        {
            var menuOptions = _browser.FindElements(By.ClassName("wp-menu-name"));
            var wpisy = menuOptions.Single(c => c.Text == "Wpisy");
            wpisy.Click();

            var button = _browser.FindElement(By.ClassName("page-title-action"));
            button.Click();

            var Title = _browser.FindElement(By.Id("title"));
            Title.SendKeys(exampleNote.Title);

            var Comment = _browser.FindElement(By.Id("content"));
            Comment.SendKeys(exampleNote.Content);

            var publish = _browser.FindElement(By.Id("publish"));
            publish.Click();

            WaitForClickable(By.Id("edit-slug-buttons"), 5);
            var link = _browser.FindElement(By.CssSelector("#sample-permalink > a"));
            var linkText = link.GetAttribute("href");

            MoveToElement(By.Id("wp-admin-bar-my-account"));
            WaitForClickable(By.Id("wp-admin-bar-logout"));

            _browser.FindElement(By.Id("wp-admin-bar-logout")).Click();


            return linkText;
        }
        internal void MoveToElement(By selector)
        {
            var element = _browser.FindElement(selector);
            MoveToElement(element);
        }
        internal void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        internal void WaitForClickable(By by, int seconds = 5)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
        internal void WaitForClickable(IWebElement element, int seconds = 5)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}