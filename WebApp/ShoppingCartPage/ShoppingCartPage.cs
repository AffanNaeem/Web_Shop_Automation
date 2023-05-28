using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Shop_Automation  
{
    public class ShoppingCartPage : CorePage
    {
        #region Locators
        By removeMark = By.XPath("/html/body/div[4]/div[1]/div[4]/div/div/div[2]/div/form/table/tbody/tr/td[1]/input");
        By updateCart = By.XPath("/html/body/div[4]/div[1]/div[4]/div/div/div[2]/div/form/div[1]/div/input[1]");
        By destinationDropDown = By.XPath("//*[@id=\"CountryId\"]");
        By ZipCode = By.XPath("//*[@id=\"ZipPostalCode\"]");
        By estShippingBtn = By.XPath("/html/body/div[4]/div[1]/div[4]/div/div/div[2]/div/form/div[2]/div[1]/div[2]/div/div[3]/div[4]/input");
        By TandCBtn = By.XPath("//*[@id=\"termsofservice\"]");
        By checkoutBtn = By.XPath("//*[@id=\"checkout\"]");
        #endregion

        public void RemoveAnItem()
        {
            driver.FindElement(removeMark).Click();
            driver.FindElement(updateCart).Click();
        }
        public void PlaceAnOrder()
        {
            driver.FindElement(destinationDropDown).SendKeys("Pakistan");
            driver.FindElement(ZipCode).Clear();
            driver.FindElement(ZipCode).SendKeys("75300");
            driver.FindElement(estShippingBtn).Click();
            driver.FindElement(TandCBtn).Click();
            driver.FindElement(checkoutBtn).Click();
        }
    }
}
