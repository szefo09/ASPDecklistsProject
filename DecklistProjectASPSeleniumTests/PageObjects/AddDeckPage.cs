using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;


namespace DecklistProjectASPSeleniumTests.PageObjects
{
    class AddDeckPage : PageObjectsBase
    {
        public const string DecklistNameSelector = "#DecklistName";
        public const string DecklistFileSelector = "#DecklistFile";
        public const string ShowAsPublicSelector = "#isPublic";
        public const string CreateSubmitSelector = "body > div > div.row > div > form > div:nth-child(4) > input";
        public AddDeckPage(RemoteWebDriver driver) : base(driver, "/Decklists/Create")
        {
        }

        [FindsBy(How = How.CssSelector, Using = DecklistNameSelector)]
        public IWebElement DecklistName { get; set; }

        [FindsBy(How = How.CssSelector, Using = DecklistFileSelector)]
        public IWebElement DecklistFile { get; set; }
        [FindsBy(How = How.CssSelector, Using = ShowAsPublicSelector)]
        public IWebElement ShowAsPublic { get; set; }
        [FindsBy(How = How.CssSelector, Using = CreateSubmitSelector)]
        public IWebElement CreateSubmit { get; set; }

    }
}
