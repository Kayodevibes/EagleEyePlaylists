using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace EagleEyeAssement.StepDefinitions
{
    [Binding]
    public class VerifyStatusCodeForMissingUserTypeStepDefinitions
    {
        private RestResponse response;

        [Given(@"I have this Base Url ""([^""]*)""")]
        public void GivenIHaveThisBaseUrl(string BaseUrl)
        {
            var options = new RestClientOptions(BaseUrl)
            {
                MaxTimeout = -1,
            };
        }

        [When(@"I make a GET request to the playlists API without specifying the user type")]
        public void WhenIMakeAGETRequestToThePlaylistsAPIWithoutSpecifyingTheUserType()
        {
            var client = new RestClient();
            var request = new RestRequest("https://a8e38tulbj.execute-api.eu-west-2.amazonaws.com/api/playlists/", Method.Get);
            var body = "playlistsJson";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        [Then(@"the response should be a HTTP (.*) Bad Request with a message indicating ""([^""]*)""")]
        public void ThenTheResponseShouldBeAHTTPBadRequestWithAMessageIndicating(int expectedStatusCode, string expectedErrorMessage)
        {
            Assert.AreEqual(expectedStatusCode, (int)response.StatusCode);
            Assert.IsTrue(response.Content.Contains(expectedErrorMessage),
            $"Expected error message: {expectedErrorMessage}\nActual response content:{response.Content}");
        }
       
    }
}
