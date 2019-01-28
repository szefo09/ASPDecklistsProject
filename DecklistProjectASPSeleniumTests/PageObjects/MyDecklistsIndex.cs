using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Remote;

namespace DecklistProjectASPSeleniumTests.PageObjects
{
    class MyDecklistsIndex : DecklistsIndexPage
    {
        public MyDecklistsIndex(RemoteWebDriver driver) : base(driver)
        {
            PathAfterLocalAddress = "Decklists/MyDecklistsIndex";
        }
    }
}
