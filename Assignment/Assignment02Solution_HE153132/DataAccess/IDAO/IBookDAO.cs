using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDAO
{
    public interface IBookDAO
    {
        List<Book> Get();
        Book GetBookById(int id);
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}
