using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;
using Framework.Models;
using Framework.Services;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {        
            driver = new ChromeDriver(Path.GetFullPath("../../../../" + "_drivers"));
            driver.Manage().Window.Maximize();
            driver.Url = "https://statsroyale.com";
        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }

        static string[] cardNames = {"Ice Spirit", "Mirror"};
        [Test, Category("cards")]
        [TestCaseSource("cardNames")]
        // [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_Card_Details_Page(string cardName)
        {
            new CardsPage(driver).GoTo().GetCardByName(cardName).Click();
            var cardDetails = new CardDetailsPage(driver);

            var cardOnPage = cardDetails.GetBaseCard();
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