using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace carshowroomapi.models
{
    public class Sales
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int Carid { get; set; }
        public Car Car { get; set; }

        [Required]
        public int Customerid { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int TotelAmount { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }
    }
}
