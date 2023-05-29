using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Shop_Automation  
{
    public class CheckoutPage : CorePage
    {
        #region Locators
        By billAddr = By.XPath("//*[@id=\"billing-address-select\"]");
        By billAddrBtn = By.XPath("//*[@id=\"billing-buttons-container\"]/input");
        By shipAddrInStore = By.XPath("//*[@id=\"PickUpInStore\"]");
        By shipAddrSubmitBtn = By.XPath("//*[@id=\"shipping-buttons-container\"]/input");
        //By shippingMethodRadioBtn = By.XPath("//*[@id=\"shippingoption_0\"]");
        //By shippingMethodSubmitBtn = By.XPath("//*[@id=\"shipping-method-buttons-container\"]/input");
        By paymentMethodRadioBtn = By.XPath("//*[@id=\"paymentmethod_1\"]");
        By paymentMethodSubmitBtn = By.XPath("//*[@id=\"payment-method-buttons-container\"]/input");
        By paymentInfoBtn = By.XPath("//*[@id=\"payment-info-buttons-container\"]/input");
        By ConfirmOrderBtn = By.XPath("//*[@id=\"confirm-order-buttons-container\"]/input");
        By OrderNum = By.XPath("html/body/div[4]/div[1]/div[4]/div/div/div[2]/div/ul/li[1]");
        By ordersBtn = By.XPath("/html/body/div[4]/div[2]/div[1]/div[3]/ul/li[2]/a");
        #endregion

        public void CheckoutOrder()
        {
            driver.FindElement(billAddr).SendKeys("Affan Naeem, Flat#401, Zamzam Terrace Phase#2, Block 4A, Gulshan e Iqbal, Karachi 75300, Pakistan");
            driver.FindElement(billAddrBtn).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(shipAddrInStore).Click();
            driver.FindElement(shipAddrSubmitBtn).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(paymentMethodRadioBtn).Click();
            driver.FindElement(paymentMethodSubmitBtn).Click();
            driver.FindElement(paymentInfoBtn).Click();
            driver.FindElement(ConfirmOrderBtn).Click();
        }
        public int CheckoutVerify()
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(6));
            wait.Until(driver => driver.FindElement(OrderNum));
            string str = driver.FindElement(OrderNum).Text;
            driver.FindElement(ordersBtn).Click();
            int orderNumAtOrderPage = Convert.ToInt32(str.Substring(14, 7));
            return orderNumAtOrderPage;
        }
        
    }
}
