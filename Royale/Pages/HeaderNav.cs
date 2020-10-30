using System;
using Framework;
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

        public void OpenTournamentsDropdown()
        {
            Map.TournamentsTabDropdown.Click();
        }

        public HeaderNav ClickTournamentsDropdown()
        {
            Map.TournamentsTabDropdown.Click();
            return this;
        }

        public void ClickLeaguesLink()
        {
            ClickDropdownOption(Map.LeaguesDropdownLink);
        }

        public void ClickFreeTournamentsLink()
        {
            ClickDropdownOption(Map.FreeTournamentsDropdownLink);
        }

        private void ClickDropdownOption(Element element)
        {
            FW.Log.Step("Click Dropdown option");
            try
            {
                element.Click();
            }
            catch (ElementNotVisibleException)
            {
                FW.Log.Error($"Element {element} is not visible");
            }
        }
    }

    public class HeaderNavMap
    {
        public Element TournamentsTabDropdown => Driver.FindElement(By.XPath("//a[contains(@class,'linkWithDropdown') and contains(text(),'Tournaments')]"), "Tournaments Dropdown");
        public Element LeaguesDropdownLink => Driver.FindElement(By.CssSelector("a[href='/leagues']"), "Leagues Dropdown Link");
        public Element FreeTournamentsDropdownLink => Driver.FindElement(By.CssSelector("a[href='/tournaments']"), "Leagues Dropdown Link");

        public Element CardsTabLink => Driver.FindElement(By.CssSelector("a[href='/cards']"), "Cards Link");
        public Element DeckBuilderTabLink => Driver.FindElement(By.CssSelector("a[href*='/deckbuilder']"), "Deck Builder Link");
    }
}