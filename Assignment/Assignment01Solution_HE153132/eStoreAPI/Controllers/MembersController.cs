using BusinessObject;
using DataAccess;
using eStoreAPI.DTO;
using eStoreAPI.DTO.MemberDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private IMemberRepository memberRepository = new MemberRepository();

        [HttpGet]
        public ActionResult<IEnumerable<GetMemberResponse>> GetMembers()
        {
            List<Member> members = memberRepository.GetMembers();
            List<GetMemberResponse> result = GetMemberResponse.ToDTO(members);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<GetMemberResponse> GetMemberById(int id)
        {
            Member member = memberRepository.GetMemberById(id);
            GetMemberResponse result = new GetMemberResponse(member);
            return Ok(result);
        }

        [HttpGet("email")]
        public ActionResult<GetMemberResponse> GetMemberByEmail(string email)
        {
            Member member = memberRepository.FindMemberByEmail(email);
            GetMemberResponse result = new GetMemberResponse(member);
            return Ok(result);
        }

        [HttpPost("Login")]
        public ActionResult<GetMemberResponse> Login([FromBody] FormLogin formLogin)
        {
            Member member = memberRepository.FindMemberByEmailAndPw(formLogin.Email, formLogin.Password);
            if (member == null) return BadRequest("Wrong email or password");

            GetMemberResponse result = new GetMemberResponse(member);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostMember([FromBody] CreateMemberRequest createMember)
        {
            Member member = new Member()
            {
                Email = createMember.Email,
                CompanyName = createMember.CompanyName,
                City = createMember.City,
                Country = createMember.Country,
                Password = createMember.Password,
            };
            memberRepository.AddMember(member);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, [FromBody] UpdateMemberRequest updateMember)
        {
            var found = memberRepository.GetMemberById(id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                Member member = new Member()
                {
                    MemberId = id,
                    Email = updateMember.Email,
                    CompanyName = updateMember.CompanyName,
                    City = updateMember.City,
                    Country = updateMember.Country,
                    Password = updateMember.Password,
                };
                memberRepository.UpdateMember(member);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var found = memberRepository.GetMemberById(id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                memberRepository.DeleteMember(id);
                return NoContent();
            }
        }
    }
}
