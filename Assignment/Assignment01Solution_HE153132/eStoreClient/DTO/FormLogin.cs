using System.ComponentModel.DataAnnotations;

namespace eStoreClient.DTO
{
    public class FormLogin
    {
        [Required, EmailAddress(ErrorMessage = "Invalid email!")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
