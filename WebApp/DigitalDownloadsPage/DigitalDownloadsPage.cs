using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Shop_Automation  
{
    public class DigitalDownloadsPage : CorePage
    {
        #region Locators
        By DDBtn= By.XPath("/html/body/div[4]/div[1]/div[2]/ul[1]/li[5]/a");
        #endregion

        public void SearchDigitalDownloads()
        {
           driver.FindElement(DDBtn).Click(); 
        }
    }
}
