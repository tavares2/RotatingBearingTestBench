using Microsoft.AspNetCore.Mvc;
using RotatingBearingAPI.DTOs;
using RotatingBearingAPI.Services;

namespace RotatingBearingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestResultController : ControllerBase
    {
        private readonly ITestResultService _testResultService;

        public TestResultController(ITestResultService testResultService)
        {
            _testResultService = testResultService;
        }

        // POST: api/testresult/{id}/start
        [HttpPost("{id}/start")]
        public async Task<IActionResult> StartTestSimulation(int id)
        {
            var testResults = await _testResultService.RunTestSimulationAsync(id);
            if (testResults == null) 
            {
                return BadRequest("Failed to start test simulation.");
            }

            return Ok(testResults);
        }

        // GET: api/testresult/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestResult(int id)
        {
            var testResults = await _testResultService.GetResultsBySequenceIdAsync(id);
            if (testResults == null)
                return NotFound();

            var resultDtos = testResults
                .Select(tr => new TestResultDto
                {
                    Id = tr.Id,
                    Timestamp = tr.Timestamp,
                    RotationSpeed = tr.RotationSpeed,
                    StressLevel = tr.StressLevel,
                    Temperature = tr.Temperature,
                    TestSequenceId = tr.TestSequenceId
                })
                .ToList();
            return Ok(resultDtos);
        }

    }
}
