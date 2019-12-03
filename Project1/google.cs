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
}

