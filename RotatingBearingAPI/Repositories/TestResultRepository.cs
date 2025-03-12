using Microsoft.EntityFrameworkCore;
using RotatingBearingAPI.Data;
using RotatingBearingAPI.Models;

namespace RotatingBearingAPI.Repositories
{
    public class TestResultRepository : ITestResultRepository
    {
        private readonly ApplicationDbContext _context;

        public TestResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TestResult> AddAsync(TestResult result)
        {
            _context.TestResults.Add(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<TestResult>> GetByTestSequenceIdAsync(int sequenceId)
        {
            return await _context.TestResults
                .Where(tr => tr.TestSequenceId == sequenceId)
                .ToListAsync();
        }
    }
}
