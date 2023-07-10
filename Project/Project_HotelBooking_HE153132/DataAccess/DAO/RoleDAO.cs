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
    public class RoleDAO : IRoleDAO
    {
        private readonly Hotel_BookingContext _dbContext;
        public RoleDAO(Hotel_BookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Role> GetAllRole()
        {
            var Roles = new List<Role>();
            try
            {
                Roles = _dbContext.Roles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Roles;
        }
        public Role GetRoleById(int id)
        {
            var Role = new Role();
            try
            {
                Role = _dbContext.Roles.SingleOrDefault(x => x.RoleId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Role;
        }

        public void Add(Role Role)
        {
            try
            {
                _dbContext.Roles.Add(Role);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Role Role)
        {
            try
            {
                Role _Role = _dbContext.Roles.SingleOrDefault(x => x.RoleId == Role.RoleId);
                if (_Role != null)
                {
                    _dbContext.Roles.Update(Role);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Role not found");
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
                Role _Role = _dbContext.Roles.SingleOrDefault(x => x.RoleId == id);
                if (_Role != null)
                {
                    _dbContext.Roles.Remove(_Role);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Role not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
