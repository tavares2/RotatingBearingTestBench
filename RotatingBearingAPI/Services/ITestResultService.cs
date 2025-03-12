using RotatingBearingAPI.Models;

namespace RotatingBearingAPI.Services
{
    public interface ITestResultService
    {
        Task<List<TestResult>> RunTestSimulationAsync(int sequenceId);
        Task<List<TestResult>> GetResultsBySequenceIdAsync(int sequenceId);
    }
}
