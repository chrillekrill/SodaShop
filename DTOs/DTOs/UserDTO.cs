using System.ComponentModel.DataAnnotations;

namespace Sodashop.DTO.DTOs
{
    public class UserDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
