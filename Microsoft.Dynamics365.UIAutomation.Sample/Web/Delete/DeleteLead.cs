﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Web
{
    [TestFixture]
    public class DeleteLead
    {
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [Test]
        public void WEBTestDeleteLead()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);

                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.Navigation.OpenSubArea("Sales", "Leads");

                xrmBrowser.Grid.SwitchView("Open Leads");

                xrmBrowser.Grid.OpenRecord(0);

                //Click the Delete button from the command bar
                //xrmBrowser.CommandBar.ClickCommand("Delete", "", true, 3000); //Use this option if Delete is under the More Commands menu
                xrmBrowser.CommandBar.ClickCommand("Delete"); //Use this option if Delete is directly visible on the command bar

                //Click the Delete button on the dialog
                xrmBrowser.Dialogs.Delete();

                xrmBrowser.ThinkTime(3000);

            }
        }
    }
}
