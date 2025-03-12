using Microsoft.EntityFrameworkCore;
using RotatingBearingAPI.Data;
using RotatingBearingAPI.Models;

namespace RotatingBearingAPI.Repositories
{
    public class TestSequenceRepository : ITestSequenceRepository
    {
        private readonly ApplicationDbContext _context;

        public TestSequenceRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<TestSequence> AddAsync(TestSequence sequence)
        {
            _context.TestSequences.Add(sequence);
            await _context.SaveChangesAsync();
            return sequence;
        }
        public async Task<TestSequence> GetByIdAsync(int id)
        {
            return await _context.TestSequences
                .Include(ts => ts.Steps)        // Include steps in the result
                .FirstOrDefaultAsync(ts => ts.Id == id);
        }

        public async Task<List<TestSequence>> GetAllAsync()
        {
            return await _context.TestSequences.Include(ts => ts.Steps).ToListAsync();
        }

        public async Task UpdateAsync(TestSequence sequence)
        {
            _context.TestSequences.Update(sequence);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var sequence = await _context.TestSequences.FindAsync(id);
            if (sequence != null)
            {
                return false; // Return false if the test sequence doesn't exist

            }

            _context.TestSequences.Remove(sequence);
            await _context.SaveChangesAsync();

            return true;  // Return true when deletion is successful
        }

    }
}
