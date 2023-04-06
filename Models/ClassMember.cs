using System.ComponentModel.DataAnnotations;

namespace Fitness__Project.Models
{
    public class ClassMember
    {
        [Key]
        public int Id { get; set; } 
        public string ClassName { get; set; }
        public string memberId { get; set; }
        public string startTime { get; set; } 
        
    }
}
