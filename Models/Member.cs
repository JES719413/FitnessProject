using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness__Project.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        [Column(TypeName = "varchar(75)")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        [Column(TypeName = "varchar(75)")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Please enter your email.")]
        [Column(TypeName = "varchar(75)")]
        public string email { get; set; }
        
        [Column(TypeName = "Date")]
        public DateTime startDate { get; set; }
        [Required(ErrorMessage = "Please choose you birthday.")]
        [Column(TypeName = "Date")]
        public DateTime birthday { get; set; }
    }
}
