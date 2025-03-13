using RotatingBearingAPI.Models;

namespace RotatingBearingAPI.Repositories
{
    public interface ITestSequenceRepository
    {
        Task<TestSequence> AddAsync(TestSequence sequence);
        Task<TestSequence> GetByIdAsync(int id);
        Task<List<TestSequence>> GetAllAsync();
        Task UpdateAsync(TestSequence sequence);
        Task<bool> DeleteAsync(int id);
        Task<TestSequence?> FindExistingSequenceAsync(TestSequence sequence);
        Task SaveAsync();
    }
}
