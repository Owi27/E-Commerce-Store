using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public List<ImageURI> ProductImages { get; set; } = new List<ImageURI>();
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int Price { get; set; }
    }

    public class ImageURI
    {
        [Key]
        public int ID { get; set; }
        public string Uri { get; set; } = null;
    }
}
