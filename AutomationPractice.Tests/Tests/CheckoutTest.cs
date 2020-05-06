using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
namespace AutomationPractice.Tests
{
    public class CheckoutTest
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver(@"C:/Users/navas/source/repos/Tuta_Google/GoogleMainSearch/bin/Debug/");
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
        }

        [Test]//AddItemToCart_ThrowsConfirmationWindow_IfAddToCartButtonClicked
        public void Checkout_ThrowsConfirmation_IfBough()
        {
            Steps.LogInSteps(Driver, Wait);
            Steps.AddToCartSteps(Driver, Wait);
            Steps.ProcessAddressSteps(Driver, Wait);
           
            Assert.NotNull(Driver.FindElement(By.ClassName("price")));         
        }



        [TearDown]
        public void CloseDriver()
        {
            Driver.Close();
        }
    }
}