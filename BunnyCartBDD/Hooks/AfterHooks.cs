using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BunnyCartBDD.Hooks
{
    [Binding]
    public sealed class AfterHooks
    {
        public static IWebDriver driver=BeforeHooks.driver;
        
        [AfterFeature]
        public static void Cleanup()
        {
            driver?.Quit();
        }
    }
}