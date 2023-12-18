using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace EagleEyeAssement.StepDefinitions
{
    [Binding]
    public class UnknownUserTypeStepDefinitions
    {
        private RestResponse response;

        [Given(@"this is the Base Url ""([^""]*)""")]
        public void GivenThisIsTheBaseUrl(string BaseUrl)
        {
            var options = new RestClientOptions(BaseUrl)
            {
                MaxTimeout = -1,
            };
        }

        [When(@"I make a GET request to the playlists API with an Invalid user type")]
        public void WhenIMakeAGETRequestToThePlaylistsAPIWithAnInvalidUserType()
        {
            var client = new RestClient();
            var request = new RestRequest("https://a8e38tulbj.execute-api.eu-west-2.amazonaws.com/api/playlists/UKHSDFIUUHSD/", Method.Get);
            var body = "playlistsJson";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            response = client.Execute(request); 
            Console.WriteLine(response.Content);
        }

        [Then(@"the Api should return a HTTP (.*) Bad Request with a message indicating ""([^""]*)""")]
        public void ThenTheApiShouldReturnAHTTPBadRequestWithAMessageIndicating(int expectedStatusCode, string expectedErrorMessage)
        {
            Assert.AreEqual(expectedStatusCode, (int)response.StatusCode);
            Assert.IsTrue(response.Content.Contains(expectedErrorMessage),
            $"Expected message: {expectedErrorMessage}\nActual response content:{response.Content}");
        }       

    }

}
