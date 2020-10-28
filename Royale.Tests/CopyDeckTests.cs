using System.Text.RegularExpressions;
using Framework.Selenium;
using NUnit.Framework;
using Royale.Pages;

namespace Tests
{
    public class CopyDeckTests : TestBase
    {
        [Test, Category("copydeck")]
        public void User_can_copy_a_deck()
        {
            Pages.DeckBuilder.GoTo().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.Yes();
            Assert.That(Pages.CopyDeck.Map.CopiedMessage.Displayed);
        }

        [Test, Category("copydeck")]
        public void User_opens_app_store()
        {
            Pages.DeckBuilder.GoTo().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.No().OpenAppStore();

            var title = Regex.Replace(Driver.Title, @"\u200E", string.Empty); //Left-to-right mark
            title = Regex.Replace(title, @"\u00A0", " "); //non-breaking space
            Assert.That(title, Is.EqualTo("Clash Royale on the App Store"));
        }

        [Test, Category("copydeck")]
        public void User_opens_google_play()
        {
            Pages.DeckBuilder.GoTo().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.No().OpenGooglePlay();

            var title = Regex.Replace(Driver.Title, @"\u200E", string.Empty); //Left-to-right mark
            title = Regex.Replace(title, @"\u00A0", " "); //non-breaking space
            //This assertion will fail, because the button redirects to the App Store
            Assert.AreEqual("Clash Royale - Apps on Google Play", Driver.Title);
        }
    }
}