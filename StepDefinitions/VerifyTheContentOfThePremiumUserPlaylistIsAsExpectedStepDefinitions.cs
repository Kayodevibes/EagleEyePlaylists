using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace EagleEyeAssement.StepDefinitions
{
    [Binding]
    public class VerifyTheContentOfThePremiumUserPlaylistIsAsExpectedStepDefinitions
    {

        private RestResponse response;
    
        [Then(@"the response body should contain the correct content for the premium featured category")]
        public void ThenTheResponseBodyShouldContainTheCorrectContentForThePremiumFeaturedCategory()
        {
            var client = new RestClient();
            var request = new RestRequest("https://a8e38tulbj.execute-api.eu-west-2.amazonaws.com/api/playlists/premium", Method.Get);
            response = client.Execute(request);           
            var responseBody = JObject.Parse(response.Content); ;
            var expectedFeaturedContent = new[]
            {
                "The Shawshank Redemption",
                "The Godfather",
            };
            var featuredPlaylist = responseBody["playlists"].FirstOrDefault(playlist => playlist["name"].ToString() == "Featured");
            
            Assert.IsNotNull(featuredPlaylist, "Expected the 'Featured' playlist to be present in the response");

            foreach (var expectedContent in expectedFeaturedContent)
            {
                Assert.IsTrue(featuredPlaylist["content"]
                    .Any(content => content["name"].ToString() == expectedContent),
                    $"Expected '{expectedContent}' to be present in the 'Featured' playlist");
            }
        }

        [Then(@"the response body should contain the correct content for the premium user Premium category")]
        public void ThenTheResponseBodyShouldContainTheCorrectContentForThePremiumUserPremiumCategory()
        {
            var responseBody = JObject.Parse(response.Content);
            var expectedMostwatchedContent = new[]
            {
                "Pulp Fiction",
                "Fight Club",
            };

            var mostwatchedPlaylist = responseBody["playlists"].FirstOrDefault(playlist => playlist["name"].ToString() == "Premium");

            Assert.IsNotNull(mostwatchedPlaylist, "Expected the 'Most watched' playlist to be present in the response");

            foreach (var expectedContent in expectedMostwatchedContent)
            {
                Assert.IsTrue(mostwatchedPlaylist["content"]
                    .Any(content => content["name"].ToString() == expectedContent),
                    $"Expected '{expectedContent}' to be present in the 'Most watched' playlist");
            }
        }

        [Then(@"the response body should conrain the correct content for the premium user Most watched category")]
        public void ThenTheResponseBodyShouldConrainTheCorrectContentForThePremiumUserMostWatchedCategory()
        {
            var responseBody = JObject.Parse(response.Content);
            var expectedMostwatchedContent = new[]
            {
                "The Dark Knight",
                "The Lord of the Rings: The Return of the King",
            };

            var mostwatchedPlaylist = responseBody["playlists"].FirstOrDefault(playlist => playlist["name"].ToString() == "Most watched");

            Assert.IsNotNull(mostwatchedPlaylist, "Expected the 'Most watched' playlist to be present in the response");

            foreach (var expectedContent in expectedMostwatchedContent)
            {
                Assert.IsTrue(mostwatchedPlaylist["content"]
                    .Any(content => content["name"].ToString() == expectedContent),
                    $"Expected '{expectedContent}' to be present in the 'Most watched' playlist");
            }
        }
    }
}
