using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Shop_Automation  
{
    class LoginPage : CorePage
    {
        #region Locators
        By loginBtnHomepage = By.ClassName("ico-login");
        By emailTxt = By.Id("Email");
        By passwordTxt = By.Id("Password");
        By loginBtnLoginpage = By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/form/div[5]/input");
        By logoutBtnLoginpage = By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[2]/a");
        #endregion

        public void Login(string url, string username, string password)
        {
            driver.Url = url;
            driver.FindElement(loginBtnHomepage).Click();
            driver.FindElement(emailTxt).SendKeys(username);
            driver.FindElement(passwordTxt).SendKeys(password);
            driver.FindElement(loginBtnLoginpage).Click();
        }
        public void Logout()
        {
            driver.FindElement(logoutBtnLoginpage).Click();
        }
    }
}
