using System;
using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{

    public class HeaderNav
    {
        public readonly HeaderNavMap Map;

        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }
        public void GoToCardsPage()
        {
            Map.CardsTabLink.Click();
        }

        public void GoToDeckBuilderPage()
        {
            Map.DeckBuilderTabLink.Click();
        }
    }

    public class HeaderNavMap
    {
        public IWebElement CardsTabLink => Driver.FindElement(By.CssSelector("a[href='/cards']"));

        public IWebElement DeckBuilderTabLink => Driver.FindElement(By.CssSelector("a[href*='/deckbuilder']"));
    }
}