using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
