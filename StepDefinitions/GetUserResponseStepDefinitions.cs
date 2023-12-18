using NUnit.Framework;
using RestSharp;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace EagleEyeAssement.StepDefinitions
{
    [Binding]
    public class GetUserResponseStepDefinitions
    {
        public static RestResponse response;
        private Stopwatch stopwatch;
        private static string endPoint = "";
        [Given(@"I have an endpoint for the ""([^""]*)"" user type playlist")]
        public void GivenIHaveAnEndpointForTheUserTypePlaylist(string userType)
        {
            if (userType == "free")
            {
                endPoint = "https://a8e38tulbj.execute-api.eu-west-2.amazonaws.com/api/playlists/free";
            }
            else if (userType == "premium")
            {
                endPoint = "https://a8e38tulbj.execute-api.eu-west-2.amazonaws.com/api/playlists/premium";
            }
            else

            {
                endPoint = "https://a8e38tulbj.execute-api.eu-west-2.amazonaws.com/api/playlists/plus";
            }

        }     

        [When(@"I search for the playlist")]
        public void WhenISearchForThePlaylist()
        {
            var client = new RestClient();
            var request = new RestRequest(endPoint, Method.Get);
            var body = "playlistsJson";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            stopwatch = Stopwatch.StartNew();
            response = client.Execute(request); // Assign to the class-level  variable
            stopwatch.Stop();
            Console.WriteLine(response.Content);
        }

        
        [When(@"I send the GET request to the playlist API")]
        public void WhenISendTheGETRequestToThePlaylistAPI()
        {
            var client = new RestClient();
            var request = new RestRequest("https://a8e38tulbj.execute-api.eu-west-2.amazonaws.com/api/playlists/free", Method.Get);
            var body = "playlistsJson";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            stopwatch = Stopwatch.StartNew();
            response = client.Execute(request); // Assign to the class-level  variable
            stopwatch.Stop();
            Console.WriteLine(response.Content);
        }

        [Then(@"the response status code for my request should be (.*)")]
        public void ThenTheResponseStatusCodeForMyRequestShouldBe(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)response.StatusCode);
        }
        

        [Then(@"the response Content-Type should be application/json")]
        public void ThenTheResponseContent_TypeShouldBeApplicationJson()
        {         
            const string expectedContentType = "application/json";           
            var actualContentType = response.ContentType;
            Assert.AreEqual(expectedContentType, actualContentType, $"Expected Content-Type to be {expectedContentType}, but found {actualContentType}");
        }

        [Then(@"the response time should be less than (.*)ms")]
        public void ThenTheResponseTimeShouldBeLessThanMs(int expectedResponseTime)
        {
            var actualResponseTime = (int)stopwatch.ElapsedMilliseconds;
            Assert.Less(actualResponseTime, expectedResponseTime, $"Expected response time to be below {expectedResponseTime}ms, but found {actualResponseTime}ms");
        }
        
        [Then(@"the message ""([^""]*)"" is returned")]
        public void ThenTheMessageIsReturned(string message)
        {
            Assert.IsTrue(response.Content.Contains(message),
           $"Expected message: {message}\nActual response content:{response.Content}");
        } 

    }
}
