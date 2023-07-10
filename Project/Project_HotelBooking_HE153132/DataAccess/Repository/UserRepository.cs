using BussinessObject.Models;
using DataAccess.IDAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDAO _userDAO;

        public UserRepository(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        public void Add(User User)
        {
            _userDAO.Add(User);
        }

        public void Delete(int id)
        {
            _userDAO.Delete(id);
        }

        public List<User> GetAllUser()
        {
            return _userDAO.GetAllUser();
        }

        public User GetUserById(int id)
        {
            return _userDAO.GetUserById(id);
        }

        public void Update(User User)
        {
            _userDAO.Update(User);
        }

        public User GetUserLogin(string username, string password)
        {
            return _userDAO.GetUserLogin(username, password);
        }

    }
}
