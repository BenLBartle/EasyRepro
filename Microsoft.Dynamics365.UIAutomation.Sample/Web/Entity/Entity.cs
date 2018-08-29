// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.Dynamics365.UIAutomation.Sample.Web
{
    [TestFixture]
    public class Entity : TestBase
    {
        [TestInitialize]
        public override void TestSetup()
        {
            XrmTestBrowser.ThinkTime(500);
            OpenEntity("Sales", "Contacts", "Active Contacts");
        }

        [Test]
        public void WEBTestNavigateUp()
        {
            XrmTestBrowser.Grid.OpenRecord(1);
            XrmTestBrowser.Entity.NavigateUp();
            XrmTestBrowser.ThinkTime(5000);
        }

        [Test]
        public void WEBTestNavigateDown()
        {
            XrmTestBrowser.Grid.OpenRecord(0);
            XrmTestBrowser.Entity.NavigateDown();
            XrmTestBrowser.ThinkTime(5000);
        }
    }
}