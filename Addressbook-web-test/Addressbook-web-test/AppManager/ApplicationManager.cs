﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager

    {
        protected IWebDriver driver;
        protected string baseURL;


        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected LogoutHelper logOutHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            logOutHelper = new LogoutHelper(this);
        }

         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }
        public static ApplicationManager GetInstance()
        {
            if(! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;

        }

        public IWebDriver Driver 
        
        { 
        get
            {

                return driver;
            }
        
        }


        public LoginHelper Auth
        {
            get
            {

                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {

                return navigator;
            }

        }

        public GroupHelper groups
        {
            get
            {
                return groupHelper;

            }

        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;

            }
        }

        public LogoutHelper logout
        {
            get
            {
                return logOutHelper;

            }

        }

        public object Groups { get; internal set; }
    }


    
}


