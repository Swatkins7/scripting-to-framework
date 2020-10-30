using Framework.Selenium;
using NUnit.Framework;
using Royale.Pages;

namespace Tests
{
    public class TopListsTests : TestBase
    {
        HeaderNav headerNav = new HeaderNav();

        [Test, Category("toplists")]
        public void Can_navigate_to_popular_cards_page()
        {
            headerNav.ClickTopListsDropdown().ClickPopularCardsLink();
            Assert.That(Driver.Title, Is.EqualTo("Top Clash Royale Cards"));
        }

        [Test, Category("toplists")]
        public void Can_navigate_to_top_players_page()
        {
            headerNav.ClickTopListsDropdown().ClickTopPlayersLink();
            Assert.That(Driver.Title, Is.EqualTo("StatsRoyale.com - Clash Royale Statistics"));
        }

        [Test, Category("toplists")]
        public void Can_navigate_to_top_clans_page()
        {
            headerNav.ClickTopListsDropdown().ClickTopClansLink();
            Assert.That(Driver.Title, Is.EqualTo("Top Clans"));
        }
    }
}