﻿using BusinessObjects.Models;
using DataAccess.DAO;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategories() => CategoryDAO.GetCategories();
    }
}
