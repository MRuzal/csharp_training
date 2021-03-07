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

            List<GroupData> oldGroups = app.groups.GetGroupList();

            app.groups.Modify(1, newData);

            List<GroupData> newGroups = app.groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);

        }
    }
}
