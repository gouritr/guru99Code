using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGuru99
{
    class Helper
    {
        public static void ExplictWaitForElementExists(IWebDriver driver,By by, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static bool CheckifElementExistByText(IList<IWebElement> list, string itemTexttoFind)
        {
            foreach(IWebElement i in list)
            {
                if(i.Text.CompareTo(itemTexttoFind) == 0)
                {
                    return true;
                }
            }

            return false;
        }
        public static int getIndexofElementinList(IList<IWebElement> list,string itemTextTofind)
        {
            int count = 0;
            foreach(IWebElement item in list)
            {
                if(item.Text.CompareTo(itemTextTofind)==0)
                {
                    return count;

                }
                count++;
            }
            return -1;

        }
     
    
    }
}
