using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SampleProject.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        public IWebDriver? driver;
        [BeforeScenario] 
        public void InitializeBrowser() 
        {
            driver = new ChromeDriver();
            
        }
        [AfterScenario]
        public void CleanupBrowser()
        {
            driver?.Quit();
        }
        [Given(@"Google Homepage should be loaded")]
        public void GivenGoogleHomepageShouldBeLoaded()
        {
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }

        [When(@"Type ""([^""]*)"" in the search text input")]
        public void WhenTypeInTheSearchTextInput(string searchText)
        {
            IWebElement searchInput = driver.FindElement(By.Id("APjFqb"));
            searchInput.SendKeys(searchText);
        }

        [When(@"Click on the Google Search button")]
        public void WhenClickOnTheGoogleSearchButton()
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            IWebElement? gsb = fluentWait.Until(d =>
            {
                IWebElement? searchButton = driver?.FindElement(By.Name("btnK"));
                return searchButton.Displayed ? searchButton : null;
            });
            if (gsb != null)
            {
                gsb.Click();
            }
        }

        [Then(@"The results should be displayed on the next page with title ""([^""]*)""")]
        public void ThenTheResultsShouldBeDisplayedOnTheNextPageWithTitle(string title)
        {
            Assert.That(driver?.Title, Is.EqualTo(title));
        }
        [When(@"Click on the I'm feeling lucky button")]
        public void WhenClickOnTheImFeelingLuckyButton()
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            IWebElement? imflb = fluentWait.Until(d =>
            {
                IWebElement? luckyButton = driver?.FindElement(By.Name("btnI"));
                return luckyButton.Displayed ? luckyButton : null;
            });
            if (imflb != null)
            {
                imflb.Click();
            }
        }

        [Then(@"The results should be displayed on the next page with title containing ""([^""]*)""")]
        public void ThenTheResultsShouldBeDisplayedOnTheNextPageWithTitleContaining(string title)
        {
            Assert.That(driver.Title.Contains(title));
        }

    }
}
