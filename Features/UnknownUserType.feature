Feature: UnknownUserTyperequest 

As an Unkown user type I should not be able to access the free or premium user playlists content.


@tag1
Scenario: Unkown user type request 
	Given this is the Base Url "https://a8e38tulbj.execute-api.eu-west-2.amazonaws.com"
	When I make a GET request to the playlists API with an Invalid user type	
	Then the Api should return a HTTP 400 Bad Request with a message indicating "Unknown user type"
