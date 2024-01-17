using System.Data.SqlClient;
using System.Data;
using PoliticalManagementAPIs.Models.Donors;
using Dapper;

namespace PoliticalManagementAPIs.Services.Donors
{
    public class DonorService : IDonorService
    {
        public async Task<List<Donor>> GetDonors()
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var donors = await connection.QueryAsync<Donor>("stpGetAllDonors", null , commandType: CommandType.StoredProcedure);
                return donors.ToList();
            }
        }

        public async Task<Donor> GetDonorByid(int id)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DonorID", id);
                var donors = await connection.QueryAsync<Donor>("stpGetDonorById", parameters, commandType: CommandType.StoredProcedure);
                return donors.FirstOrDefault();
            }
        }

        public async Task<int> CreateDonor(Donor donor)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", donor.FirstName);
                parameters.Add("@LastName", donor.LastName);
                parameters.Add("@DonationAmount", donor.DonationAmount);

                var result = await connection.ExecuteAsync("stpCreateDonor", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UpdateDonor(Donor donor)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", donor.FirstName);
                parameters.Add("@LastName", donor.LastName);
                parameters.Add("@DonationAmount", donor.DonationAmount);
               
                parameters.Add("@DonorID", donor.DonorID);
                var result = await connection.ExecuteAsync("stpUpdateEmployee", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> DeleteDonor(int Id)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DonorID", Id);
                var result = await connection.ExecuteAsync("stpDeleteDonor", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }


    }
}
