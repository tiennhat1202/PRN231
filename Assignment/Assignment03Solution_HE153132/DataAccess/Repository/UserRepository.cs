using BusinessObject.Models;
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

        public void Add(User user)
        {
            _userDAO.Add(user);
        }

        public void Delete(int id)
        {
            _userDAO.Delete(id);
        }

        public List<User> Get()
        {
            return _userDAO.Get();
        }

        public User Get(string email, string password)
        {
            return _userDAO.Get(email, password);
        }

        public User GetUserByEmail(string email)
        {
            return _userDAO.GetUserByEmail(email);
        }

        public User GetUserById(int id)
        {
            return _userDAO.GetUserById(id);
        }

        public void Update(User user)
        {
            _userDAO.Update(user);
        }
    }
}
