using E_CommerceAPI.Models;

namespace E_CommerceAPI.DTOs
{
    public class GetProductDTO
    {
        public int ProductID { get; set; }
        public string ImageUri { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int Price { get; set; }
    }
}
