Feature: AdsModule
	In order to be able to manage my ads
	As an Musician
	I want to be able to create, edit, delete and use all ad options

@regression
Scenario: A user should be able to create an Ad
	Given a session for a Musician
	When Ad is created and saved
	Then the new ad should be visible in the ads admin panel

@regression
Scenario: A user should be able to edit an Ad
	Given a session for a Musician
	When Ad is edited and saved
	Then modifications should be visible in the ads admin panel

@regression
Scenario: A user should be able to delete an Ad
	Given a session for a Musician
	When and ad is deleted
	Then the ad should dissapear from the ads admin