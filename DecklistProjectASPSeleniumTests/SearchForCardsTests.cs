using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DecklistProjectASPSeleniumTests.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.IO;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace DecklistProjectASPSeleniumTests
{
    [TestFixture]
    class SearchForCardsTests : TestMethods
    {
        [Test]
        public void SearchForCard_UserSubmittedCardID_ShowResults()
        {
            using (var driver = new ChromeDriver((Environment.CurrentDirectory)))
            {
                var po = new SearchForCardPage(driver);
                po.Navigate();
                po.CardIDInput.SendKeys("12");
                po.CardSearchSubmit.Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains("Result:"));
            }
        }
        [Test]
        public void SearchForCard_UserSubmittedCardName_ShowResults()
        {
            using (var driver = new ChromeDriver((Environment.CurrentDirectory)))
            {
                var po = new SearchForCardPage(driver);
                po.Navigate();
                po.CardNameInput.SendKeys("Blue-Eyes");
                po.CardSearchSubmit.Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains("Result:"));
            }
        }
    }
}
