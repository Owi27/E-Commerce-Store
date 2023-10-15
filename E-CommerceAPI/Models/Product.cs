using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ImageUri { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int Price { get; set; }
    }
}