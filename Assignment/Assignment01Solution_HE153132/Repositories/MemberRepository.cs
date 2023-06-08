using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(Member p) => MemberDAO.AddMember(p);

        public void DeleteMember(int id) => MemberDAO.DeleteMember(id);

        public Member GetMemberById(int id) => MemberDAO.FindMemberById(id);

        public List<Member> GetMembers() => MemberDAO.GetMembers();

        public void UpdateMember(Member p) => MemberDAO.UpdateMember(p);

        public Member FindMemberByEmailAndPw(string email, string pw) => MemberDAO.FindMemberByEmailAndPw(email, pw);
        public Member FindMemberByEmail(string email) => MemberDAO.FindMemberByEmail(email);
    }
}
