using BusinessObject.DBContext;
using BusinessObject.Models;
using DataAccess.IDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO :IUserDAO
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public UserDAO(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }


        public List<User> Get()
        {
            var users = new List<User>();
            try
            {
                users = _applicationDBContext.Users.Include(u => u.Publisher).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return users;
        }

        public User GetUserById(int id)
        {
            var user = new User();
            try
            {
                user = _applicationDBContext.Users.SingleOrDefault(r => r.UserId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public User Get(string email, string password)
        {
            User users = new User();
            try
            {
                if (email.Equals("")) throw new Exception("Email must not be empty");
                if (password.Equals("")) throw new Exception("Password must not be empty");

                int find = _applicationDBContext.Users.Where(u => u.EmailAddress.Equals(email) && u.Password.Equals(password)).Count();
                if (find == 0)
                {
                    users = null;
                }
                else
                {
                    users = _applicationDBContext.Users.Where(u => u.EmailAddress.Equals(email) && u.Password.Equals(password)).First();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return users;
        }

        public User GetUserByEmail(string email)
        {
            User user = new User();
            int find = _applicationDBContext.Users.Where(u => u.EmailAddress.Equals(email)).Count();
            try
            {   
                if(find == 0)
                {
                    user = null;
                }
                else
                {
                    user = _applicationDBContext.Users.Where(u => u.EmailAddress.Equals(email)).First();

                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public void Add(User user)
        {
            try
            {
                _applicationDBContext.Users.Add(user);
                _applicationDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(User user)
        {
            try
            {
                User _user = _applicationDBContext.Users.SingleOrDefault(c => c.UserId == user.UserId);
                if (_user != null)
                {
                    _applicationDBContext.Users.Update(user);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User Not Found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                User _user = _applicationDBContext.Users.SingleOrDefault(c => c.UserId == id);
                if (_user != null)
                {
                    _applicationDBContext.Users.Remove(_user);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User Not Found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
