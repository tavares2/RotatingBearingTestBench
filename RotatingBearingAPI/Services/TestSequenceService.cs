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
            
            // Add the TestSequence first to generate the Id
            var createdSequence = await _testSequenceRepository.AddAsync(sequence);

            // After adding TestSequence, set the TestSequenceId in each step
            foreach (var step in createdSequence.Steps)
            {
                step.TestSequence = createdSequence; // Ensure the relationship is set
                step.TestSequenceId = createdSequence.Id; // Explicitly set the foreign key
            }

            // Save the TestSequence with associated steps
            await _testSequenceRepository.SaveAsync();  // Ensure save operation if using a unit of work pattern

            return createdSequence;
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

        public async Task<bool> DeleteTestSequenceAsync(int id)
        {
            return await _testSequenceRepository.DeleteAsync(id);
        }
    }
}
