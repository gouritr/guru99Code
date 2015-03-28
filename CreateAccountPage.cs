using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ProjectGuru99
{
    class CreateAccountPage:BasePage
    {
        public CreateAccountPage(IWebDriver driver) : base(driver)
        {

        }
        [FindsBy(How = How.Id, Using = "firstname")]
        IWebElement txtFirstName;

        [FindsBy(How = How.Id, Using = "lastname")]
        IWebElement txtLastName;

        [FindsBy(How = How.Id, Using = "email_address")]
        IWebElement txtEmailAddress;

        [FindsBy(How = How.Id, Using = "password")]
        IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "confirmation")]
        IWebElement txtConfirmPassword;

        [FindsBy(How = How.CssSelector, Using = "button[title='Register']")]
        IWebElement btnRegister;

        public userHomePage Register(string fname,string lname,string email,string pswd)
        {

            txtFirstName.SendKeys(fname);
            txtLastName.SendKeys(lname);
            txtPassword.SendKeys(pswd);
            txtEmailAddress.SendKeys(email);
            txtConfirmPassword.SendKeys(pswd);
            btnRegister.Click();
            userHomePage U = new userHomePage(_Driver);
            PageFactory.InitElements(_Driver, U);
            return U;


        }

    }
}
