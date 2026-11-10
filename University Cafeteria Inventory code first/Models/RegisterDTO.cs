using System.ComponentModel.DataAnnotations;

namespace University_Cafeteria_Inventory_code_first.Models
{
    public class RegisterDTO
    {
        [Required]
        public string  UserName { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } 
    }
}