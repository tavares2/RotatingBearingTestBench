using RotatingBearingAPI.Models;

namespace RotatingBearingAPI.Repositories
{
    public interface ITestResultRepository
    {
        Task<TestResult> AddAsync(TestResult result);
        Task<List<TestResult>> GetByTestSequenceIdAsync(int sequenceId);
    }
}
