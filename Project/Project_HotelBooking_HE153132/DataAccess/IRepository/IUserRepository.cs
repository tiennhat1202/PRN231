using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserById(int id);
        void Add(User User);
        void Update(User User);
        void Delete(int id);
        User GetUserLogin(string username, string password);

    }
}
