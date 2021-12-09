Feature: Quote
	
	As a user i want to be able to create a quote 
	so that I can get an inssurance 


	Background: 
	Given the quote form is displayed

Scenario: User Create A Quote
	When  user creates a quote
	Then  user should be able to view "Success — Quote created" message


Scenario: User can view pending quotes
	When  user clicks on view my pending quote
	Then  the pending quotes should be displayed 
	 

Scenario: User can create quote from pending quote
	When  user clicks on view my pending quote
	And   user continue filling the quote form 
	Then  user should be able to view "Success — Quote created" message