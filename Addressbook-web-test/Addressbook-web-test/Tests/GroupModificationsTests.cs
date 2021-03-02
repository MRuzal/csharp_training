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
    [TestFixture]
    public class GroupModificationsTests : AuthTestBase
    {
        [SetUp]
        public void VerifyGroupPresent()
        {
            app.groups.GroupPresentCheck();
        }

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("AAA");
            newData.Header = "Namee";
            newData.Footer = "Футер";
            app.groups.Modify(1, newData);
            
        }
    }
}
