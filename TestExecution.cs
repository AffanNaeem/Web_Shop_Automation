using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Web_Shop_Automation;
using static System.Net.Mime.MediaTypeNames;

namespace Web_Shop_Automation
{
    [TestClass]
    public class TestExecution
    {
        #region Setups and Cleanups
        public static ExtentReports extent;
        public static ExtentTest test;
        public TestContext instance;
        public TestContext TestContext
        {
            get { return instance; }
            set { instance = value; }
        }

        [ClassInitialize()]

        public static void ClassInitialize(TestContext context)
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"Reports/MyReport.html");
            extent.AttachReporter(htmlReporter);
        }

        [ClassCleanup()]

        public static void ClassCleanup()
        {
            extent.Flush();
        }
        [TestInitialize()]
        public void TestInit()
        {
            CorePage.SeleniumInit();
            test = extent.CreateTest(TestContext.TestName);
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            CorePage.driver.Close();
            var status = TestContext.CurrentTestOutcome;
            switch (status)
            {
                case UnitTestOutcome.Failed:
                    test.Log(Status.Fail, "Test Failed");
                    break;
                default:
                    test.Log(Status.Pass, "This Test Passed"); ;
                    break;
            }
        }
        #endregion
        LoginPage loginPage = new LoginPage();
        BooksPage booksPage = new BooksPage();
        ComputersPage computersPage = new ComputersPage();
        ElectronicsPage electronicsPage = new ElectronicsPage();
        ApparelShoesPage apparelShoesPage = new ApparelShoesPage();
        DigitalDownloadsPage digitalDownloadsPage = new DigitalDownloadsPage();
        JewelryPage jewelryPage = new JewelryPage();
        SearchPage searchPage = new SearchPage();
        ShoppingCartPage shoppingCartPage = new ShoppingCartPage();
        CheckoutPage checkoutPage = new CheckoutPage();

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\Data.xml", "LoginWithValidUserValidPass_TC001", DataAccessMethod.Sequential)]
        public void LoginWithValidUserValidPass_TC001()
        {
            //test = extent.CreateTest("ValidLogin");

            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            loginPage.Login(url, user, pass);
            String actualText = CorePage.driver.FindElement(By.ClassName("account")).Text;
            Assert.AreEqual("affannaeem1@gmail.com", actualText);
            Assert.AreEqual("https://demowebshop.tricentis.com/", CorePage.driver.Url);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\Data.xml", "LoginWithInvalidUserInvalidPass_TC002", DataAccessMethod.Sequential)]
        public void LoginWithInvalidUserInvalidPass_TC002()
        {
            //test = extent.CreateTest("InvalidLogin");
            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            loginPage.Login(url, user, pass);
            String actualText = CorePage.driver.FindElement(By.ClassName("validation-summary-errors")).Text;
            Assert.AreEqual("Login was unsuccessful. Please correct the errors and try again.\r\nNo customer account found", actualText);
            Assert.AreEqual("https://demowebshop.tricentis.com/login", CorePage.driver.Url);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        public void Logout_TC003()
        {
            //test = extent.CreateTest("ValidLogout");

            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            loginPage.Logout();
            bool isLogout = CorePage.driver.FindElement(By.ClassName("ico-register")).Displayed;
            Assert.IsTrue(isLogout);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        public void SearchBooks_TC001()
        {
            //test = extent.CreateTest("ValidBooksTab");

            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            booksPage.SearchBooks();
            Assert.AreEqual("https://demowebshop.tricentis.com/books", CorePage.driver.Url);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        public void SearchComputers_TC001()
        {
            //test = extent.CreateTest("ValidComputersTab");

            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            computersPage.SearchComputers();
            Assert.AreEqual("https://demowebshop.tricentis.com/computers", CorePage.driver.Url);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        public void SearchElectronics_TC001()
        {
            //test = extent.CreateTest("ValidElectronicsTab");

            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            electronicsPage.SearchElectronics();
            Assert.AreEqual("https://demowebshop.tricentis.com/electronics", CorePage.driver.Url);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        public void SearchApparelShoes_TC001()
        {
            //test = extent.CreateTest("ValidApparelShoesTab");

            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            apparelShoesPage.SearchApparelShoes();
            Assert.AreEqual("https://demowebshop.tricentis.com/apparel-shoes", CorePage.driver.Url);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        public void SearchDigitalDownloads_TC001()
        {
            //test = extent.CreateTest("ValidDigitalDownloadsTab");

            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            digitalDownloadsPage.SearchDigitalDownloads();
            Assert.AreEqual("https://demowebshop.tricentis.com/digital-downloads", CorePage.driver.Url);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        public void SearchJewelry_TC001()
        {
            //test = extent.CreateTest("ValidJewelryTab");

            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            jewelryPage.SearchJewelry();
            Assert.AreEqual("https://demowebshop.tricentis.com/jewelry", CorePage.driver.Url);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        public void SearchAnItem_TC001()
        {
            //test = extent.CreateTest("SearchItem");

            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            searchPage.SearchBookName("Fiction");
            List<IWebElement> links = CorePage.driver.FindElements(By.ClassName("product-item")).ToList();
            Assert.AreEqual(2, links.Count);
            //test.Log(Status.Pass, "This Test Passed");
        }
        
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\Data.xml", "PlaceOrder_TC001", DataAccessMethod.Sequential)]
        public void PlaceOrder_TC001()
        {
            //test = extent.CreateTest("PlaceOrder");

            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string searchItem = TestContext.DataRow["search"].ToString();
            string furl = TestContext.DataRow["finalurl"].ToString();
            loginPage.Login(url, user,pass);
            searchPage.SearchBookName(searchItem);
            searchPage.AddtoCart();
            shoppingCartPage.PlaceAnOrder();
            Assert.AreEqual(furl, CorePage.driver.Url);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\Data.xml", "CheckoutOrder_TC001", DataAccessMethod.Sequential)]
        public void CheckoutOrder_TC001()
        {
            //test = extent.CreateTest("CheckoutOrder");

            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string searchItem = TestContext.DataRow["search"].ToString();
            string fmsg = TestContext.DataRow["finalmsg"].ToString();
            loginPage.Login(url, user, pass);
            searchPage.SearchBookName(searchItem);
            searchPage.AddtoCart();
            shoppingCartPage.PlaceAnOrder();
            checkoutPage.CheckoutOrder();
            string str = CorePage.driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div/div/div[2]/div/div[1]")).Text;
            Assert.AreEqual(fmsg, str);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        public void CheckoutOrderAndVerify_TC002()
        {
            //test = extent.CreateTest("VerifyOrderPlaced");

            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            searchPage.SearchBookName("Fiction");
            searchPage.AddtoCart();
            shoppingCartPage.PlaceAnOrder();
            checkoutPage.CheckoutOrder();
            int orderNum = checkoutPage.CheckoutVerify();
            WebDriverWait wait = new WebDriverWait(CorePage.driver, TimeSpan.FromSeconds(6));
            wait.Until(driver => driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div/div[1]/div[1]/strong")));

            string str = CorePage.driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div/div[1]/div[1]/strong")).Text;
            int orderNumAtorderspage = Convert.ToInt32(str.Substring(14, 7));
            Assert.AreEqual(orderNum, orderNumAtorderspage);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        [DoNotParallelize]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\Data.xml", "SearchAndAddBookItem_TC002", DataAccessMethod.Sequential)]
        public void ZSearchAndAddBookItem_TC002()
        {
            //test = extent.CreateTest("AddItemToCart");

            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string searchItem = TestContext.DataRow["search"].ToString();
            loginPage.Login(url, user, pass);
            CorePage.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            int originalitemsincart = searchPage.CurrCartQuantity();
            searchPage.SearchBookName(searchItem);
            searchPage.AddtoCart();
            int total = searchPage.CurrCartQuantity();
            CorePage.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.AreEqual(originalitemsincart + 1, total);
            //test.Log(Status.Pass, "This Test Passed");
        }
        [TestMethod]
        [DoNotParallelize]
        public void ZRemoveFromCart_TC002()
        {
            //test = extent.CreateTest("RemoveItemFromCart");

            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            searchPage.SearchBookName("Fiction");
            searchPage.AddtoCart();
            int cartqtybefore = searchPage.CurrCartQuantity();
            shoppingCartPage.RemoveAnItem();
            int cartqtyafter = searchPage.CurrCartQuantity();
            CorePage.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.AreEqual(cartqtybefore - 1, cartqtyafter);
            //test.Log(Status.Pass, "This Test Passed");
        }
    }
}