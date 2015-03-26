using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace ProjectGuru99
{
    class MobilePage:BasePage
    {
        string expectedTitle = "Mobile";

        [FindsBy(How = How.CssSelector,Using="button[title='Add to Cart']")]
        IWebElement btnAddToCart;

        [FindsBy(How = How.CssSelector,Using = "select[title='Sort By']")]
        IWebElement selectSortBy;

        [FindsBy(How= How.CssSelector,Using=".product-name")]
        IList<IWebElement> items; 

        public void SortByName()
        {
            SelectElement element = new SelectElement(selectSortBy);
            element.SelectByText("Name");

            
        }

        public MobilePage(IWebDriver driver)
            : base(driver)
        {

         }

        public void vfbileTitle()
        {
            string actual = _Driver.Title.ToString();
            Assert.AreEqual(expectedTitle, actual);
        }

        public void VerifySortingByName()
        {
          string previous = items[0].Text;
          Console.WriteLine(previous);

            foreach(IWebElement i in items)
            {

                if(i.Text.CompareTo(previous) <0)
                {
                    Assert.Fail("Name sorting not working {0}  is less than {1}", i.Text, previous);
                    break;
                }

                previous = i.Text;

                
            }
            Assert.Pass("Sorting by Name working");
        }

        public ShoppingCartPage AddToCart()
        {
            btnAddToCart.Click();
            ShoppingCartPage s = new ShoppingCartPage(_Driver);
            PageFactory.InitElements(_Driver, s);
            return s;
        }

        public string getItemPrice(string itemName)
        {
            IList<IWebElement> Items = _Driver.FindElements(By.CssSelector("h2.product-name"));

            IList<IWebElement> ItemPrice = _Driver.FindElements(By.CssSelector(".price-box"));
            int i = 0;
            foreach(IWebElement item in items)
            {
                if (item.Text.CompareTo(itemName.ToUpper()) == 0)
                {

                    return ItemPrice[i].Text;
                    break;
                }
                i++;
            }


            return "";

        }


        public DetailsPage ClickItem(String itemName)
        {
            IList<IWebElement> Items = _Driver.FindElements(By.CssSelector("h2.product-name"));

            foreach (IWebElement item in items)
            {
                if (item.Text.CompareTo(itemName.ToUpper()) == 0)
                {

                    item.Click();
                    DetailsPage d = new DetailsPage(_Driver);
                    PageFactory.InitElements(_Driver, d);
                    return d;
                    
                }
                
            }

            return null;
        }

    }
}
