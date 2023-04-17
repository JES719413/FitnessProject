using Microsoft.Build.Framework;
using System.ComponentModel;

namespace Fitness__Project.Models
{
    public class Membership : Member
    {

        public string? membershipID { get; set; }
        [DisplayName("Start Date")]
        [Required]
        public DateTime startDate { get; set; }
        [DisplayName("Status")]
        [Required]
        public string? status { get; set; }
        [Required]
        [DisplayName("Membership Type")]
        public string? membershipType { get; set; }
    }
}
