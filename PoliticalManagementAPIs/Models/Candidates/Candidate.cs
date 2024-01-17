namespace PoliticalManagementAPIs.Models.Candidates
{
    public class Candidate : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PartyAffiliation { get; set; }
        public string PartySymbol { get; set; }
        public string ContactNumber { get; set; }
        public string Location { get; set; }

    }
}
