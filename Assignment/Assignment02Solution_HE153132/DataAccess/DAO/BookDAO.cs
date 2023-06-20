using BusinessObject.DBContext;
using BusinessObject.Models;
using DataAccess.IDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookDAO : IBookDAO
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public BookDAO(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public List<Book> Get()
        {
            var Books = new List<Book>();
            try
            {
                Books = _applicationDBContext.Books.Include(b => b.Publisher).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Books;
        }

        public Book GetBookById(int id)
        {
            var Book = new Book();
            try
            {

                Book = _applicationDBContext.Books.SingleOrDefault(b => b.BookId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Book;
        }

        public void Add(Book book)
        {
            try
            {

                _applicationDBContext.Books.Add(book);
                _applicationDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Book book)
        {
            try
            {

                Book _book = _applicationDBContext.Books.SingleOrDefault(c => c.BookId == book.BookId);
                if (_book != null)
                {

                    _applicationDBContext.Books.Update(book);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Book Not Found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                Book _book = _applicationDBContext.Books.SingleOrDefault(c => c.BookId == id);
                if (_book != null)
                {
                    _applicationDBContext.Books.Remove(_book);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Book Not Found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
