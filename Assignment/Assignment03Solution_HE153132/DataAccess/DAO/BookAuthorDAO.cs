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
    public class BookAuthorDAO : IBookAuthorDAO
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public BookAuthorDAO(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public List<BookAuthor> Get()
        {
            var bookAuthors = new List<BookAuthor>();
            try
            {
                bookAuthors = _applicationDBContext.BookAuthors
                    .Include(b => b.Author)
                    .Include(b => b.Book)
                    .ThenInclude(b => b.Publisher)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return bookAuthors;
        }

        public void Add(BookAuthor bookAuthor)
        {
            try
            {
                _applicationDBContext.BookAuthors.Add(bookAuthor);
                _applicationDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(BookAuthor bookAuthor)
        {
            try
            {
                _applicationDBContext.BookAuthors.Update(bookAuthor);
                _applicationDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(BookAuthor bookAuthor)
        {
            try
            {
                _applicationDBContext.BookAuthors.Remove(bookAuthor);
                _applicationDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
