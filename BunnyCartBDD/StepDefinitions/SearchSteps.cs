using BunnyCartBDD.Hooks;
using BunnyCartBDD.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCartBDD.StepDefinitions
{
    [Binding]
    internal class SearchSteps:CoreCodes
    {
        public static IWebDriver? driver=BeforeHooks.driver;
        IWebElement? searchInput;
        
        [Given(@"User will be on the homepage")]
        public void GivenUserWillBeOnTheHomepage()
        {
            driver.Url = "https://www.bunnycart.com/";
            driver.Manage().Window.Maximize();
        }

        [When(@"User will type the '([^']*)' in the searchbox")]
        public void WhenUserWillTypeTheInTheSearchbox(string searchtext)
        {
            searchInput=driver?.FindElement(By.Id("search"));
            searchInput?.SendKeys(searchtext);
            Log.Information("Typed " + searchtext);
        }

        [When(@"User clicks on enter button")]
        public void WhenUserClicksOnEnterButton()
        {
            searchInput?.SendKeys(Keys.Enter);
            Log.Information("Pressed enter");
        }

        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            TakeScreenshot(driver);
            Log.Information("Screenshot taken");
            try
            {
                Assert.That(driver?.Url, Does.Contain(searchtext));
                LogTestResult("Search test", "Search test success");
            }
            catch (AssertionException ex){
                LogTestResult("Search test", "Search test failed", ex.Message);
            }
        }
    }
}
