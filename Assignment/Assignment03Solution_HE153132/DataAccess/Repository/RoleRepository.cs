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
    public class RoleRepository : IRoleRepository
    {
        private readonly IRoleDAO _roleDAO;
        public RoleRepository(IRoleDAO roleDAO)
        {
            _roleDAO = roleDAO;
        }
        public void Add(Role role)
        {
            _roleDAO.Add(role);
        }

        public void Delete(int id)
        {
            _roleDAO.Delete(id);
        }

        public List<Role> Get()
        {
            return _roleDAO.Get();
        }

        public Role GetRoleById(int id)
        {
            return _roleDAO.GetRoleById(id);
        }

        public void Update(Role role)
        {
            _roleDAO.Update(role);
        }
    }
}
