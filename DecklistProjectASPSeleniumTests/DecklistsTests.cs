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
    class DecklistsTests : TestMethods
    {
        [Test]
        public void ClickOnCreateNewButton_UserAuthorizated_OpenAddNewDecklistPage()
        {
            using (var driver =(RemoteWebDriver)new ChromeDriver((Environment.CurrentDirectory)))
            {
                
                var po = new DecklistsIndexPage(driver);
                po.Navigate();
                po.CreateNewDecklistButton.Click();
                if (po.LoginButton.Text == "Login")
                {
                    LoginUser(po, driver);
                }
                new WebDriverWait(driver, TimeSpan.FromSeconds(6)).Until(ExpectedConditions.TitleContains("Add Decklist"));
            }
        }

        [Test]
        public void ClickOnCreateNewButton_UserUnauthorizated_OpenLoginPage()
        {
            using (var driver = new ChromeDriver((Environment.CurrentDirectory)))
            {

                var po = new DecklistsIndexPage(driver);

                po.Navigate();
                if (po.LoginButton.Text != "Login")
                {
                    LogoutUser(po, driver);
                }
                po.CreateNewDecklistButton.Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains("Log in"));
            }
        }
        [Test]
        public void ClickOnSearchForCardButton_OpenSearchForCardPage()
        {
            using (var driver = new ChromeDriver((Environment.CurrentDirectory)))
            {

                var po = new DecklistsIndexPage(driver);

                po.Navigate();
                if (po.LoginButton.Text != "Login")
                {
                    LogoutUser(po, driver);
                }
                po.SearchForCardButton.Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains("Search For Card"));
            }
        }
        [Test]
        public void UserOpensDeckDetails_OpenDeckDetailsPage()
        {
            using (var driver = (RemoteWebDriver)new ChromeDriver((Environment.CurrentDirectory)))
            {


                var po = new DecklistsIndexPage(driver);

                po.Navigate();
                po.DetailsForDeck.Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains("Details"));
            }
        }
    }
}
