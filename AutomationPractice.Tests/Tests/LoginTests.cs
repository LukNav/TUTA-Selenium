using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutomationPractice.Tests
{
    public class LoginTests
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver(@"C:/Users/navas/source/repos/Tuta_Google/GoogleMainSearch/bin/Debug/");
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
        }

        [Test]
        public void Login_ThrowsError_IFInputIsInvalid()
        {
            Steps.GoToIndexPage(Driver, Wait);
            Steps.GoFromIndexToLoginPage(Driver, Wait);
            Steps.EnterInvalidLogInData(Driver, Wait);

            Assert.NotNull(Driver.FindElement(By.ClassName("alert")));
        }        

        [Test]
        public void Login_SwitchesPage_IFInputIsValid()
        {
            Steps.LogInSteps(Driver, Wait);

            Assert.AreEqual("MY ACCOUNT", Driver.FindElement(By.ClassName("page-heading")).Text);
        }

        [TearDown]
        public void CloseDriver()
        {
            Driver.Close();
        }
    }
}

/*
 +1.Sign in to the account
 +2.Validate correct sign in
 3.Search for an item in the shop
 4.Validate that it finds the item
 5.Finish buying the item
 6.Validate that the order is completed
 */