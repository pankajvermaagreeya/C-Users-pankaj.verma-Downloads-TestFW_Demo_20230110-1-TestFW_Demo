using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFW_Demo.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver"></param>
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region PageLocators
        public IWebElement MyAccountProfile => driver.FindElement(By.XPath("(//span[contains(text(),'My account')])[2]"));
        public IWebElement LoginLink => driver.FindElement(By.XPath("//a[contains(text(),'Login')]"));
        public IWebElement UsernameInput => driver.FindElement(By.XPath("//input[@id='input-email']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@id='input-password']"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//input[@value='Login']"));
        public IWebElement WarningMessage => driver.FindElement(By.XPath("//div[contains(text(),' Warning: No match for E-Mail Address and/or Password.')]"));
        public IWebElement WarningMessageForMoreAttempts => driver.FindElement(By.XPath("//div[contains(text(),' Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.')]"));

        #endregion

        #region Functions
        /// <summary>
        /// Click on My Account Profile
        /// </summary>
        public void ClickOnMyAccountProfile()
        {
            Thread.Sleep(3000);
            MyAccountProfile.Click();
        }

        public void ClickOnLoginLink()
        {
            Thread.Sleep(3000);
            LoginLink.Click();
        }

        public bool Login(string username, string password)
        {
            Thread.Sleep(3000);
            ClickOnMyAccountProfile();
            Thread.Sleep(3000);
            ClickOnLoginLink();
            bool value = false;
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@id='input-email']")).SendKeys(username);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
            Thread.Sleep(3000);
            if (driver.FindElements(By.XPath("//div[contains(text(),' Warning: No match for E-Mail Address and/or Password.')]")).Count!=0)
            {
                Console.WriteLine(WarningMessage.Text);
                value = true;
            }
            else if (driver.FindElements(By.XPath("//div[contains(text(),' Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.')]")).Count!=0)
            {
                Console.WriteLine(WarningMessageForMoreAttempts.Text);
                value = true;
            }
            return value;
        }
        #endregion
    }
}
