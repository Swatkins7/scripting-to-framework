using Framework;
using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class DeckBuilderPage : PageBase
    {
        public readonly DeckBuilderPageMap Map;

        public DeckBuilderPage()
        {
            Map = new DeckBuilderPageMap();
        }

        public DeckBuilderPage GoTo()
        {
            FW.Log.Step("Click Deck Builder link");
            HeaderNav.Map.DeckBuilderTabLink.Click();
            return this;
        }

        public void AddCardsManually()
        {
            FW.Log.Step("Click Add Cards Manually link");
            Map.AddCardsManuallyLink.Click();
        }

        public void CopySuggestedDeck()
        {
            FW.Log.Step("Click Copy Deck icon");
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
        public IWebElement AddCardsManuallyLink => Driver.FindElement(By.XPath("//a[text()='add cards manually']"));

        public IWebElement CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"));
    }
}
