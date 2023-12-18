Feature: VerifyStatusCodeForEmptyUserType

The test verifies the response when a response is made with an empty user type

@tag1
Scenario: Missing User Type

	Given I have this Base Url "https://a8e38tulbj.execute-api.eu-west-2.amazonaws.com"
	When I make a GET request to the playlists API without specifying the user type
	Then the response should be a HTTP 403 Bad Request with a message indicating "Missing Authentication Token"
	