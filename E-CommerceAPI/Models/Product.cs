namespace E_CommerceAPI.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public List<string> ProductImages { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int Price { get; set; }
    }
}
