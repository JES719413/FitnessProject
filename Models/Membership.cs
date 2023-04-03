namespace Fitness__Project.Models
{
    public class Membership : Member
    {
        public string membershipID { get; set; }
        public DateTime startDate { get; set; }
        public string status { get; set; }

        public string membershipType { get; set; }
    }
}
