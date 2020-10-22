using System;
using System.Linq;
using Framework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Royale.Pages
{
    public class CardDetailsPage : PageBase
    {
        public readonly CardDetailsPageMap Map;
        public CardDetailsPage(IWebDriver driver) : base(driver)
        {
            Map = new CardDetailsPageMap(driver);
        }
        public (string Category, string Arena) GetCardCategory()
        {
            var categories = Map.CardCategory.Text.Split(',');
            return (categories[0].Trim(), categories[1].Trim());
        }
        
        public Card GetBaseCard()
        {
            var (category, arena) = GetCardCategory();

            //Mirror card doesn't have a rarity element
            var rarity = "no rarity";
            if(Map.CardName.Text != "Mirror")
            {
                rarity = Map.CardRarityInfo.Text.Split('\n').Last();
            }

            return new Card
            {
                Name = Map.CardName.Text,
                Rarity = rarity,
                Type = category,
                Arena = arena
            };
        }
        public string GetCardRarity()
        {
            return Map.CardRarityInfo.Text.Split('\n').Last();
        }
    }
    public class CardDetailsPageMap
    {
        IWebDriver _driver;
        public readonly WebDriverWait wait;
        public CardDetailsPageMap(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public IWebElement CardName => _driver.FindElement(By.CssSelector("div[class*='cardName']"));
        public IWebElement CardCategory => wait.Until(drvr => drvr.FindElement(By.CssSelector("div[class*='card__rarity'")));
        public IWebElement CardRarityInfo => _driver.FindElement(By.CssSelector("[class*='rarityCaption'"));
    }
}