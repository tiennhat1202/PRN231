using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDAO
{
    public interface IBookAuthorDAO
    {
        List<BookAuthor> Get();
        void Add(BookAuthor bookAuthor);
        void Update(BookAuthor bookAuthor);
        void Delete(BookAuthor bookAuthor);
    }
}
