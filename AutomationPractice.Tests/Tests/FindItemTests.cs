using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutomationPractice.Tests
{
    public class FindItemTests
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver(@"C:/Users/navas/source/repos/Tuta_Google/GoogleMainSearch/bin/Debug/");
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
            Driver.Manage().Window.Maximize();

        }

        [Test]
        public void AddItemToCart_ThrowsConfirmationWindow_IfAddToCartButtonClicked()
        {
            Steps.LoginAndAddToCart(Driver, Wait);
            
            Assert.NotNull(Driver.FindElement(By.CssSelector("[title='Proceed to checkout']")));
        }

        

        [TearDown]
        public void CloseDriver()
        {
           // Driver.Close();
        }
    }
}
