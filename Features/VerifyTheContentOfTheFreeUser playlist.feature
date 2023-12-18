Feature: Verify the content of the free user playlist is as expected

This test will verify the content of the playlist that the free user has access to.
Ensuring that a free user has access to "Featured" and "Most Watched" content and verifying the content. 

Background: 
Scenario Outline: GET request for user type
	
    Given I have an endpoint for the "<User>" user type playlist
    When I search for the playlist	    

    Examples:
    | User    |
    | free    |

@tag1
Scenario: Verify the movies in Free user playlist are as expected
   Then the response body should contain the correct content for the free user featured category
   And the response body should contain the correct content for the free user Most watched category

