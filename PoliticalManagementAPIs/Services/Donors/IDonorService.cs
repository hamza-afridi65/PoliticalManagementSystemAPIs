using Microsoft.AspNetCore.Mvc;
using PoliticalManagementAPIs.Models.Donors;

namespace PoliticalManagementAPIs.Services.Donors
{
    public interface IDonorService
    {
        Task<List<Donor>> GetDonors();
        Task<Donor> GetDonorByid(int id);
        Task<int> CreateDonor(Donor donor);
        Task<int> UpdateDonor(Donor donor);
        Task<int> DeleteDonor(int Id);

    }
}
