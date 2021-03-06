using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CopyDeckPage : PageBase
    {
        public readonly CopyDeckPageMap Map;

        public CopyDeckPage()
        {
            Map = new CopyDeckPageMap();
        }

        public CopyDeckPage Yes()
        {
            Map.YesButton.Click();
            return this;
        }

        public CopyDeckPage No()
        {
            Map.NoButton.Click();
            AcceptCookies();
            Driver.Wait.Until(WaitConditions.ElementDisplayed(Map.OtherStoresButton));
            return this;
        }

        public void AcceptCookies()
        {
            Map.AcceptCookiesButton.Click();
            Driver.Wait.Until(WaitConditions.ElementNotDisplayed(Map.AcceptCookiesButton));
        }

        public void OpenAppStore()
        {
            Map.AppStoreButton.Click();
        }

        public void OpenGooglePlay()
        {
            Map.GooglePlayButton.Click();
        }
    }

    public class CopyDeckPageMap
    {
        public Element YesButton => Driver.FindElement(By.Id("button-open"), "Yes Button");
        public Element CopiedMessage => Driver.FindElement(By.CssSelector(".notes.active"), "Copied Message");
        public Element NoButton => Driver.FindElement(By.Id("not-installed"), "No Button");
        public Element AppStoreButton => Driver.FindElement(By.XPath("//a[text()='App Store']"), "App Store Button");
        public Element GooglePlayButton => Driver.FindElement(By.XPath("//a[text()='Google Play']"), "Google Play Button");
        public Element AcceptCookiesButton => Driver.FindElement(By.CssSelector("a.cc-btn.cc-dismiss"), "Accept Cookies Button");
        public Element OtherStoresButton => Driver.FindElement(By.Id("other-stores"), "Other Stores Button");
    }
}