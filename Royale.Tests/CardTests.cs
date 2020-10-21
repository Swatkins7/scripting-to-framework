using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;

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

        [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {       
            var cardsPage = new CardsPage(driver);
            var iceSpirit = cardsPage.GoTo().GetCardByName("Ice Spirit");
            Assert.That(iceSpirit.Displayed);
        }

        [Test]
        public void Ice_Spirit_headers_are_correct_on_Card_Details_Page()
        {
            new CardsPage(driver).GoTo().GetCardByName("Ice Spirit").Click();
            var cardDetailsPage = new CardDetailsPage(driver);
            var (category, arena) = cardDetailsPage.GetCardCategory();
            var cardName = cardDetailsPage.Map.CardName.Text;
            var cardRarity = cardDetailsPage.GetCardRarity();

            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", category);
            Assert.AreEqual("Arena 8", arena);
            Assert.AreEqual("Common", cardRarity);
        }
    }
}