using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Xunit;
namespace PageObjectsExample
{
     public class NoteTest :BaseTest
    {
        [Fact]
        public void Can_publish_new_note()
        {
            var loginPage = LoginPage.Open(GetBrowser());
            var adminPage = loginPage.Login();
            var note = new ExampleNote();
            var AdminPage = adminPage.AddNot(note);
            var NotePage = new NotePage(GetBrowser());
            NotePage.GoTo(AdminPage);

            Assert.True(NotePage.HasNot(note));
        }
    }
}
