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
        public int UserID { get; set; } 
        public List<Guid> OrderNumbers { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
