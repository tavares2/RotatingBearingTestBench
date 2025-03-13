using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotatingBearingAPI.Models;
using RotatingBearingAPI.Services;

namespace RotatingBearingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestSequenceController : ControllerBase
    {
        private readonly ITestSequenceService _testSequenceService;

        public TestSequenceController(ITestSequenceService testSequenceService)
        {
            _testSequenceService = testSequenceService;
        }

        // GET: api/testsequence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestSequence>>> GetAllSequences()
        {
            var sequences = await _testSequenceService.GetAllTestSequencesAsync();
            return Ok(sequences);
        }

        // GET: api/testsequence/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TestSequence>> GetSequenceById(int id)
        {
            var sequence = await _testSequenceService.GetTestSequenceByIdAsync(id);
            if (sequence == null)
            {
                return NotFound();
            }
            return Ok(sequence);
        }

        // POST: api/testsequence
        [HttpPost]
        public async Task<ActionResult<TestSequence>> CreateSequence([FromBody] TestSequence sequence)
        {
            if (sequence == null)
            {
                return BadRequest("Invalid Data,");
            }


            var createdSequence = await _testSequenceService.CreateTestSequenceAsync(sequence);
            //await _testSequenceService.CreateTestSequenceAsync(sequence);
            return Created($"api/testsequence/{createdSequence.Id}", createdSequence);
            //return CreatedAtAction(nameof(GetSequenceById), new { id = createSequence.Id }, createSequence);
        }

        // DELETE: api/testsequence/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSequence(int id)
        {
            var deleted = await _testSequenceService.DeleteTestSequenceAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        

    }
}
