// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Web
{
    [TestFixture]
    public class GlobalSearchXrm
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [Test]
        public void WEBTestGlobalSearch()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(500);

                xrmBrowser.Navigation.GlobalSearch("contoso");

                xrmBrowser.GlobalSearch.Search("Contoso");
                xrmBrowser.ThinkTime(4000);


            }
        }

        [Test]
        public void WEBTestGlobalSearchOpenRecord()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(500);

                xrmBrowser.Navigation.GlobalSearch("");
                xrmBrowser.GlobalSearch.Search("Contoso");
                xrmBrowser.GlobalSearch.OpenRecord("Accounts",0) ;
                xrmBrowser.ThinkTime(4000);


            }
        }

        [Test]
        public void WEBTestGlobalSearchFilterWith()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(500);

                xrmBrowser.Navigation.GlobalSearch("");
                xrmBrowser.GlobalSearch.Search("Contoso");
                xrmBrowser.GlobalSearch.FilterWith("Account");

                xrmBrowser.ThinkTime(4000);


            }
        }
    }
}