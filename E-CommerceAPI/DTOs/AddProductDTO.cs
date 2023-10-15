using E_CommerceAPI.Models;

namespace E_CommerceAPI.DTOs
{
    public class AddProductDTO
    {
        public string ProductName { get; set; }
        public string ImageUri { get; set; }
        public string? ProductDescription { get; set; }
        public int Price { get; set; }
    }
}
