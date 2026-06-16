using System.ComponentModel.DataAnnotations;

namespace carshowroomapi.models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
