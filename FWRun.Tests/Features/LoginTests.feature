Feature: Login Tests
	In order to check login
	As a user
	I want to be logged in

@High
Scenario: 01 User logged in into application
	Given I navigate to Log In page
	When I perform login
	| email                       | password |
	| oksanamakarenko92@gmail.com | 260520   |
	Then the 'MY ACCAUNT' page is displayed
