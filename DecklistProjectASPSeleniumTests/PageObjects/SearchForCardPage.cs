using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;

namespace DecklistProjectASPSeleniumTests.PageObjects
{
    class SearchForCardPage : PageObjectsBase
    {
        const string cardIDInputSelector = "#CardIdentifier";
        const string cardNameInputSelector = "#CardName";
        const string cardSearchSubmitSelector = "body > div > div.row > div > form > div:nth-child(3) > input";
        public SearchForCardPage(RemoteWebDriver driver) : base(driver, "/Decklists/SearchForCard")
        {
        }
        [FindsBy(How = How.CssSelector, Using = cardIDInputSelector)]
        public IWebElement CardIDInput { get; set; }
        [FindsBy(How = How.CssSelector, Using = cardNameInputSelector)]
        public IWebElement CardNameInput { get; set; }
        [FindsBy(How = How.CssSelector, Using = cardSearchSubmitSelector)]
        public IWebElement CardSearchSubmit { get; set; }
    }
}
