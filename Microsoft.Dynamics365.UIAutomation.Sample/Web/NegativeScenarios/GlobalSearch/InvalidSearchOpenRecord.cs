﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Web
{
    [TestClass]
    public class InvalidSearchOpenRecord
    {
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void WEBTestInvalidSearchOpenRecord()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(500);

                xrmBrowser.Navigation.GlobalSearch("");
                xrmBrowser.GlobalSearch.Search("Contsoso");
                try
                {
                    xrmBrowser.GlobalSearch.OpenRecord("Accounts", 0);
                    Assert.Fail("Contososo returned 0 records and hence should have failed");
                }
                catch (Exception e)
                {
                    Assert.IsTrue(true, String.Format("Exception expected: {0}", e.Message));
                }
                xrmBrowser.ThinkTime(200);
            }
        }

    }
}