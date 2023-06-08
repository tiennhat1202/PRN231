using BusinessObject;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eStoreClient.DTO.MemberDTO
{
    public class GetMemberResponse
    {
        public int MemberId { get; set; }
        public string Email { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string Password { get; set; } = null!;
    }
}
