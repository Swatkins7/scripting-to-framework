using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using Royale.Pages;

namespace Tests
{
    public class CopyDeckTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            Pages.Init();
            Driver.Current.Manage().Window.Maximize();
            Driver.Goto("https://statsroyale.com");
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Quit();
        }

        [Test]
        public void User_can_copy_a_deck()
        {
            Pages.DeckBuilder.GoTo();
            Pages.DeckBuilder.AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.Yes();
            Assert.That(Pages.CopyDeck.Map.CopiedMessage.Displayed);
        }
    }
}