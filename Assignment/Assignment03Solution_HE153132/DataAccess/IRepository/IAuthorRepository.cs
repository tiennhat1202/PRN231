using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IAuthorRepository
    {
        List<Author> Get();
        Author GetAuthorById(int id);
        void Add(Author author);
        void Update(Author author);
        void Delete(int id);
    }
}
