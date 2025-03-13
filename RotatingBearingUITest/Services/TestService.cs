using Newtonsoft.Json;
using RotatingBearingUITest.Models;

namespace RotatingBearingUITest.Services
{
    public class TestService : ITestService
    {
        private readonly HttpClient _httpClient;

        public TestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TestSequence> CreateTestSequenceAsync(TestSequence sequence)
        {
            var response = await _httpClient.PostAsJsonAsync("api/testsequence", sequence);
            //if (response.IsSuccessStatusCode)
            //{
            //    return await response.Content.ReadFromJsonAsync<TestSequence>();
            //}

            if (response.IsSuccessStatusCode)
            {
                // Get the raw JSON string
                var responseString = await response.Content.ReadAsStringAsync();

                // Manually deserialize the JSON string to a TestSequence object
                return JsonConvert.DeserializeObject<TestSequence>(responseString);
            }
            return null;
        }

        public async Task StartTestSimulationAsync(int sequenceId)
        {
            var response = await _httpClient.PostAsync($"api/testresult/{sequenceId}/start", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<TestResult>> GetTestResultsBySequenceIdAsync(int sequenceId)
        {
            //var results = await _httpClient.GetFromJsonAsync<List<TestResult>>($"api/testresult/{sequenceId}");
            //return results;
            var response = await _httpClient.GetStringAsync($"api/testresult/{sequenceId}");

            // Deserialize the simplified response
            return JsonConvert.DeserializeObject<List<TestResult>>(response);
        }
    }
}
