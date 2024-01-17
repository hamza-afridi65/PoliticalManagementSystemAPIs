namespace PoliticalManagementAPIs.Models.Donors
{
    public class Donor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Decimal DonationAmount { get; set; }
    }
}
