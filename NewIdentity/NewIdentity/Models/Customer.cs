using System.ComponentModel.DataAnnotations;

namespace NewIdentity.Models
{
    public class Customer
    {
            public int id { get; set; }
        [Required]
            public string name { get; set; }
        [Required]
            public string address { get; set; }
        [Required]
        public int cnic { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string email { get; set; }
        

    }
}
