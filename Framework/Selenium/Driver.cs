using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            _driver = new ChromeDriver(Path.GetFullPath("../../../../" + "_drivers"));
            Wait = new Wait(10);
        }
        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");
        public static string Title => Current.Title;

        public static void Goto(string url)
        {
            if(!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            Debug.WriteLine(url);
            Current.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElement(By by)
        {
            return Wait.Until(crnt => Current.FindElement(by));
        }

        public static IList<IWebElement> FindElements(By by)
        {
            //reverted back to match the instruction video
            return Current.FindElements(by);
        }

        public static void Quit()
        {
            Current.Quit();
        }
    }
}