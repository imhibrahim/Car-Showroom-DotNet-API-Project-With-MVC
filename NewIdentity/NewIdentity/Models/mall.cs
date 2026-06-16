using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewIdentity.Models
{
    public class mall
    {


        [Key]
        public int MallId { get; set; }

        [Required(ErrorMessage = "Mall name is required")]
        [StringLength(100)]
        public string MallName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [Phone]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Total floors is required")]
        [Range(1, 100, ErrorMessage = "Floors must be between 1 and 100")]
        [Display(Name = "Total Floors")]
        public int TotalFloors { get; set; }

        [Required(ErrorMessage = "Opening date is required")]
        [DataType(DataType.Date)]
        public DateTime OpeningDate { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

    }
}
