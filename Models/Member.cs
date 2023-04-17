using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness__Project.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        [DisplayName("First Name")]
        [Column(TypeName = "varchar(75)")]
        public string? firstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        [DisplayName("Last Name")]
        [Column(TypeName = "varchar(75)")]
        public string? lastName { get; set; }
        [Required(ErrorMessage = "Please enter your email.")]
        [DisplayName("Email")]
        [Column(TypeName = "varchar(75)")]
        public string? email { get; set; }
        
        //[Column(TypeName = "Date")]
        //public new DateTime startDate { get; set; }
        [Required(ErrorMessage = "Please choose you birthday.")]
        [DisplayName("Birthday")]
        [Column(TypeName = "Date")]
        public DateTime birthday { get; set; }

       // public ICollection<ClassMember> ClassMembers { get; set; }
    }
}
