using Framework.Selenium;
using NUnit.Framework;
using Royale.Pages;

namespace Tests
{
    public class TournamentsTests : TestBase
    {
        HeaderNav headerNav = new HeaderNav();

        [Test, Category("tournaments")]
        public void Can_navigate_to_Leagues_page()
        {
            headerNav.ClickTournamentsDropdown().ClickLeaguesLink();
            Assert.That(Driver.Title, Is.EqualTo("Leagues"));
        }

        [Test, Category("tournaments")]
        public void Can_navigate_to_Free_Tournaments_page()
        {
            headerNav.ClickTournamentsDropdown().ClickFreeTournamentsLink();
            Assert.That(Driver.Title, Is.EqualTo("StatsRoyale.com - Clash Royale Statistics")); 
        }
    }
}