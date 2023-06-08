using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        public static List<Member> GetMembers()
        {
            var listMembers = new List<Member>();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    listMembers = context.Members.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listMembers;
        }

        public static Member FindMemberById(int id)
        {
            var member = new Member();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    member = context.Members.SingleOrDefault(m => m.MemberId == id)!;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return member;
        }

        public static Member FindMemberByEmail(string email)
        {
            var member = new Member();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    member = context.Members.Where(m => m.Email == email).First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return member;
        }

        public static Member FindMemberByEmailAndPw(string email, string pw)
        {
            var member = new Member();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    int find = context.Members.Where(m => m.Email.Equals(email) && m.Password.Equals(pw)).Count();

                    if(find == 0)
                    {
                        member = null;
                    }
                    else
                    {
                        member = context.Members.Where(m => m.Email.Equals(email) && m.Password.Equals(pw)).First();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return member;
        }

        public static void AddMember(Member m)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Members.Add(m);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateMember(Member newMember)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    Member oldMember = context.Members.SingleOrDefault(m => m.MemberId == newMember.MemberId)!;
                    if (oldMember != null)
                    {
                        oldMember.Email = newMember.Email;
                        oldMember.CompanyName = newMember.CompanyName;
                        oldMember.City = newMember.City;
                        oldMember.Country = newMember.Country;
                        oldMember.Password = newMember.Password;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("This member does not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteMember(int id)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                   // List<Order> listOrders = context.Orders.Where(o => o.MemberId == id).ToList();
                    context.Orders.RemoveRange(context.Orders.Where(o => o.MemberId == id));
                    context.Members.Remove(context.Members.SingleOrDefault(m => m.MemberId == id)!);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
