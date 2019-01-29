using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;

namespace DecklistProjectASPSeleniumTests.PageObjects
{
    class LoginPage : PageObjectsBase
    {
        public const string LoginInputSelector = "#Input_Email";
        public const string PasswordInputSelector = "#Input_Password";
        public const string SubmitSelector = "#account > div:nth-child(7) > button";
        public LoginPage(RemoteWebDriver driver) : base(driver, "/Identity/Account/Login")
        {
        }

        [FindsBy(How = How.CssSelector, Using = LoginInputSelector)]
        public IWebElement LoginInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = PasswordInputSelector)]
        public IWebElement PasswordInput { get; set; }
        [FindsBy(How = How.CssSelector, Using = SubmitSelector)]
        public IWebElement Submit { get; set; }
    }
}
