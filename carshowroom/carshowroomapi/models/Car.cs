using System.ComponentModel.DataAnnotations;

namespace carshowroomapi.models
{
    public class Car
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public string brand { get; set; }

        public string model { get; set; }

        public int  price{ get; set; }
        public int year { get; set; }

        public string color { get; set; }

        public int StockQuantity { get; set; }


        public bool IsAvailable { get; set; }

        public string ImageUrl { get; set; }


    }
}
