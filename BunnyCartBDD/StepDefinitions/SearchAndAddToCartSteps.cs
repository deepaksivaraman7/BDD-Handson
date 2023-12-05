using BunnyCartBDD.Hooks;
using BunnyCartBDD.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCartBDD.StepDefinitions
{
    [Binding]
    internal class SearchAndAddToCartSteps:CoreCodes
    {
        public static IWebDriver? driver = BeforeHooks.driver;

        [Then(@"The title should have'([^']*)'")]
        public void ThenTheHeadingShouldHave(string searchtext)
        {
            TakeScreenshot(driver);
            Log.Information("Screenshot taken");
            try
            {
                Assert.That(driver.Title, Does.Contain(searchtext));
                LogTestResult("Title check test", "Title check passed");
            }
            catch (Exception ex)
            {
                LogTestResult("Title check test", "Title check test failed", ex.Message);
            }
        }

        [When(@"User selects a '([^']*)'")]
        public void WhenUserSelectsA(string productName)
        {
            //driver.Url = "https://www.bunnycart.com/catalogsearch/result/?q=water";
            IWebElement product = driver.FindElement(By.LinkText(productName));
            product.Click();
        }

        [Then(@"Product page should be loaded with '([^']*)'")]
        public void ThenProductPageShouldBeLoaded(string product)
        {
            TakeScreenshot(driver);
            Log.Information("Screenshot taken");
            try
            {
                Assert.That(driver.Title.ToLower(), Does.Contain(product.ToLower()));
                LogTestResult("Product page title test","Product page title test passed");
            }
            catch(Exception ex)
            {
                LogTestResult("Product page title test", "Product page title test failed",ex.Message);
            }
        }

    }
}
