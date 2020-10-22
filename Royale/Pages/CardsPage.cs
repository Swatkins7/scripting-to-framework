using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Royale.Pages
{
    public class CardsPage : PageBase
    {
        public readonly CardsPageMap Map;
     
        public CardsPage(IWebDriver driver) : base(driver)
        {
            Map = new CardsPageMap(driver);   
        }

        public CardsPage GoTo()
        {
            HeaderNav.GoToCardsPage();
            return this;
        }
        
        public IWebElement GetCardByName(string cardName)
        {
            if (cardName.Contains(" "))
            {
                cardName = cardName.Replace(" ", "+");
            }
            return Map.Card(cardName);
        }
    }

    public class CardsPageMap
    {
        IWebDriver _driver;

        public readonly WebDriverWait wait;

        public CardsPageMap(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public IWebElement Card(string name) => wait.Until(drvr => drvr.FindElement(By.CssSelector($"a[href*='{name}']")));
        
    }

}