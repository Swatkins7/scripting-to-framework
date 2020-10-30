using Framework.Selenium;
using NUnit.Framework;
using Royale.Pages;

namespace Tests
{
    public class DecksTest : TestBase
    {
        HeaderNav headerNav = new HeaderNav();

        [Test, Category("decks")]
        public void Can_navigate_to_popular_decks_page()
        {
            headerNav.ClickDecksDropdown().ClickPopularDecksLink();
            Assert.That(Driver.Title, Is.EqualTo("Best Clash Royale Decks"));
        }

        [Test, Category("decks")]
        public void Can_navigate_to_challenge_decks_page()
        {
            headerNav.ClickDecksDropdown().ClickChallengeDecksLink();
            Assert.That(Driver.Title, Is.EqualTo("Recent Winners - Clash Royale"));
        }

        [Test, Category("decks")]
        public void Can_navigate_to_top_player_decks_page()
        {
            headerNav.ClickDecksDropdown().ClickTopPlayerDecksLink();
            Assert.That(Driver.Title, Is.EqualTo("Top Players - Clash Royale"));
        }
    }
}