using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project1
{
    public class google : IDisposable
    {

        IWebDriver browser;
        public google()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Can_Google_From_Warsow()
        {
            browser.Navigate().GoToUrl("https://googl.com");
            var queryBox = browser.FindElement(By.CssSelector(".gLFyf"));
            queryBox.SendKeys("pogoda warszawa");
            queryBox.Submit();
            var result = browser.FindElement(By.Id("wob_tm"));

            Assert.Equal("3", result.Text);
        }


        [Fact]
        public void Can_add_new_comment()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/");
            var queryBox = browser.FindElement(By.CssSelector(".entry-title"));
            var link = queryBox.FindElement(By.TagName("a"));
            link.Click();
            var queryBoxComment = browser.FindElement(By.Id("comment"));
            var examoleText = Faker.Lorem.Paragraph();
            queryBoxComment.SendKeys(examoleText);
            //queryBoxComment.Click();
            // queryBoxComment.SendKeys("test123");
            var queryBoxAuthor = browser.FindElement(By.Id("author"));
            queryBoxAuthor.SendKeys("bialy");
            var queryBoxEmail = browser.FindElement(By.Id("email"));
            queryBoxEmail.SendKeys("warto@automatyzowac.wp.pl");
            var queryBoxComent = browser.FindElement(By.Id("submit"));

            MoveToElement(browser.FindElement(By.CssSelector("div.nav-links")));
            browser.FindElement(By.Id("submit")).Submit();

            var comments = browser.FindElements(By.CssSelector("article.comment-body"));
            var myComments = comments
            .Where(c => c.FindElement(By.CssSelector(".fn")).Text == "bialy")
            .Where(c => c.FindElement(By.CssSelector(".comment-content > p")).Text == examoleText);

            Assert.Single(myComments);
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();

        }

        public void Dispose()
        {
            browser.Quit();
        }

    }
}