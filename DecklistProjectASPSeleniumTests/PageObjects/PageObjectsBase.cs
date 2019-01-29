using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;

namespace DecklistProjectASPSeleniumTests.PageObjects
{
    abstract class PageObjectsBase
    {
        public RemoteWebDriver Driver { get; protected set; }
        public string LocalAddress { get; protected set; } = "http://localhost:50887/"; //local port for tests, didn't work with port 44321
        public const string LoginButtonSelector = "body > nav > div > div.navbar-collapse.collapse > ul.nav.navbar-nav.navbar-right > li:nth-child(2) > a";
        public const string CookiesAcceptSelector = "#cookieConsent > div > div.collapse.navbar-collapse > div > button";
        public string PathAfterLocalAddress { get; protected set; } = "";

        public PageObjectsBase(RemoteWebDriver driver, string pathAfterLocalAddress)
        {
            Driver = driver;
            PathAfterLocalAddress = pathAfterLocalAddress;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            Driver.Navigate().GoToUrl($"{LocalAddress}{PathAfterLocalAddress}");
        }

        [FindsBy(How = How.CssSelector, Using = LoginButtonSelector)]
        public IWebElement LoginButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = CookiesAcceptSelector)]
        public IWebElement CookiesAcceptButton { get; set; }
    }
}