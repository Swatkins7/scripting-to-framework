using NUnit.Framework;
using Framework.Models;
using Framework.Services;
using Royale.Pages;
using System.Collections.Generic;

namespace Tests
{
    public class CardTests : TestBase
    {
        static IList<Card> apiCards = new ApiCardService().GetAllCards();

        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_is_on_Cards_Page(Card card)
        {
            var cardOnPage = Pages.Cards.GoTo().GetCardByName(card.Name);
            Assert.That(cardOnPage.Displayed);
        }

        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_Card_Details_Page(Card card)
        {
            Pages.Cards.GoTo().GetCardByName(card.Name).Click();
            var cardOnPage = Pages.CardDetails.GetBaseCard();

            if(cardOnPage.Type == "troop")
                cardOnPage.Type = "character";

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.That(card.Type.Contains(cardOnPage.Type));
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, card.Rarity);
        }
    }
}