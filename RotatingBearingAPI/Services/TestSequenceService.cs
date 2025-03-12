using RotatingBearingAPI.Models;
using RotatingBearingAPI.Repositories;

namespace RotatingBearingAPI.Services
{
    public class TestSequenceService : ITestSequenceService
    {
        private readonly ITestSequenceRepository _testSequenceRepository;

        public TestSequenceService(ITestSequenceRepository testSequenceRepository) 
        {
            _testSequenceRepository = testSequenceRepository;
        }

        public async Task<TestSequence> CreateTestSequenceAsync(TestSequence sequence)
        {
            return await _testSequenceRepository.AddAsync(sequence);
        }

        public async Task<TestSequence> GetTestSequenceByIdAsync(int id)
        {
            return await _testSequenceRepository.GetByIdAsync(id);
        }

        public async Task<List<TestSequence>> GetAllTestSequencesAsync()
        {
            return await _testSequenceRepository.GetAllAsync();
        }

        public async Task UpdateTestSequenceAsync(TestSequence sequence)
        {
            await _testSequenceRepository.UpdateAsync(sequence);
        }

        public async Task DeleteTestSequenceAsync(int id)
        {
            await _testSequenceRepository.DeleteAsync(id);
        }
    }
}
