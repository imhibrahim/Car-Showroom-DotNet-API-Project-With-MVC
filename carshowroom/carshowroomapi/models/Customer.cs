using System.ComponentModel.DataAnnotations;

namespace carshowroomapi.models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public int CNIC { get; set; }

        public string City { get; set; }

        public string Email { get; set; }
    }
}
