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

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            
            manager.Navigator.GoToHomePage();

            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text, element.Text));
            }
            return contacts;
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
            return this;
    }

      

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
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
    }


}
