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
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly IBookAuthorDAO _bookAuthorDAO;
        public BookAuthorRepository(IBookAuthorDAO bookAuthorDAO)
        {
            _bookAuthorDAO = bookAuthorDAO;
        }

        public void Add(BookAuthor bookAuthor)
        {
            _bookAuthorDAO.Add(bookAuthor);
        }

        public void Delete(BookAuthor bookAuthor)
        {
            _bookAuthorDAO.Delete(bookAuthor);
        }

        public List<BookAuthor> Get()
        {
           return _bookAuthorDAO.Get();
        }

        public void Update(BookAuthor bookAuthor)
        {
            _bookAuthorDAO.Update(bookAuthor);
        }
    }
}
