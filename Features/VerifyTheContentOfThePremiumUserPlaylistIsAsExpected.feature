Feature: VerifyTheContentOfThePremiumUserPlaylistIsAsExpected

This rest will verify the content of the playlist that the Premium user has access to.
Ensuring that a Premium user has access to "Featured", "Premium" and "Most Watched" content and verifying the content.

Scenario Outline: GET request for user type
	Given I have an endpoint for the "<User>" user type playlist
    When I search for the playlist	

    Examples:
    | User    |
    | premium |
    

@tag1
Scenario:  Verify the content in Premium user playlist are as expected

    Then the response body should contain the correct content for the premium featured category
	And the response body should contain the correct content for the premium user Premium category
    And the response body should conrain the correct content for the premium user Most watched category
		
	