using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Fitness__Project.Models
{
    public class CardInfo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your card number.")]
        [Column(TypeName = "int")]
        public int cardNum { get; set; }
        [Required(ErrorMessage = "Please enter you expiration date.")]
        [Column(TypeName = "date")]
        public DateTime expDate { get; set; }
        [Required(ErrorMessage = "Please enter your Zip code.")]
        [Column(TypeName ="int")]
        
        public int zipCode { get; set; }
    }
}
