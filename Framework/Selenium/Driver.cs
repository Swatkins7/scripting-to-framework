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

        private static WebDriverWait _wait;

        public static void Init()
        {
            _driver = new ChromeDriver(Path.GetFullPath("../../../../" + "_drivers"));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

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
            //return Current.FindElement(by);
            return _wait.Until(current => current.FindElement(by));
        }

        public static IList<IWebElement> FindElements(By by)
        {
            //return Current.FindElements(by);
            return _wait.Until(current => current.FindElements(by));
        }

        public static void Quit()
        {
            Current.Quit();
        }
    }
}