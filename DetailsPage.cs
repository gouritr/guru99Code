using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGuru99
{
    class DetailsPage:BasePage
    {
        [FindsBy(How=How.CssSelector,Using="span.price")]
        IWebElement labelPrice; 

        public DetailsPage(IWebDriver driver)
            : base(driver)
        {

        }

        public void verifythePricedisplayed(string pricetocompare)
        {
            Assert.That(pricetocompare.CompareTo(labelPrice.Text)==0);
        }
    }
}
