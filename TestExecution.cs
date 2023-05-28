 using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public TestContext instance;
        public TestContext TestContext { 
            get { return instance; } 
            set { instance = value; } }

        [ClassInitialize()]

        public  static void ClassInitialize(TestContext context)
        {

        }

        [ClassCleanup()]

        public static void ClassCleanup()
        {

        }
        [TestInitialize()]
        public void TestInit()
        {
            CorePage.SeleniumInit();
        }
        [TestCleanup()]
        public void TestCleanup() 
        {
            CorePage.driver.Close();
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
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","Data.xml", "LoginWithValidUserValidPass_TC001",DataAccessMethod.Sequential)]
        public void LoginWithValidUserValidPass_TC001()
        {
            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            loginPage.Login(url,user,pass);
            String actualText = CorePage.driver.FindElement(By.ClassName("account")).Text;
            Assert.AreEqual("affannaeem1@gmail.com", actualText);
            Assert.AreEqual("https://demowebshop.tricentis.com/", CorePage.driver.Url);
        }
        [TestMethod]
        public void LoginWithInvalidUserInvalidPass_TC002()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem11@gmail.com", "aaffan222001");
            String actualText = CorePage.driver.FindElement(By.ClassName("validation-summary-errors")).Text;
            Assert.AreEqual("Login was unsuccessful. Please correct the errors and try again.\r\nNo customer account found", actualText);
            Assert.AreEqual("https://demowebshop.tricentis.com/login", CorePage.driver.Url);
        }
        [TestMethod]
        public void Logout_TC003()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            loginPage.Logout();
            bool isLogout = CorePage.driver.FindElement(By.ClassName("ico-register")).Displayed;
            Assert.IsTrue(isLogout);
        }
        [TestMethod]
        public void SearchBooks_TC001()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            booksPage.SearchBooks();
            Assert.AreEqual("https://demowebshop.tricentis.com/books",CorePage.driver.Url);
        }
        [TestMethod]
        public void SearchComputers_TC001()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            computersPage.SearchComputers();
            Assert.AreEqual("https://demowebshop.tricentis.com/computers", CorePage.driver.Url);
        }
        [TestMethod]
        public void SearchElectronics_TC001()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            electronicsPage.SearchElectronics();
            Assert.AreEqual("https://demowebshop.tricentis.com/electronics", CorePage.driver.Url);
        }
        [TestMethod]
        public void SearchApparelShoes_TC001()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            apparelShoesPage.SearchApparelShoes();
            Assert.AreEqual("https://demowebshop.tricentis.com/apparel-shoes", CorePage.driver.Url);
        }
        [TestMethod]
        public void SearchDigitalDownloads_TC001()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            digitalDownloadsPage.SearchDigitalDownloads();
            Assert.AreEqual("https://demowebshop.tricentis.com/digital-downloads", CorePage.driver.Url);
        }
        [TestMethod]
        public void SearchJewelry_TC001()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            jewelryPage.SearchJewelry();
            Assert.AreEqual("https://demowebshop.tricentis.com/jewelry", CorePage.driver.Url);
        }
        [TestMethod]
        public void SearchAnItem_TC001()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            searchPage.SearchBookName("Fiction");
            List<IWebElement> links = CorePage.driver.FindElements(By.ClassName("product-item")).ToList();
            Assert.AreEqual(2, links.Count);
        }
        [TestMethod]
        public void SearchAndAddBookItem_TC002()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            //String txt = CorePage.driver.FindElement(By.ClassName("cart-qty")).Text;
            int originalitemsincart = searchPage.CurrCartQuantity();//Convert.ToInt32(txt.Substring(1, txt.Length - 2));
            searchPage.SearchBookName("Fiction");
            searchPage.AddtoCart();
            int total = searchPage.CurrCartQuantity();
            Assert.AreEqual(originalitemsincart+1, total);
        }
        [TestMethod]
        public void PlaceOrder_TC001()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            searchPage.SearchBookName("Fiction");
            searchPage.AddtoCart();
            shoppingCartPage.PlaceAnOrder();
            Assert.AreEqual("https://demowebshop.tricentis.com/onepagecheckout", CorePage.driver.Url);
        }
        [TestMethod]
        public void RemoveFromCart_TC002()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            searchPage.SearchBookName("Fiction");
            searchPage.AddtoCart();
            int cartqtybefore = searchPage.CurrCartQuantity();
            shoppingCartPage.RemoveAnItem();
            int cartqtyafter = searchPage.CurrCartQuantity();
            Assert.AreEqual(cartqtybefore-1,cartqtyafter);
        }
        [TestMethod]
        public void CheckoutOrder_TC001()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            searchPage.SearchBookName("Fiction");
            searchPage.AddtoCart();
            shoppingCartPage.PlaceAnOrder();
            checkoutPage.CheckoutOrder();
            string str = CorePage.driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div/div/div[2]/div/div[1]")).Text;
            Assert.AreEqual("Your order has been successfully processed!",str);
        }
        [TestMethod]
        public void CheckoutOrderAndVerify_TC002()
        {
            loginPage.Login("https://demowebshop.tricentis.com/", "affannaeem1@gmail.com", "affan222001");
            searchPage.SearchBookName("Fiction");
            searchPage.AddtoCart();
            shoppingCartPage.PlaceAnOrder();
            checkoutPage.CheckoutOrder();
            int orderNum = checkoutPage.CheckoutVerify();
            string str =  CorePage.driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div/div[1]/div[1]/strong")).Text;
            int orderNumAtorderspage = Convert.ToInt32(str.Substring(14, 7));
            Assert.AreEqual(orderNum,orderNumAtorderspage);
        }
    }
}