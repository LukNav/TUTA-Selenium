using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractice.Tests
{
    public static class Steps
    {
        #region Steps
        public static void LogInSteps(IWebDriver driver, WebDriverWait wait)
        {
            GoToIndexPage(driver, wait);
            GoFromIndexToLoginPage(driver, wait);
            EnterValidLogInData(driver, wait);
        }

        public static void AddToCartSteps(IWebDriver driver, WebDriverWait wait)
        {
            GoFromAccountToIndexPage(driver, wait);
            AddItemToCart(driver, wait);
        }

        public static void ProcessAddressSteps(IWebDriver driver, WebDriverWait wait)
        {
            ProceedToCheckout(driver, wait);
            ProcessCart(driver, wait);
            ProcessAddress(driver, wait);
            ProcessCarrier(driver, wait);
            ProcessBankwire(driver, wait);
            ProcessOrder(driver, wait);
        }
        #endregion

        #region GoTo's
        public static void GoToIndexPage(IWebDriver driver, WebDriverWait wait)
        {
            driver.Url = "http://automationpractice.com/index.php";
            wait.Until(D => D.FindElement(By.ClassName("login")));
        }

        public static void GoFromIndexToLoginPage(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.ClassName("login")).Click();
            wait.Until(D => D.FindElement(By.Id("email")));
        }

        

        public static void GoFromAccountToIndexPage(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.Id("header_logo")).Click();
            wait.Until(D => D.FindElement(By.ClassName("ajax_block_product")));
        }
        #endregion

        #region Actions
        public static void EnterLogInData(IWebDriver driver, WebDriverWait wait, string email, string password)
        {
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("passwd")).SendKeys(password);
            driver.FindElement(By.Id("SubmitLogin")).SendKeys(Keys.Enter);
        }

        public static void EnterValidLogInData(IWebDriver driver, WebDriverWait wait, string email, string password)
        {
            EnterLogInData(driver, wait, email, password);
            wait.Until(D => D.FindElement(By.ClassName("page-heading")));
        }

        public static void EnterValidLogInData(IWebDriver driver, WebDriverWait wait)
        {
            EnterValidLogInData(driver, wait, "geader.nn@gmail.com", "LukNav");
        }

        public static void EnterInvalidLogInData(IWebDriver driver, WebDriverWait wait, string email, string password)
        {
            EnterLogInData(driver, wait, email, password);
            wait.Until(D => D.FindElement(By.ClassName("alert")));
        }

        public static void EnterInvalidLogInData(IWebDriver driver, WebDriverWait wait)
        {
            EnterInvalidLogInData(driver, wait, "geader.nn555@gmail.com", "LukNa5554v");
        }

        public static void AddItemToCart(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.ClassName("ajax_block_product"))
                .FindElement(By.ClassName("ajax_add_to_cart_button")).Click();
            wait.Until(D => D.FindElement(By.LinkText("Proceed to checkout")));
        }

        public static void ProceedToCheckout(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.LinkText("Proceed to checkout")).Click();
            wait.Until(D => D.FindElement(By.ClassName("icon-trash")));
        }

        public static void ProcessCart(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.LinkText("Proceed to checkout")).Click();
            wait.Until(D => D.FindElement(By.Name("processAddress")));
        }

        
        public static void ProcessAddress(IWebDriver driver,    WebDriverWait wait)
        {
            driver.FindElement(By.Name("processAddress")).Click();
            wait.Until(D => D.FindElement(By.Id("cgv")));
        }

        public static void ProcessCarrier(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.Id("cgv")).Click();
            driver.FindElement(By.Name("processCarrier")).Click();
            wait.Until(D => D.FindElement(By.ClassName("bankwire")));
        }

        public static void ProcessBankwire(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.ClassName("bankwire")).Click();
            wait.Until(D => driver.FindElement(By.CssSelector("button.btn.btn-default.button-medium")));
        }

        public static void ProcessOrder(IWebDriver driver, WebDriverWait wait)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.CssSelector("button.btn.btn-default.button-medium")));
            driver.FindElement(By.CssSelector("button.btn.btn-default.button-medium")).Click();
            wait.Until(D => D.FindElement(By.ClassName("price")));
        }
        #endregion
    }
}
