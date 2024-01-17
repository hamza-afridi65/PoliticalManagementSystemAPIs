using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliticalManagementAPIs.Models.Candidates;
using PoliticalManagementAPIs.Services.Candidates;


namespace PoliticalManagementAPIs.Controllers.NewFolder
{
    [Route("api/")]
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet("Candidate")]
        public async Task<IActionResult> GetCandidates()
        {
            var candidate = await _candidateService.GetCandidates();
            if (candidate.Count == 0)
            {
                return NotFound("Candidates not exist");
            }


            return Ok(candidate);
        }

        [HttpGet("Candidate/{id}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var candidate = await _candidateService.GetCandidateById(id);
            if (candidate == null)
            {
                return NotFound($"Candidate{id} not exist");
            }


            return Ok(candidate);
        }

        [HttpPost("Candidate")]
        public async Task<IActionResult> CreateCandidate([FromBody] Candidate candidate)
        {
            try
            {
                int result = await _candidateService.CreateCandidate(candidate);
                if (result > 0)
                    return Ok("true");
                else
                    return BadRequest("false");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Candidate/{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, [FromBody] Candidate candidate)
        {
            try
            {
                var dbCandidate = await _candidateService.GetCandidateById(id);
                if (dbCandidate == null)
                {
                    return NotFound($"CandidateId {id} not found..");
                }
                // candidate.Id=dbCandidate.Id;
                candidate.CandidateID = id;
                int result = await _candidateService.UpdateCandidate(candidate);
                if (result > 0)
                    return Ok("true");
                else
                    return BadRequest("false");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("Candidate/{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            try
            {
                var dbEmployee = await _candidateService.GetCandidateById(id);
                if (dbEmployee == null)
                {
                    return NotFound($"CandidateId {id} not found..");
                }
                int result = await _candidateService.DeleteCandidate(id);
                if (result > 0)
                    return Ok("true");
                else
                    return BadRequest("false");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }

}
