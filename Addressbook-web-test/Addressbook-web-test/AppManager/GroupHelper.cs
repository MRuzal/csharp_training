using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
           
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGropuCreation();
           FillGroupForm(group);
           SubmitGroupCreation();
           ReturnToGroupsPage();
           return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;

        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }

        public GroupHelper InitNewGropuCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.XPath("//form[@action='/addressbook/group.php']")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

    }

}
