using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Shop_Automation  
{
    public class JewelryPage : CorePage
    {
        #region Locators
        By JewelryBtn= By.XPath("/html/body/div[4]/div[1]/div[2]/ul[1]/li[6]/a");
        #endregion

        public void SearchJewelry()
        {
           driver.FindElement(JewelryBtn).Click(); 
        }
    }
}
