using E_CommerceAPI.Models;

namespace E_CommerceAPI.DTOs
{
    public class AddProductDTO
    {
        public List<ImageURI> ProductImages { get; set; } = new List<ImageURI>();
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int Price { get; set; }
    }
}
