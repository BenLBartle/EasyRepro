// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.Dynamics365.UIAutomation.Sample.Web
{
    using NUnit.Framework;

    [TestFixture]
    public class TestAccount : TestBase
    {
        [SetUp]
        public override void TestSetup()
        {
            XrmTestBrowser.ThinkTime(500);
            OpenEntity("Sales", "Accounts", "Active Accounts");
            HasData = OpenEntityGrid();
        }

        [Test]
        public void WEBTestCollapseTab()
        {
            if (!HasData) return;
            XrmTestBrowser.Entity.CollapseTab("Summary");
            XrmTestBrowser.ThinkTime(5000);
        }

        [Test]
        public void WEBTestPopOutForm()
        {
            if (!HasData) return;
            XrmTestBrowser.Entity.Popout();
            XrmTestBrowser.ThinkTime(10000);
        }

        [Test]
        public void WEBTestOpenLookup()
        {
            if (!HasData) return;
            XrmTestBrowser.Entity.SelectLookup(TestSettings.LookupField, TestSettings.LookupName);
            XrmTestBrowser.Entity.SelectLookup(TestSettings.LookupField, 0);
        }

        [Test]
        public void WEBTestSearchLookup()
        {
            if (!HasData) return;
            XrmTestBrowser.Entity.SetValue(TestSettings.LookupField, TestSettings.LookupName);
            XrmTestBrowser.Entity.SelectLookup(TestSettings.LookupField, TestSettings.LookupName);
            XrmTestBrowser.Entity.SelectLookup(TestSettings.LookupField, 0);
        }

        [Test]
        public void WEBTestSaveEntity()
        {
            if (!HasData) return;
            XrmTestBrowser.Entity.Save();
            XrmTestBrowser.ThinkTime(5000);
        }

        [Test]
        public void WEBTestCloseEntity()
        {
            if (!HasData) return;
            XrmTestBrowser.Entity.CloseEntity();
            XrmTestBrowser.ThinkTime(5000);
        }

        [Test]
        public void WEBTestExpandTab()
        {
            if (!HasData) return;
            XrmTestBrowser.Entity.CollapseTab("Summary");
            XrmTestBrowser.Entity.ExpandTab("Summary");
        }

        [Test]
        public void WEBTestSelectTab()
        {
            if (!HasData) return;
            XrmTestBrowser.Entity.SelectTab("Summary");
            XrmTestBrowser.Entity.SelectTab("Details");
            XrmTestBrowser.ThinkTime(5000);
        }

        [Test]
        public void WEBTestSelectSectionInForm()
        {
            if (!HasData) return;
            XrmTestBrowser.Entity.SelectForm("Details");
            XrmTestBrowser.ThinkTime(5000);
        }
    }
}