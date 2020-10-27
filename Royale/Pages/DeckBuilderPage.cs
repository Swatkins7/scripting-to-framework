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
            HeaderNav.Map.DeckBuilderTabLink.Click();
            return this;
        }

        public void AddCardsManually()
        {
            Map.AddCardsManuallyLink.Click();
        }

        public void CopySuggestedDeck()
        {
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
        public IWebElement AddCardsManuallyLink => Driver.FindElement(By.XPath("//a[text()='add cards manually']"));

        public IWebElement CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"));
    }
}