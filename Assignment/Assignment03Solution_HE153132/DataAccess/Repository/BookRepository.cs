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
    public class BookRepository : IBookRepository
    {
        private readonly IBookDAO _bookDAO;
        public BookRepository(IBookDAO bookDAO)
        {
            _bookDAO = bookDAO;
        }
        public void Add(Book book)
        {
            _bookDAO.Add(book);
        }

        public void Delete(int id)
        {
            _bookDAO.Delete(id);
        }

        public List<Book> Get()
        {
            return _bookDAO.Get();
        }

        public Book GetBookById(int id)
        {
            return _bookDAO.GetBookById(id);
        }

        public void Update(Book book)
        {
            _bookDAO.Update(book);
        }
    }
}
