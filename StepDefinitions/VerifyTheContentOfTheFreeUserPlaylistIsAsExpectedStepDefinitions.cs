using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using EagleEyeAssement.DataTransferObject;
using static EagleEyeAssement.DataTransferObject.FreeUserTypeDto;
using Newtonsoft.Json;

namespace EagleEyeAssement.StepDefinitions
{
    [Binding]
    public class VerifyTheContentOfTheFreeUserPlaylistIsAsExpectedStepDefinitions
    {
        private RestResponse response;
        public VerifyTheContentOfTheFreeUserPlaylistIsAsExpectedStepDefinitions()
        {
            response = GetUserResponseStepDefinitions.response;
        }

        [Then(@"the response body should contain the correct content for the free user featured category")]
        public void ThenTheResponseBodyShouldContainTheCorrectContentForTheFreeUserFeaturedCategory()
        {


            var responseBody = JObject.Parse(response.Content);
            
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

        [Then(@"the response body should contain the correct content for the free user Most watched category")]
        public void ThenTheResponseBodyShouldContainTheCorrectContentForTheFreeUserMostWatchedCategory()
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
