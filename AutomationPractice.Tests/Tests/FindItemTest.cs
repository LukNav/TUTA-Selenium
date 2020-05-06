using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutomationPractice.Tests
{
    public class FindItemTest
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
        public void AddItemToCart_ThrowsConfirmationWindow_IfAddToCartButtonClicked()
        {
            Steps.LogInSteps(Driver, Wait);
            Steps.AddToCartSteps(Driver, Wait);
            Wait.Until(D => D.FindElement(By.LinkText("Proceed to checkout")));
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            Assert.NotNull(Driver.FindElement(By.LinkText("Proceed to checkout")));
        }

        

        [TearDown]
        public void CloseDriver()
        {
            Driver.Close();
        }
    }
}
