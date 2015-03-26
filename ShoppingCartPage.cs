using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;



namespace ProjectGuru99
{
    class ShoppingCartPage :BasePage
    {
        [FindsBy(How=How.CssSelector,Using = "input[title='Qty']")]
        IWebElement txtQuantity;

        [FindsBy(How=How.CssSelector,Using="button[name='update_cart_action']")]
        IWebElement btnUpdate;

        [FindsBy(How = How.CssSelector, Using = ".messages .error-msg li span")]
        IWebElement Error;
        
           [FindsBy(How = How.Id, Using = "empty_cart_button")]
            IWebElement btnEmptyCart;
        public ShoppingCartPage(IWebDriver driver):base(driver)
        {

        }

        public void UpdateQty(string Quantity)
        {
            txtQuantity.Clear();
            txtQuantity.SendKeys(Quantity);
            IList<IWebElement> btns = _Driver.FindElements(By.TagName("button"));

            Boolean buttonFound = false;
            foreach(IWebElement btn in btns)
            {
                if(btn.Text == "UPDATE")
                {
                    buttonFound = true;
                    btn.Click();
                    break;
                }
            }

            if (buttonFound == false)
            {
                Assert.Fail("Update button did not appear and was not clicked");
            }

           // Helper.ExplictWaitForElementExists(_Driver,By.CssSelector(".btn-update"),10);
            
        }
        public void checkOutofQuantityError()
        {
            string pattern = "The requested quantity for (.*) is not available";
            Assert.That(Error.Displayed);
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);

            Assert.That(r.Match(Error.Text).Success);

            //Assert.AreEqual("The requested quantity for \"Sony Xperia\" is not available",Error.Text);

        }

        public void emptyCart()
        {
            btnEmptyCart.Click();
            string txt = _Driver.FindElement(By.CssSelector("h1")).Text;

            Assert.AreEqual("Shopping Cart is Empty".ToUpper(), txt);
        }
    }
}
