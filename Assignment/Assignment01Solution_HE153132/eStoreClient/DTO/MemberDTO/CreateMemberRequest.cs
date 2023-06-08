using System.ComponentModel.DataAnnotations;

namespace eStoreClient.DTO.MemberDTO
{
    public class CreateMemberRequest
    {
        [Required, MaxLength(20), EmailAddress]
        public string Email { get; set; } = null!;
        [Required, MaxLength(30)]
        public string? CompanyName { get; set; }
        [Required, MaxLength(30)]
        public string? City { get; set; }
        [Required, MaxLength(30)]
        public string? Country { get; set; }
        [Required, MinLength(6), MaxLength(15)]
        public string Password { get; set; } = null!;
    }
}
