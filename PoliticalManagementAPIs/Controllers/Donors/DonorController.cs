using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliticalManagementAPIs.Models.Donors;
using PoliticalManagementAPIs.Services.Donors;

namespace PoliticalManagementAPIs.Controllers.Donors
{
   
    //[ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpGet("api/PoliticalManagement")]
        public async Task<IActionResult> GetDonors()
        {
            var donors = await _donorService.GetDonors();
            if (donors.Count == 0)
            {
                return NotFound("Donors not exist");
            }
            return this.Ok(donors);
        }

        [HttpGet("api/PoliticalManagement/{id}")]
        public async Task<IActionResult> GetDonorByid(int id)
        {
            var donor = await _donorService.GetDonorByid(id);
            if (donor == null)
            {
                return NotFound($"Donor{id} not exist");
            }


            return this.Ok(donor);
        }

        [HttpPost("api/PoliticalManagement")]
        public async Task<IActionResult> CreateDonor([FromBody]  Donor donor)
        {
            try
            {
                int result = await _donorService.CreateDonor(donor);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPut("api/PoliticalManagement/{id}")]
        public async Task<IActionResult> UpdateDonor(int id, [FromBody] Donor donor)
        {
            try
            {
                var dbEmployee = await _donorService.GetDonorByid(id);
                if (dbEmployee == null)
                {
                    return this.NotFound($"DonorId {id} not found..");
                }
                // employee.Id=dbEmployee.Id;
                donor.DonorID = id;
                int result = await _donorService.UpdateDonor(donor);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }

        [HttpDelete("api/PoliticalManagement/{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            try
            {
                var dbEmployee = await _donorService.GetDonorByid(id);
                if (dbEmployee == null)
                {
                    return this.NotFound($"DonorId {id} not found..");
                }
                int result = await _donorService.DeleteDonor(id);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");

            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }
    }
}
