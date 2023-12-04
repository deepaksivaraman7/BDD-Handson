using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkedInTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        public static IWebDriver? driver;
        private IWebElement? passwordInput;
       
        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }
        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver.Url = "https://www.linkedin.com/";
        }
        
        [AfterFeature]
        public static void Cleanup()
        {
            driver?.Quit();
        }
        [When(@"User will enter username'(.*)'")]
        public void WhenUserWillEnterUsername(string username)
        {
            DefaultWait<IWebDriver?> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            emailInput.SendKeys(username);
        }

        [When(@"User will enter password'(.*)'")]
        public void WhenUserWillEnterPassword(string password)
        {
            DefaultWait<IWebDriver?> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            passwordInput.SendKeys(password);
        }

        [When(@"User will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js?.ExecuteScript("arguments[0].scrollIntoView(true)", driver?.FindElement(By.XPath("//button[@type='submit']")));
            js?.ExecuteScript("arguments[0].click()", driver?.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will be redirected to homepage")]
        public void ThenUserWillBeRedirectedToHomepage()
        {
            Assert.That(driver.Title, Does.Contain("LinkedIn"));
        }

        [Then(@"Error message for password length should be thrown")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {
            IWebElement? alertPara = driver?.FindElement(By.XPath("//p[@for='session_password']"));
            string? alertText=alertPara?.Text;
            Assert.That(alertText, Is.EqualTo("Please enter a password"));
        }

        [When(@"User will click on show link in the password input")]
        public void WhenUserWillClickOnShowLinkInThePasswordInput()
        {
            IWebElement? showButton = driver?.FindElement(By.XPath("//button[text()='Show']"));
            showButton?.Click();
        }

        [Then(@"The password characters should be shown")]
        public void ThenThePasswordCharactersShouldBeShown()
        {
            Assert.That(passwordInput?.GetAttribute("type"), Is.EqualTo("text"));
        }
        [When(@"User will click on show hide in the password input")]
        public void WhenUserWillClickOnShowHideInThePasswordInput()
        {
            IWebElement? hideButton = driver?.FindElement(By.XPath("//button[text()='Hide']"));
            hideButton?.Click();
        }

        [Then(@"The password characters should be hidden")]
        public void ThenThePasswordCharactersShouldBeHidden()
        {
            Assert.That(passwordInput?.GetAttribute("type"), Is.EqualTo("password"));
        }

    }
}
