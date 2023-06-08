using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var listCategories = new List<Category>();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    listCategories = context.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listCategories;
        }
    }
}
