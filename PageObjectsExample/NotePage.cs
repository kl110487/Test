
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace PageObjectsExample
{
    internal class NotePage
    {
        private IWebDriver _browser;

        public NotePage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal NotePage AddComent(ExamleComment exampleComment)
        {
            var queryBoxComment = _browser.FindElement(By.Id("comment"));
            queryBoxComment.SendKeys(exampleComment.Content);

            var queryBoxAuthor = _browser.FindElement(By.Id("author"));
            queryBoxAuthor.SendKeys(exampleComment.Author);

            var queryBoxEmail = _browser.FindElement(By.Id("email"));
            queryBoxEmail.SendKeys(exampleComment.Email);

            MoveToElement(_browser.FindElement(By.CssSelector("div.nav-links")));
            _browser.FindElement(By.Id("submit")).Submit();
            return new NotePage( _browser);
        }

        internal bool HasNot(ExampleNote note)
        {
            WaitForClickable(By.CssSelector(".entry-title"), 5);
                var x = _browser.FindElement(By.CssSelector(".entry-title"));
                var y = _browser.FindElement(By.CssSelector(".entry-content > p"));

            return x.Text == note.Title && y.Text == note.Content;
        }

        internal void GoTo(string adminPage)
        {
            _browser.Navigate().GoToUrl(adminPage);
        }

        internal bool Has(ExamleComment exampleCommment)
        {
            var comments = _browser.FindElements(By.CssSelector("article.comment-body"));
            var myComments = comments
            .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleCommment.Author)
            .Where(c => c.FindElement(By.CssSelector(".comment-content > p")).Text == exampleCommment.Content);

            return myComments.Count() == 1;
        }
        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
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