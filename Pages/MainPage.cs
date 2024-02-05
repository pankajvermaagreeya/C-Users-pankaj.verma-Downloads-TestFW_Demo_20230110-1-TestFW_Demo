using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFW_Demo.Pages
{
    public class MainPage
    {
        private IWebDriver driver;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver"></param>
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region PageLocators
        public IWebElement MegaMenuTab => driver.FindElement(By.XPath("//span[contains(text(),'Mega Menu')]"));
        public IWebElement SearchInput => driver.FindElement(By.XPath("(//input[@name='search'])[1]"));
        public IWebElement SearchButton => driver.FindElement(By.XPath("//button[text()='Search']"));

        #endregion

        #region Functions
        public bool SearchForGivenInputValue(string searchInputValue)
        {
            bool value = false;
            Thread.Sleep(3000);
            SearchInput.SendKeys(searchInputValue);
            Thread.Sleep(3000);
            SearchButton.Click();
            Thread.Sleep(5000);
            string searchValue = driver.FindElement(By.XPath("//h1[contains(text(),'Search -')]")).Text;
            string[] searchedValue = searchValue.Split('-');
            if (searchedValue[searchedValue.Length - 1].Trim()==searchInputValue){
                Console.WriteLine("Searched For : " + searchedValue[searchedValue.Length - 1]);
                value = true;
            }
            return value;
        }

        #endregion
    }
}
