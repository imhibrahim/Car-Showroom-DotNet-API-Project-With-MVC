using System.ComponentModel.DataAnnotations;

namespace carshowroomapi.models
{
    public class Payment
    {

        [Key]
        public int Id { get; set; }

        [Required]  
        public int SaleId { get; set; }
        public Sales Sales { get; set; }

        public string PaymentMethode { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
