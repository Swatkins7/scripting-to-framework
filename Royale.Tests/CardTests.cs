using System.IO;
using NUnit.Framework;
using Framework.Models;
using Framework.Services;
using Framework.Selenium;
using Royale.Pages;

namespace Tests
{
    public class CardTests
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
        public void Ice_Spirit_is_on_Cards_Page()
        {
            var iceSpirit = Pages.Cards.GoTo().GetCardByName("Ice Spirit");
            Assert.That(iceSpirit.Displayed);
        }

        static string[] cardNames = {"Ice Spirit", "Mirror"};
        [Test, Category("cards")]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_Card_Details_Page(string cardName)
        {
            Pages.Cards.GoTo().GetCardByName(cardName).Click();
            var cardOnPage = Pages.CardDetails.GetBaseCard();
            var card = new InMemoryCardService().GetCardByName(cardName);

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            if(cardName != "Mirror")
            {
                Assert.AreEqual(card.Rarity, card.Rarity);
            }
        }
    }
}