using BusinessObject.DBContext;
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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IAuthorDAO _authorDAO;
        public AuthorRepository(IAuthorDAO authorDAO)
        {
            _authorDAO = authorDAO;
        }

        public void Add(Author author)
        {
            _authorDAO.Add(author);
        }

        public void Delete(int id)
        {
            _authorDAO.Delete(id);
        }

        public List<Author> Get()
        {
            return _authorDAO.Get();
        }

        public Author GetAuthorById(int id)
        {
            return _authorDAO.GetAuthorById(id);
        }

        public void Update(Author author)
        {
            _authorDAO.Update(author);
        }
    }
}
