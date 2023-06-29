using BusinessObject.DBContext;
using BusinessObject.Models;
using DataAccess.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoleDAO :IRoleDAO
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public RoleDAO(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public List<Role> Get()
        {
            var roles = new List<Role>();
            try
            {
                roles = _applicationDBContext.Roles.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return roles;
        }
        public Role GetRoleById(int id)
        {
            var role = new Role();
            try
            {
                role = _applicationDBContext.Roles.SingleOrDefault(r => r.RoleId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return role;
        }
        public void Add(Role role)
        {
            try
            {
                _applicationDBContext.Roles.Add(role);
                _applicationDBContext.SaveChanges();
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(Role role)
        {
            try
            {
                Role _role = _applicationDBContext.Roles.SingleOrDefault(c => c.RoleId == role.RoleId);
                if (_role != null)
                {

                    _applicationDBContext.Roles.Update(role);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Role Not Found");
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
                Role _role = _applicationDBContext.Roles.SingleOrDefault(c => c.RoleId == id);
                if (_role != null)
                {
                    _applicationDBContext.Roles.Remove(_role);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Role Not Found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
