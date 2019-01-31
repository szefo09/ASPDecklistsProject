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
using OpenQA.Selenium;

namespace DecklistProjectASPSeleniumTests
{
    [TestFixture]
    class AddDeckTests : TestMethods
    {
        [Test]
        public void UserOpensAddNewDeckPage_UserUnauthorizated_OpenLoginPage()
        {
            using (var driver = (RemoteWebDriver)new ChromeDriver((Environment.CurrentDirectory)))
            {

                var po = new AddDeckPage(driver);
                po.Navigate();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains("Log in"));
            }
        }
        [Test]
        public void UserOpensAddNewDeckPage_UserAuthorizated_OpenAddDecklistsPage()
        {
            using (var driver = (RemoteWebDriver)new ChromeDriver((Environment.CurrentDirectory)))
            {

                var po = new AddDeckPage(driver);
                po.Navigate();
                LoginUser(po,driver);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains("Add Decklist"));
            }
        }
        [Test]
        public void UserInputsProperDeckNameAndDeckFile_AddDecklistAndShowIt()
        {
            using (var driver = (RemoteWebDriver)new ChromeDriver((Environment.CurrentDirectory)))
            {

                var po = new AddDeckPage(driver);
                po.Navigate();
                LoginUser(po, driver);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains("Add Decklist"));
                po.DecklistName.SendKeys("AI_Blue_Eyes");
                po.DecklistFile.SendKeys(Path.Combine(Environment.CurrentDirectory, "AI_BlueEyes.ydk"));
                po.ShowAsPublic.SendKeys(Keys.Space);
                po.CreateSubmit.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains(" Decklists"));
            }
        }
        [Test]
        public void UserInputsInproperorMissingDeckNameAndDeckFile_GoBackToAddDecklistPage()
        {
            using (var driver = (RemoteWebDriver)new ChromeDriver((Environment.CurrentDirectory)))
            {

                var po = new AddDeckPage(driver);
                po.Navigate();
                LoginUser(po, driver);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains("Add Decklist"));
                po.DecklistName.SendKeys("AI_Blue_Eyes");
                po.ShowAsPublic.SendKeys(Keys.Space);
                po.CreateSubmit.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > div.row > div > form > div:nth-child(2) > span")));
            }
        }
    }
}
