using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace ProjectGuru99
{
    class CustomerAccountPage:BasePage
    {
        [FindsBy(How=How.CssSelector,Using="a[title='Create an Account']")]
        IWebElement btnCreateAccount;
        public CustomerAccountPage(IWebDriver driver) : base(driver)
        {

        }
        public CreateAccountPage ClickCreateAccount()
        {
            btnCreateAccount.Click();
            CreateAccountPage CA = new CreateAccountPage(_Driver);
            PageFactory.InitElements(_Driver, CA);
            return CA;
        }
    }
}
