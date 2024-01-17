using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using PoliticalManagementAPIs.Controllers;
using PoliticalManagementAPIs.Models.Candidates;

namespace PoliticalManagementAPIs.Services.Candidates
{
    public class CandidateService : ICandidateService
    {
        public async Task<List<Candidate>> GetCandidates()
        {
            

            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var candidate = await connection.QueryAsync<Candidate>("stpGetAllCandidates", null,commandType: CommandType.StoredProcedure);
                return candidate.ToList();
            }
        }

        public async Task<Candidate> GetCandidateById(int id)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CandidateID", id);
                var candidates = await connection.QueryAsync<Candidate>("stpGetCandidateById", null, commandType: CommandType.StoredProcedure);
                return candidates.FirstOrDefault();
            }
        }

        public async Task<int> CreateCandidate(Candidate candidate)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", candidate.FirstName);
                parameters.Add("@LastName", candidate.LastName);
                parameters.Add("@PartyAffiliation", candidate.PartyAffiliation);
                parameters.Add("@PartySymbol", candidate.PartySymbol);
                parameters.Add("@ContactNumber", candidate.ContactNumber);
                parameters.Add("@Location", candidate.Location);

                var result = await connection.ExecuteAsync("stpCreateCandidate", null, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UpdateCandidate(Candidate candidate)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", candidate.FirstName);
                parameters.Add("@LastName", candidate.LastName);
                parameters.Add("@PartyAffiliation", candidate.PartyAffiliation);
                parameters.Add("@PartSymbol", candidate.PartySymbol);
                parameters.Add("@ContactNumber", candidate.ContactNumber);
                parameters.Add("@Location", candidate.Location);
                parameters.Add("@CandidateID", candidate.CandidateID);


                var result = await connection.ExecuteAsync("stpUpdateCandidate", null, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> DeleteCandidate(int Id)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters= new DynamicParameters();
                parameters.Add("@CandidateID", Id);

                var result = await connection.ExecuteAsync("stpDeleteCandidate", null, commandType:CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
