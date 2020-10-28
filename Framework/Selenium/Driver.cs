using System;
using OpenQA.Selenium;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        public static Wait Wait;

        public static void Init()
        {
            _driver = DriverFactory.Build(FW.Config.Driver.Browser);
            Wait = new Wait(FW.Config.Driver.WaitSeconds);
        }
        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");
        public static string Title => Current.Title;

        public static void Goto(string url)
        {
            if(!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            FW.Log.Info(url);
            Current.Navigate().GoToUrl(url);
        }

        public static Element FindElement(By by, string elementName)
        {
            return new Element(Wait.Until(crnt => Current.FindElement(by)), elementName)
            {
                FoundBy = by
            };
        }

        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }

        public static void Quit()
        {
            FW.Log.Info("Close Browser");
            Current.Quit();
        }
    }
}