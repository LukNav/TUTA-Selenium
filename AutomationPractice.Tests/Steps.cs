using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.Tests
{
    public static class Steps
    {
        public static void LoginAndAddToCart(IWebDriver driver, WebDriverWait wait)
        {
            Steps.LogInWithValidData(driver, wait);
            wait.Until(D => D.FindElement(By.ClassName("page-heading")));

            Steps.AddItemToCart(driver, wait);
            wait.Until(D => D.FindElement(By.CssSelector("title='Proceed to checkout'")));
        }


        public static void GoToIndexPage( IWebDriver driver)
        {
            driver.Url = "http://automationpractice.com/index.php";
        }

        public static void LogIn(IWebDriver driver, WebDriverWait wait, string email, string password)
        {
            GoToIndexPage(driver);
            driver.FindElement(By.ClassName("login")).Click();

            wait.Until(D => D.FindElement(By.Id("email")));
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("passwd")).SendKeys(password);
            driver.FindElement(By.Id("SubmitLogin")).SendKeys(Keys.Enter);
        }

        public static void LogInWithValidData(IWebDriver driver, WebDriverWait wait)
        {
            LogIn(driver, wait, "geader.nn@gmail.com", "LukNav");
        }

        public static void AddItemToCart(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.Id("header_logo")).Click();
            wait.Until(D => D.FindElement(By.ClassName("ajax_block_product")));
            driver.FindElement(By.ClassName("ajax_block_product"))
                .FindElement(By.ClassName("ajax_add_to_cart_button"))
                .Click();
        }
    }
}
