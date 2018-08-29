Feature: Accounts
	In order to prove the technology stack, 
	I need to log into an Account.

@EasyRepro
Scenario: Create Account
	Given I have logged into Dynamics 365 as 'ben.bartle'
	And I have navigated to 'Sales' and 'Accounts'
	And I have clicked 'New'
	And I enter 'Bens Account' as the name
	And I select 'Private Company' as the type
	When I click Save
	Then the account is given an account number
