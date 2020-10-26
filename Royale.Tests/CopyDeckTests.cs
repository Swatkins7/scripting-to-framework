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
            // 2. go to deck builder page
            Driver.FindElement(By.CssSelector("a[href*='/deckbuilder']")).Click();

            // 3. click "Add cards manually"
            Driver.FindElement(By.XPath("//a[text()='add cards manually']")).Click();

            // 4. Click copy deck icon
            Driver.FindElement(By.CssSelector(".copyButton")).Click();

            // 5. click yes
            Driver.FindElement(By.Id("button-open")).Click();

            // 6. assert msg is displayed
            var copyMessage = Driver.FindElement(By.CssSelector(".notes.active"));

            Assert.That(copyMessage.Displayed);

        }
    }
}