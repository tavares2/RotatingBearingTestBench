using RotatingBearingUITest.Models;

namespace RotatingBearingUITest.Services
{
    public interface ITestService
    {
        Task<TestSequence> CreateTestSequenceAsync(TestSequence sequence);
        Task StartTestSimulationAsync(int sequenceId);
        Task<List<TestResult>> GetTestResultsBySequenceIdAsync(int sequenceId);
    }
}
