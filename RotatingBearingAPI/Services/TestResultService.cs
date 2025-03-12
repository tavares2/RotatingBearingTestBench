using RotatingBearingAPI.Models;
using RotatingBearingAPI.Repositories;

namespace RotatingBearingAPI.Services
{
    public class TestResultService : ITestResultService
    {
        private readonly ITestResultRepository _testResultRepository;
        private readonly ITestSequenceService _testSequenceService;
        private readonly Random _random = new();

        public TestResultService(ITestResultRepository testResultRepository, ITestSequenceService testSequenceService)
        {
            _testResultRepository = testResultRepository;
            _testSequenceService = testSequenceService;
        }

        public async Task<List<TestResult>> RunTestSimulationAsync(int sequenceId)
        {
            var testSequence = await _testSequenceService.GetTestSequenceByIdAsync(sequenceId);
            if (testSequence == null)
            {
                throw new ArgumentException("Invalid Test Sequence ID.");
            }

            var results = new List<TestResult>();

            foreach (var step in testSequence.Steps)
            {
                for (int i=0; i < step.Duration; i++)
                {
                    var result = new TestResult
                    {
                        Timestamp = DateTime.UtcNow,
                        RotationSpeed = step.Setpoint,
                        StressLevel = _random.NextDouble() * 100,  // Random stress level
                        Temperature = _random.Next(20, 80),  // Random temperature between 20ºC and 80ºC
                        TestSequenceId = sequenceId,
                    };

                    results.Add(result);
                    await _testResultRepository.AddAsync(result);
                }
            }

            return results;
        }

        public async Task<List<TestResult>> GetResultsBySequenceIdAsync(int sequenceId)
        {
            return await _testResultRepository.GetByTestSequenceIdAsync(sequenceId);
        }

        
    }
}
