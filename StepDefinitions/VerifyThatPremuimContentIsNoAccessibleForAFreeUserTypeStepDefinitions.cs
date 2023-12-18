using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace EagleEyeAssement.StepDefinitions
{
    [Binding]
    public class VerifyThatPremuimContentIsNoAccessibleForAFreeUserTypeStepDefinitions
    {
        private RestResponse response;
        public VerifyThatPremuimContentIsNoAccessibleForAFreeUserTypeStepDefinitions()
        {
            response = GetUserResponseStepDefinitions.response;
        }

        [Then(@"the response body should not contain any content that only a Premium user should have")]
        public void ThenTheResponseBodyShouldNotContainAnyContentThatOnlyAPremiumUserShouldHave()
        {
            var responseBody = JObject.Parse(response.Content);
            
            var freeUserTypePlaylist = responseBody["playlists"]
                .FirstOrDefault(playlist => playlist["name"].ToString() == "Premium");

            
            Assert.IsNull(freeUserTypePlaylist, "Expected the 'Premium' playlist to not be present in the response");

            if (freeUserTypePlaylist != null)
            {
                
                var excludedPremiumContent = new[]
                {
                    "Pulp Fiction",
                    "Fight Club",
                    "Most watched",
                };

                foreach (var unexpectedContent in excludedPremiumContent)
                {
                    Assert.IsFalse(freeUserTypePlaylist["content"]
                    .Any(content => content["name"].ToString() == unexpectedContent),
                    $"Expected '{unexpectedContent}' to not be present in the 'Free User Type' playlist");
                }
            
           
            }
        }
    }
}