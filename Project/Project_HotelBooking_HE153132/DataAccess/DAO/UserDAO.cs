using BussinessObject.DBContext;
using BussinessObject.Models;
using DataAccess.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO : IUserDAO
    {
        private readonly Hotel_BookingContext _dbContext;
        public UserDAO(Hotel_BookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAllUser()
        {
            var Users = new List<User>();
            try
            {
                Users = _dbContext.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Users;
        }
        public User GetUserById(int id)
        {
            var User = new User();
            try
            {
                User = _dbContext.Users.SingleOrDefault(x => x.UserId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return User;
        }

        public User GetUserLogin(string username, string password)
        {
            User? user = new User();
            try
            {
                if (username.Equals("")) throw new Exception("Username can not be empty");
                if (password.Equals("")) throw new Exception("Password can not be empty");
                var findUser = _dbContext.Users.Where(u => u.Username.Equals(username) && u.Password.Equals(password)).Count();
                if(findUser == 0)
                {
                    user = null;
                }
                else
                {
                    user = _dbContext.Users.Where(u => u.Username.Equals(username) && u.Password.Equals(password)).First();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public void Add(User User)
        {
            try
            {
                _dbContext.Users.Add(User);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(User User)
        {
            try
            {
                User _User = _dbContext.Users.SingleOrDefault(x => x.UserId == User.UserId);
                if (_User != null)
                {
                    _dbContext.Users.Update(User);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                User _User = _dbContext.Users.SingleOrDefault(x => x.UserId == id);
                if (_User != null)
                {
                    _dbContext.Users.Remove(_User);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
