using RotatingBearingUI.Models;

namespace RotatingBearingUI.Services
{
    public class TestService
    {
        private readonly HttpClient _httpClient;

        public TestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TestSequence> CreateTestSequenceAsync(TestSequence sequence)
        {
            var response = await _httpClient.PostAsJsonAsync("api/testsequence", sequence);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TestSequence>();
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
            var results = await _httpClient.GetFromJsonAsync<List<TestResult>>($"api/testresult/{sequenceId}");
            return results;
        }
    }
}
