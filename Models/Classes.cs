
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Fitness__Project.Models
{
    public class Classes
    {
        [Key]
        public int classId { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public string status { get; set; }


        //public ICollection<ClassMember> ClassMembers { get; set; }
    }
}
