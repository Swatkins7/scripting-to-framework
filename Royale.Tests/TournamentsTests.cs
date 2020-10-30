using Framework.Selenium;
using NUnit.Framework;
using Royale.Pages;

namespace Tests
{
    public class TournamentsTests : TestBase
    {
        [Test, Category("tournaments")]
        public void Leagues_page_loads()
        {
            var headerNav = new HeaderNav();
            headerNav.ClickTournamentsDropdown().ClickLeaguesLink();
            Assert.That(Driver.Title, Is.EqualTo("Leagues"));
        }

        [Test, Category("tournaments")]
        public void Free_Tournaments_page_loads()
        {
            var headerNav = new HeaderNav();
            headerNav.ClickTournamentsDropdown().ClickFreeTournamentsLink();
            Assert.That(Driver.Title, Is.EqualTo("StatsRoyale.com - Clash Royale Statistics")); 
        }
    }
}