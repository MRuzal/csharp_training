using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }


        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }

        }

        public void Typee(By locatorr, string textt)
        {
            if (textt != null)
            {
                driver.FindElement(locatorr).Clear();
                driver.FindElement(locatorr).SendKeys(textt);
            }

        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementNotPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
    }
}