using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

         public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

           IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)

            {
                Address = address,
                AllPhones = allPhones,
            };
        }


        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone

            };
        } 

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            DeleteContact();

            return this;

        }
        public ContactHelper Modify(int p, ContactData newInfo)
        {
            SelectContact(p);
            EditContact();
            FillTheContactCreationForm(newInfo);
            SubmitContactModification();
            
            return this;
        }


        public ContactHelper CreateContact(ContactData Contact)

        {
            manager.Navigator.GoToContactCreationPage();
            FillTheContactCreationForm(Contact);
            SubmitContactCreation();
            return this;
        }

        private List<ContactData> ContactCache = null;

        public List<ContactData> GetContactList()
        {
            if (ContactCache == null)
            {
                ContactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string firstname = "";
                    string lastname = "";
                    lastname = cells[2].Text;
                    firstname = cells[1].Text;
                    ContactCache.Add(new ContactData(lastname, firstname));
                }
            }
            return new List<ContactData>(ContactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name=\"entry\"]")).Count;
        }

        public ContactHelper FillTheContactCreationForm(ContactData Contact)
        {
            Typee(By.Name("firstname"), Contact.Firstname);
            Typee(By.Name("lastname"), Contact.Lastname);
            return this;
        }


        public ContactHelper SubmitContactCreation()
    {
        driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            ContactCache = null;
            return this;
    }

      

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            ContactCache = null;

            return this;
        }

        public ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("//img[@title='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            ContactCache = null;
            return this;
        }

        public ContactHelper ContactPresentCheck()
        {
            if (IsElementPresent(By.Name("selected[]")))
            {
            }
            else
            {

                ContactData newInfo = new ContactData("Ruzal", "Muham");
                newInfo.Firstname = "sdfsdf";
                newInfo.Lastname = "fdfd";
                manager.Contacts.CreateContact(newInfo);
                manager.Navigator.GoToHomePage();

            }
            return this;
        }

        public void InitContactModification (int index) 
        {
            driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"))[7]
                  .FindElement(By.TagName("a")).Click();
        
        }

    }


}
