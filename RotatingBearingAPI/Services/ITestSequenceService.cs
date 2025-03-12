using RotatingBearingAPI.Models;

namespace RotatingBearingAPI.Services
{
    public interface ITestSequenceService
    {
        Task<TestSequence> CreateTestSequenceAsync(TestSequence sequence);
        Task<TestSequence> GetTestSequenceByIdAsync(int id);
        Task<List<TestSequence>> GetAllTestSequencesAsync();
        Task UpdateTestSequenceAsync(TestSequence sequence);
        Task<bool> DeleteTestSequenceAsync(int id);
    }
}
