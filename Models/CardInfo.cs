using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
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
        [DisplayName("Card Number")]
        [Column(TypeName = "bigint")]
        public long cardNum { get; set; }
        [Required(ErrorMessage = "Please enter you expiration date.")]
        [DisplayName("Expiration Date")]
        [Column(TypeName = "date")]
        public DateTime expDate { get; set; }
        [Required(ErrorMessage = "Please enter your Zip code.")]
        [DisplayName("Zip Code")]
        [Column(TypeName ="int")]
        
        public int zipCode { get; set; }
    }
}
