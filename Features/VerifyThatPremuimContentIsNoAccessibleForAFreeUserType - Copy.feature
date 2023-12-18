Feature: VerifyThatPremuimContentIsNoAccessibleForAFreeUserType

A free user is given a list of movies that they can either buy or rent.
It is very important to the business that a free user does not have access to content that premium users have paid for.
This test ensures that the premium category does not exist in the response body and also that they movies in the premium 
file do not exist in the featured or mostwatched category for a free user.  

Background: 

Scenario Outline: GET request for user type
	Given I have an endpoint for the "<User>" user type playlist
    When I search for the playlist	

    Examples:
    | User    | 
    | free    | 
  
    
@tag1
Scenario: The response body should not contain any premium movies or content.
	
	Then the response body should not contain any content that only a Premium user should have
