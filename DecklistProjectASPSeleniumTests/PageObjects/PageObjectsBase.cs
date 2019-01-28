using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;

namespace DecklistProjectASPSeleniumTests.PageObjects
{
    abstract class PageObjectsBase
    {
        public RemoteWebDriver Driver { get; protected set; }
        public string LocalAddress { get; protected set; } = "http://localhost:44321/";
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
    }
}