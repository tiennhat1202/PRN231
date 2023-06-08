using BusinessObject;
using System.ComponentModel;

namespace eStoreAPI.DTO.MemberDTO
{
    public class GetMemberResponse
    {
        public int MemberId { get; set; }
        public string Email { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string Password { get; set; } = null!;

        public GetMemberResponse(Member member)
        {
            MemberId = member.MemberId;
            Email = member.Email;
            CompanyName = member.CompanyName;
            City = member.City;
            Country = member.Country;
            Password = member.Password;
        }
        public static List<GetMemberResponse> ToDTO(List<Member> listMembers)
        {
            List<GetMemberResponse> getMemberResponse = new List<GetMemberResponse>();
            foreach (var item in listMembers) getMemberResponse.Add(new GetMemberResponse(item));
            return getMemberResponse;
        }
    }
}
