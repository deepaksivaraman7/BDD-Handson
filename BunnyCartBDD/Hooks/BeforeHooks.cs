using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using TechTalk.SpecFlow;

namespace BunnyCartBDD.Hooks
{
    [Binding]
    public sealed class BeforeHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public static IWebDriver? driver;

        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }
        [BeforeFeature]
        public static void LogFileCreation()
        {
            string currDir = Directory.GetParent("../../../").FullName;
            string logFileilePath = currDir + "/Logs/SearchFeature" + DateTime.Now.ToString("yyyyMMdd_Hmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logFileilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}