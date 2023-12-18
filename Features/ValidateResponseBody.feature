Feature: ValidateResponseBody

As a free or premium user type 
I want to search for playlist 
so that I can see the playlist that I'm entitled to see 

@tag1
Scenario Outline: Validate Response Body
	Given I have an endpoint for the "<User>" user type playlist
    When I search for the playlist	    
    Then the message "<Content>" is returned

    Examples:
    | User    | Content                                       |
    | free    | Featured                                      |
    | free    | The Shawshank Redemption                      |
    | free    | The Godfather                                 |
    | free    | Most watched                                  |
    | free    | The Dark Knight                               |
    | free    | The Lord of the Rings: The Return of the King |
    | premium | Featured                                      |
    | premium | The Shawshank Redemption                      |
    | premium | The Godfather                                 |
    | premium | Most watched                                  |
    | premium | The Dark Knight                               |
    | premium | The Lord of the Rings: The Return of the King |
    | premium | Pulp Fiction                                  |
                                                
                                                  