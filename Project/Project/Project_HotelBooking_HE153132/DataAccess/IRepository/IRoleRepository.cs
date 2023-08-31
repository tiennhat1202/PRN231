﻿using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IRoleRepository
    {
        List<Role> GetAllRole();
        Role GetRoleById(int id);
        void Add(Role Role);
        void Update(Role Role);
        void Delete(int id);
    }
}