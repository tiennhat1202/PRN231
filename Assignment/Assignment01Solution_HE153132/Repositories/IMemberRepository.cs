using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IMemberRepository
    {
        void AddMember(Member p);
        Member GetMemberById(int id);
        Member FindMemberByEmailAndPw(string email, string pw);
        Member FindMemberByEmail(string email);
        void DeleteMember(int id);
        void UpdateMember(Member p);
        List<Member> GetMembers();
    }
}
