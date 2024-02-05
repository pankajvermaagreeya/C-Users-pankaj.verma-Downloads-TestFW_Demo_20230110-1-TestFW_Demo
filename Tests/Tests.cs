using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestFW_Demo.Helper;
using TestFW_Demo.Model;
using TestFW_Demo.Pages;

namespace TestFW_Demo
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();
        TestDataStructures testDataStructures;
        DemoModel demoModel;
        MainPageModel mainPageModel;

        [SetUp]
        public void Setup()
        {
            testDataStructures = TestDataReader.GetTestDataJsonObject();
            demoModel = testDataStructures.TestDataModel.DemoModel;
            mainPageModel = testDataStructures.TestDataModel.MainPageModel;
        }

        [Test]
        public void VerifyLoginPage()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(demoModel.URL);
            LoginPage loginPage = new LoginPage(driver);
            Assert.IsTrue(loginPage.Login(demoModel.Username, demoModel.Password));
        }

        [Test]
        public void VerifySearchedValue()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(demoModel.URL);
            MainPage mainPage = new MainPage(driver);
            Assert.IsTrue(mainPage.SearchForGivenInputValue(mainPageModel.SearchInputValue));
        }

        [Test]
        public void VerifySearchedValueResults()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(demoModel.URL);
            MainPage mainPage = new MainPage(driver);
            Assert.IsTrue(mainPage.SearchForGivenInputValue(mainPageModel.SearchInputValue));
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            Assert.IsTrue(searchResultsPage.VerifySearchResults());
        }

        [Test]
        public void AddItemToCart()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(demoModel.URL);
            MainPage mainPage = new MainPage(driver);
            Assert.IsTrue(mainPage.SearchForGivenInputValue(mainPageModel.Item));
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            Assert.IsTrue(searchResultsPage.AddItemsToCart());
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
            driver.Quit();
        }

    }
}