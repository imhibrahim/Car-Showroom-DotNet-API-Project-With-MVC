namespace NewIdentity.Models
{
    public class CarImage
    {
        public int id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int price { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public int stockQuantity { get; set; }
        public bool isAvailable { get; set; }
        public IFormFile path { get; set; }
    }
}
