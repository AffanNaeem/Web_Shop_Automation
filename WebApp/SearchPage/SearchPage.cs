using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Shop_Automation  
{
    public class SearchPage : CorePage
    {
        #region Locators
        By openCartBtn = By.ClassName("cart-label");
        By searchBar = By.Id("small-searchterms");
        By searchBtn = By.XPath("/html/body/div[4]/div[1]/div[1]/div[3]/form/input[2]");
        By cartQtyBtn = By.ClassName("cart-qty");
        By addToCartBtn = By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[3]/div[1]/div[1]/div/div[2]/div[3]/div[2]/input");
        #endregion

        public void SearchBookName(string bookName)
        {
           driver.FindElement(searchBar).Click(); 
           driver.FindElement(searchBar).SendKeys(bookName);
           driver.FindElement(searchBtn).Click();    
        }
        public int CurrCartQuantity()
        {
            WebDriverWait wait = new WebDriverWait(CorePage.driver, TimeSpan.FromSeconds(6));
            wait.Until(driver => driver.FindElement(cartQtyBtn));

            String txt1 = CorePage.driver.FindElement(cartQtyBtn).Text;
            int totalitemsincart = Convert.ToInt32(txt1.Substring(1, txt1.Length - 2));
            return totalitemsincart;
        }
        public void AddtoCart()
        {
            CorePage.driver.FindElement(addToCartBtn).Click();
            CorePage.driver.FindElement(openCartBtn).Click();
        }
    }
}
