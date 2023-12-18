Feature: GetUserResponse

As a free, premium or unknown user type 
I want to search for a playlist 
so that I can see the playlist that I'm entitled to see 

@tag1
Scenario Outline: GET request for user type
	Given I have an endpoint for the "<User>" user type playlist
    When I search for the playlist	
    Then the response status code for my request should be <StatusCode>
    And the response Content-Type should be application/json
    And the response time should be less than 1000ms
    And the message "<Message>" is returned

    Examples:
    | User    | StatusCode | Message           |
    | free    | 200        | playlist          |
    | premium | 200        | playlist          |
    | plus    | 400        | Unknown user type |
    | unknown | 400        | Unknown user type |
    
    