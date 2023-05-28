using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Shop_Automation  
{
    public class ComputersPage : CorePage
    {
        #region Locators
        By ComputersBtn= By.XPath("/html/body/div[4]/div[1]/div[2]/ul[1]/li[2]/a");
        #endregion

        public void SearchComputers()
        {
           driver.FindElement(ComputersBtn).Click(); 
        }
    }
}
