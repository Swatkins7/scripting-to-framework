using Framework;
using Framework.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Royale.Pages;

namespace Tests
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        public void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.Init();
            Driver.Goto(FW.Config.Test.Url);
        }

        [TearDown]
        public void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if(outcome == TestStatus.Passed)
            {
                FW.Log.Info("Oucome: Passed");
            }
            else if(outcome == TestStatus.Failed)
            {
                Driver.TakeScreenshot("test_failed");
                FW.Log.Info("Outcome: Failed");
            }
            else
            {
                FW.Log.Warning("Outcome: " + outcome);
            }

            Driver.Quit();
        }
    }
}