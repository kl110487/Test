using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        public void Dispose()
        {
            browser.Quit();
        }

    }

    public class Automatyzacja : IDisposable
    {

        IWebDriver browser;
        public Automatyzacja()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Can_Google_From_Warsow()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/");
            var queryBox = browser.FindElement(By.CssSelector(".entry-title"));
            var link = queryBox.FindElement(By.TagName("a"));
            link.Click();
            var queryBoxComment = browser.FindElement(By.Id("comment"));
            queryBoxComment.Click();
            queryBoxComment.SendKeys("test123");
            var queryBoxAuthor = browser.FindElement(By.Id("author"));
            queryBoxAuthor.SendKeys("bialy");
            var queryBoxEmail = browser.FindElement(By.Id("email"));
            queryBoxEmail.SendKeys("warto@automatyzowac.wp.pl");
            var queryBoxComent = browser.FindElement(By.Id("submit"));
            queryBoxComent.Click();
        }

        public void Dispose()
        {
            browser.Quit();
        }
    }
}