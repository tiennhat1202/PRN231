using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IUserRepository
    {
        List<User> Get();
        User Get(string email, string password);
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
