using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Steps
{


    [Binding]
    public class AccountsSteps
    {
        private Api.Browser _browser;
        private Uri _baseUri;

        [BeforeScenario("EasyRepro")]
        public void BeforeScenario()
        {
            _browser = new Api.Browser(TestSettings.Options);
            _baseUri = new Uri(TestContext.Parameters["crmUrl"]);
        }

        [AfterScenario("EasyRepro")]
        public void AfterScenario()
        {
            _browser.Dispose();
        }

        [Given(@"I have logged into Dynamics 365 as '(.*)'")]
        public void GivenIHaveLoggedIntoDynamicsAs(string userName)
        {
            var loginName = TestContext.Parameters[$"crmusername-{userName}"].ToSecureString();
            var loginPassword = TestContext.Parameters[$"crmpassword-{userName}"].ToSecureString();
            
            _browser.LoginPage.Login(_baseUri, loginName, loginPassword);
            _browser.GuidedHelp.CloseGuidedHelp();

            _browser.ThinkTime(500);
        }
        
        [Given(@"I have navigated to '(.*)' and '(.*)'")]
        public void GivenIHaveNavigatedToAnd(string level1, string level2)
        {

            _browser.Navigation.OpenSubArea(level1, level2);
            _browser.ThinkTime(2000);
        }
        
        [Given(@"I have clicked '(.*)'")]
        public void GivenIHaveClicked(string actionName)
        {
            _browser.CommandBar.ClickCommand(actionName);
            _browser.ThinkTime(5000);
        }
        
        [Given(@"I enter '(.*)' as the name")]
        public void GivenIEnterAsTheName(string accountName)
        {
            _browser.Entity.SetValue("name", accountName);
        }

        [Given(@"I select '(.*)' as the type")]
        public void GivenISelectAsTheType(string companyType)
        {
            _browser.Entity.SetValue(new OptionSet { Name = "inss_companytype", Value = companyType });
        }

        [When(@"I click Save")]
        public void WhenIClickSave()
        {
            _browser.CommandBar.ClickCommand("Save");
            _browser.ThinkTime(2000);
        }
        
        [Then(@"the account is given an account number")]
        public void ThenTheAccountIsGivenAnAccountNumber()
        {
            Assert.IsNotEmpty(_browser.Entity.GetValue("inss_companyregistrationnumber"), "Account Number was not populated");
        }
    }
}
