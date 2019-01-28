using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;

namespace DecklistProjectASPSeleniumTests.PageObjects
{
    class DecklistsIndexPage : PageObjectsBase
    {
        public const string CreateNewDecklistButtonSelector = "body > div > p:nth-child(2) > a";
        public const string SearchForCardButtonSelector = "body > div > p:nth-child(3) > a";

        public DecklistsIndexPage(RemoteWebDriver driver) : base(driver,"Decklists")
        {

        }

        [FindsBy(How = How.CssSelector, Using = CreateNewDecklistButtonSelector)]
        public IWebElement CreateNewDecklistButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = SearchForCardButtonSelector)]
        public IWebElement SearchForCardButton { get; set; }
    }
}
