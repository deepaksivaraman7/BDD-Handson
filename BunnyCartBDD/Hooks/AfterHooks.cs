using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BunnyCartBDD.Hooks
{
    [Binding]
    public sealed class AfterHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public static IWebDriver driver=BeforeHooks.driver;
        
        [AfterFeature]
        public static void Cleanup()
        {
            driver?.Quit();
        }
    }
}