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
    internal class TestMethods
    {
        internal void LoginUser(PageObjectsBase page, RemoteWebDriver driver, bool isAdmin = false)
        {
            CloseCookies(page);
            new WebDriverWait(driver, TimeSpan.FromSeconds(6)).Until(ExpectedConditions.TitleContains("Log in"));
            var poLogin = new LoginPage(driver);
            if (isAdmin)
            {
                poLogin.LoginInput.SendKeys("admin@decklist.net");
                poLogin.PasswordInput.SendKeys("adminYGO");
            }
            else
            {
                poLogin.LoginInput.SendKeys("user@decklist.net");
                poLogin.PasswordInput.SendKeys("userYGO");
            }
            poLogin.Submit.Click();
        }
        internal void LogoutUser(PageObjectsBase page, RemoteWebDriver driver, bool isAdmin = false)
        {
            CloseCookies(page);
            page.LoginButton.Click();
        }
        internal void CloseCookies(PageObjectsBase page)
        {
            if (page.CookiesAcceptButton.Displayed)
            {
                page.CookiesAcceptButton.Click();
            }
        }

    }
}