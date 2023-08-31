using BussinessObject.Models;
using DataAccess.DAO;
using DataAccess.IDAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IRoleDAO _roleDAO;

        public RoleRepository(IRoleDAO roleDAO)
        {
            _roleDAO = roleDAO;
        }
        public void Add(Role Role)
        {
            _roleDAO.Add(Role);
        }

        public void Delete(int id)
        {
            _roleDAO.Delete(id);
        }

        public List<Role> GetAllRole()
        {
            return _roleDAO.GetAllRole();
        }

        public Role GetRoleById(int id)
        {
            return _roleDAO.GetRoleById(id);
        }

        public void Update(Role Role)
        {
            _roleDAO.Update(Role);
        }
    }
}
