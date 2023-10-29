using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.Models
{
    public class TokenObject
    {
        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
