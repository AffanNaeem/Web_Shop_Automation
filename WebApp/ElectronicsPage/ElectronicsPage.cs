using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Shop_Automation  
{
    public class ElectronicsPage : CorePage
    {
        #region Locators
        By ElectronicsBtn= By.XPath("/html/body/div[4]/div[1]/div[2]/ul[1]/li[3]/a");
        #endregion

        public void SearchElectronics()
        {
           driver.FindElement(ElectronicsBtn).Click(); 
        }
    }
}
