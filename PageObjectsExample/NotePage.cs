
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    }

}