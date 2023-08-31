using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDAO
{
    public interface IUserDAO
    {
        List<User> GetAllUser();
        User GetUserById(int id);
        void Add(User User);
        void Update(User User);
        void Delete(int id);
        User GetUserLogin(string email, string password);
        User GetEmailResetPassword(string email);   
    }
}
