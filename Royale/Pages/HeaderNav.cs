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

        public HeaderNav ClickTopListsDropdown()
        {
            Map.TopListsTabDropdown.Click();
            return this;
        }
        public void ClickPopularCardsLink()
        {
            ClickDropdownOption(Map.PopularCardsDropdownLink);
        }
        public void ClickTopPlayersLink()
        {
            ClickDropdownOption(Map.TopPlayersDropdownLink);
        }
        public void ClickTopClansLink()
        {
            ClickDropdownOption(Map.TopClansDropdownLink);
        }

        public HeaderNav ClickDecksDropdown()
        {
            Map.DecksTabDropdown.Click();
            return this;
        }
        public void ClickPopularDecksLink()
        {
            ClickDropdownOption(Map.PopularDecksDropdownLink);
        }
        public void ClickChallengeDecksLink()
        {
            ClickDropdownOption(Map.ChallengeDecksDropdownLink);
        }
        public void ClickTopPlayerDecksLink()
        {
            ClickDropdownOption(Map.TopPlayerDecksDropdownLink);
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
        //Tournaments
        public Element TournamentsTabDropdown => Driver.FindElement(By.XPath("//a[contains(@class,'linkWithDropdown') and contains(text(),'Tournaments')]"), "Tournaments Dropdown");
        public Element LeaguesDropdownLink => Driver.FindElement(By.CssSelector("a[href='/leagues']"), "Leagues Dropdown Link");
        public Element FreeTournamentsDropdownLink => Driver.FindElement(By.CssSelector("a[href='/tournaments']"), "Leagues Dropdown Link");

        //Cards and Deck Builder
        public Element CardsTabLink => Driver.FindElement(By.CssSelector("a[href='/cards']"), "Cards Link");
        public Element DeckBuilderTabLink => Driver.FindElement(By.CssSelector("a[href*='/deckbuilder']"), "Deck Builder Link");

        //Top Lists
        public Element TopListsTabDropdown => Driver.FindElement(By.XPath("//a[contains(@class,'linkWithDropdown') and contains(text(),'Top Lists')]"), "Tops Lists Dropdown");
        public Element PopularCardsDropdownLink => Driver.FindElement(By.CssSelector("a[href='/top/cards']"), "Popular Cards Dropdown Link");
        public Element TopPlayersDropdownLink => Driver.FindElement(By.CssSelector("a[href='/top/players']"), "Top Players Dropdown Link");
        public Element TopClansDropdownLink => Driver.FindElement(By.CssSelector("a[href='/top/clans']"), "Top Clans Dropdown Link");

        //Decks
        public Element DecksTabDropdown => Driver.FindElement(By.XPath("//a[contains(@class,'linkWithDropdown') and contains(text(),'Decks')]"), "Decks Dropdown");
        public Element PopularDecksDropdownLink => Driver.FindElement(By.CssSelector("a[href='/decks/popular']"), "Popular Decks Dropdown Link");
        public Element ChallengeDecksDropdownLink => Driver.FindElement(By.CssSelector("a[href*='/decks/challenge']"), "Challenge Deck Dropdown Link");
        public Element TopPlayerDecksDropdownLink => Driver.FindElement(By.CssSelector("a[href*='/decks/top200']"), "Top Player Decks Dropdown Link");
    }
}