using RestSharp;
using TechTalk.SpecFlow;

namespace EagleEyeAssement.NewFolder
{
    [Binding]
    public sealed class Webhooks
    {
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            var options = new RestClientOptions("https://a8e38tulbj.execute-api.eu-west-2.amazonaws.com")
            {
                MaxTimeout = -1,
            };
            
            ScenarioContext.Current.Set(new RestClient(options), "apiClient");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TryGetValue<RestClient>("apiClient", out var apiClient))
            {
                apiClient?.Dispose();
            }
        }
    }
}