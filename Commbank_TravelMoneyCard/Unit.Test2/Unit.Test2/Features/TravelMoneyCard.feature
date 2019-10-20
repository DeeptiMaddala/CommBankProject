Feature: TravelMoneyCard
As a customer am able to travel to Travel money card page


Scenario: Navigate to Travel Money Card Page
	Given user launches Commbank page
	When user clicks Travel Products link
	And user clicks Discover more in Travel Money Card section
	Then user validates Order Online button
	And user enters netbankId as "12345678" and password as "test1234" followed by clicking login button