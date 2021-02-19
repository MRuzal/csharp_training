using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret")); ;
            GoToContactCreationPage();
            ContactData Contact = new ContactData();
            Contact.Firstname = "Ruzal";
            Contact.Lastname = "Mukhamadiev";
            FillTheContactCreationForm(Contact);
            SubmitContactCreation();
            GoToHomePage();
            LogOut();
        }

    }
}
