using System.ComponentModel.DataAnnotations;

namespace eStoreAPI.DTO.MemberDTO
{
    public class UpdateMemberRequest
    {
        public int MemberId { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        [Required, MinLength(6), MaxLength(20)]
        public string Password { get; set; } = null!;
    }
}
