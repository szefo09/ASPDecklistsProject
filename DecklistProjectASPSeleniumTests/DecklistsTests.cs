using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DecklistProjectASPSeleniumTests.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

using System.IO;
using OpenQA.Selenium.Edge;

namespace DecklistProjectASPSeleniumTests
{
    [TestFixture]
    class DecklistsTests
    {
        [Test]
        public void ClickOnCreateNewButton_UserAuthorizated_OpenCreateNewPage()
        {

            using (var driver = (RemoteWebDriver)new ChromeDriver((Environment.CurrentDirectory)))
            {
                var po = new DecklistsIndexPage(driver);
                po.Navigate();
                //System.Threading.Thread.Sleep(10000);
            }
        }
    }
}
