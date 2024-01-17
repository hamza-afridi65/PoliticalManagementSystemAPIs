using Microsoft.AspNetCore.Routing.Matching;
using PoliticalManagementAPIs.Controllers;
using PoliticalManagementAPIs.Models.Candidates;

namespace PoliticalManagementAPIs.Services.Candidates
{
    public interface ICandidateService
    {
        Task<List<Candidate>> GetCandidates();
        Task<Candidate> GetCandidateById(int id);
        Task<int> CreateCandidate(Candidate candidate);
        Task<int> UpdateCandidate(Candidate candidate);
        Task<int> DeleteCandidate(int Id);
      
    }
}
