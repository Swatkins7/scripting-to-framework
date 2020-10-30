using System.Linq;
using Framework.Models;
using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardDetailsPage : PageBase
    {
        public readonly CardDetailsPageMap Map;
        public CardDetailsPage()
        {
            Map = new CardDetailsPageMap();
        }
        public (string Category, int Arena) GetCardCategory()
        {
            var categories = Map.CardCategory.Text.Split(',');
            var type = categories[0].Trim().ToLower();
            var arena = categories[1].Trim().Split(" ").Last();
            
            int intArena;
            if(int.TryParse(arena, out intArena))
            {
                return (type, intArena);
            }

            return (type, 0);  //Arena is "Training camp" (example - Fireball)
        }
        
        public Card GetBaseCard()
        {
            var (category, arena) = GetCardCategory();
 
            return new Card
            {
                Name = Map.CardName.Text,
                Rarity = Map.CardRarityInfo.Text.Split('\n').Last(),
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
        public Element CardName => Driver.FindElement(By.CssSelector("div[class*='cardName']"), "Card Name");
        public Element CardCategory => Driver.FindElement(By.CssSelector("div[class*='card__rarity'"), "Card Category");
        public Element CardRarityInfo => Driver.FindElement(By.CssSelector("[class*='rarityCaption'"), "Card Rarity Info");
    }
}