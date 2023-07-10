using BusinessObject.DBContext;
using BusinessObject.Models;
using DataAccess.IDAO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AuthorDAO : IAuthorDAO
    {

        private readonly ApplicationDBContext _applicationDBContext;

        public AuthorDAO(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public List<Author> Get()
        {
            var Authors = new List<Author>();
            try
            {
                Authors = _applicationDBContext.Authors.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Authors;
        }


        public Author GetAuthorById(int id)
        {
            var Author = new Author();
            try
            {
                Author = _applicationDBContext.Authors.SingleOrDefault(a => a.AuthorId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Author;
        }


        public void Add(Author author)
        {
            try
            {
                _applicationDBContext.Authors.Add(author);
                _applicationDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Author author)
        {
            try
            {
                Author _author = _applicationDBContext.Authors.SingleOrDefault(c => c.AuthorId == author.AuthorId);
                if (_author != null)
                {
                    _applicationDBContext.Authors.Update(author);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Author Not Found");
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
                Author _author = _applicationDBContext.Authors.SingleOrDefault(c => c.AuthorId == id);
                if (_author != null)
                {
                    _applicationDBContext.Authors.Remove(_author);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Author Not Found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
