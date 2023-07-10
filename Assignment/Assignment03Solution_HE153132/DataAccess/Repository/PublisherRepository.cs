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
    public class PublisherRepository : IPublisherRepository
    {
        private readonly IPublisherDAO _publisherDAO;
        public PublisherRepository(IPublisherDAO publisherDAO)
        {
            _publisherDAO = publisherDAO;
        }
        public void Add(Publisher publisher)
        {
            _publisherDAO.Add(publisher);
        }

        public void Delete(int id)
        {
            _publisherDAO.Delete(id);
        }

        public List<Publisher> Get()
        {
            return _publisherDAO.Get();
        }

        public Publisher GetPublisherById(int id)
        {
            return _publisherDAO.GetPublisherById(id);
        }

        public void Update(Publisher publisher)
        {
            _publisherDAO.Update(publisher);
        }
    }
}
