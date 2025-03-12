using Microsoft.AspNetCore.Mvc;
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
            var testResult = await _testResultService.GetResultsBySequenceIdAsync(id);
            if (testResult == null)
                return NotFound();

            return Ok(testResult);
        }

    }
}
