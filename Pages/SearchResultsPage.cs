using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFW_Demo.Pages
{
    public class SearchResultsPage
    {
        private IWebDriver driver;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver"></param>
        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region PageLocators
        public IWebElement SearchResultsGrid => driver.FindElement(By.XPath("//div[@data-view_id='grid']"));
        public IWebElement CartIcon => driver.FindElement(By.XPath("//div[@class='cart-icon']"));

        #endregion

        #region Functions
        /// <summary>
        /// Verify the Search Results
        /// </summary>
        /// <returns></returns>
        public bool VerifySearchResults()
        {
            bool value = false;
            if (SearchResultsGrid.Displayed)
            {
                IList<IWebElement> element = driver.FindElements(By.XPath("//div[@data-view_id='grid']/div/div"));
                if (element.Count != 0)
                {
                    for(int i = 1; i <= element.Count; i++)
                    {
                        if(driver.FindElement(By.XPath("(//div[@data-view_id='grid']/div/div)["+i.ToString()+"]/div/div/a")).Displayed
                            && driver.FindElement(By.XPath("(//div[@data-view_id='grid']/div/div)[" + i.ToString() + "]/div[2]/h4")).Displayed
                            && driver.FindElement(By.XPath("(//div[@data-view_id='grid']/div/div)[ "+ i.ToString() + "]/div[2]/div[@class='price']")).Displayed)
                        {
                            value = true;
                        }
                    }
                }
            }
            return value;
        }

        /// <summary>
        /// Add Items to Cart
        /// </summary>
        public bool AddItemsToCart()
        {
            bool value = false;
            if (SearchResultsGrid.Displayed)
            {
                IList<IWebElement> element = driver.FindElements(By.XPath("//div[@data-view_id='grid']/div/div"));
                if (element.Count != 0)
                {
                    if (driver.FindElement(By.XPath("(//div[@data-view_id='grid']/div/div)[1]/div/div/a")).Displayed)
                    {
                        Actions action = new Actions(driver);
                        action.MoveToElement(driver.FindElement(By.XPath("(//div[@data-view_id='grid']/div/div)[1]/div/div/a"))).Perform();
                        driver.FindElement(By.XPath("(//div[@data-view_id='grid']/div/div)[1]/div/div[2]/button[@title='Add to Cart']")).Click();
                        value = true;
                    }                    
                }
            }
            return value;
        }

        #endregion
    }
}
